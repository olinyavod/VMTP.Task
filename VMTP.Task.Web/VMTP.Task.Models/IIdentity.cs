namespace VMTP.Task.Models
{
	public interface IIdentity<TKey>
	{
		TKey Id { get; set; }
	}
}