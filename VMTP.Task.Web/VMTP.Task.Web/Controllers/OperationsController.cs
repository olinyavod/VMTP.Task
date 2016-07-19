using VMTP.Task.Data;
using VMTP.Task.Models;

namespace VMTP.Task.Web.Controllers
{
	public class OperationsController : CrudControllerBase<Operation, VMTPDbContext>, ICrudController<Operation>
	{
		protected override void Update(Operation oldEntity, Operation newEntity)
		{
			oldEntity.Name = newEntity.Name;
			oldEntity.Price = newEntity.Price;
		}
	}
}
