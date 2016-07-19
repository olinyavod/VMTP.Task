using System.Linq;
using System.Web.Http;
using System.Web.OData;
using VMTP.Task.Models;

namespace VMTP.Task.Web.Controllers
{
	public interface ICrudController<TEntity>
		where TEntity : class, IIdentity<int> 
	{
		IQueryable<TEntity> Get();
		TEntity Get([FromODataUri] int id);
		IHttpActionResult Post([FromBody] TEntity entity);
		IHttpActionResult Put(int key, TEntity entity);
		IHttpActionResult Patch(int key, Delta<TEntity> entityPath);
		IHttpActionResult Delete(int id);
	}
}