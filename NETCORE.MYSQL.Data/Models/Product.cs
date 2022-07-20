namespace NETCORE.MYSQL.Data.Models
{
	public class Product : AuditableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public float Cost { get; set; }
		public int Quantity { get; set; }
		public bool IsActive { get; set; }
	}
}
