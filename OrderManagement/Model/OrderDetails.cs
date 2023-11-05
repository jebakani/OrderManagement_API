using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Model
{
    public class OrderDetail
    {
		[Key]
		public int OrderId { get; set; }
		public Guid OrderNumber { get;set; }
		public DateTime OrderDate { get; set; }
		public int VendorId { get; set; }
		public int ShopId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
