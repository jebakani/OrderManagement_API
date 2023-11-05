using System.Net.Sockets;

namespace OrderManagement.ViewModel
{
    public class OrderDetailView
    {
        public int OrderId { get; set; }
        public Guid OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get;set; }
        public int ShopId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

}
