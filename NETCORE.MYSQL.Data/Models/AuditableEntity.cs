namespace NETCORE.MYSQL.Data.Models
{
	public class AuditableEntity
	{
		public string EntityId { get; set; }
		public string CreatedBy { get; set; }
		public DateTime Created { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModified { get; set; }
	}
}
