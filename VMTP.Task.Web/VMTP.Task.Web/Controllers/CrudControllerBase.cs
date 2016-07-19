using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using VMTP.Task.Models;

namespace VMTP.Task.Web.Controllers
{
	public abstract class CrudControllerBase<TEntity, TDbContext> : ODataController, ICrudController<TEntity>
		where TEntity : class, IIdentity<int>
		where TDbContext : DbContext, new()
	{
		readonly TDbContext _context = new TDbContext();

		protected override void Dispose(bool disposing)
		{
			if(disposing)
				_context.Dispose();
			base.Dispose(disposing);
		}


		[EnableQuery]
		public virtual IQueryable<TEntity> Get()
		{
			return _context.Set<TEntity>();
		}

		public TEntity Get([FromODataUri]int id)
		{
			var result = _context
				.Set<TEntity>()
				.Find(id);
			if (result == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			return result;
		}

		protected virtual TEntity Add(TEntity entity)
		{
			return _context.Set<TEntity>().Add(entity);
		}

		public IHttpActionResult Post(TEntity entity)
		{
			try
			{
				var result = Add(entity);
				_context.SaveChanges();
				return Ok(result);
			}
			catch (ArgumentNullException e)
			{
				Debugger.Log(1, "Error", e.Message);
				return BadRequest();
			}
			catch (ArgumentException e)
			{
				Debugger.Log(1, "Error", e.Message);
				return BadRequest();
			}
			catch (InvalidOperationException e)
			{
				Debugger.Log(1, "Error", e.Message);
				return Conflict();
			}
		}

		protected abstract void Update(TEntity oldEntity, TEntity newEntity);

		public IHttpActionResult Put(int key, TEntity entity)
		{
			try
			{
				var set = _context.Set<TEntity>();
				var oldEntity = set.Find(key);
				if (oldEntity == null)
					return NotFound();
				Update(oldEntity, entity);
				_context.SaveChanges();

				return Ok(oldEntity);
			}
			catch (ArgumentNullException)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		public virtual IHttpActionResult Patch(int key, Delta<TEntity> entityPath)
		{
			var entity = _context.Set<TEntity>().Find(key);
			if (entity == null) return NotFound();
			entityPath.CopyChangedValues(entity);
			_context.SaveChanges();
			return Ok(entity);
		}

		public virtual IHttpActionResult Delete(int id)
		{
			var dbSet = _context.Set<TEntity>();
			var entity = dbSet.Find(id);
			if (entity == null)
				return NotFound();
			dbSet.Remove(entity);
			return Ok();
		}
	}
}