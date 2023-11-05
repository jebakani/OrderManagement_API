using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Model
{
    public class VendorDetails
    {
        [Key]
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
