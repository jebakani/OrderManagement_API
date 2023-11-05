using Microsoft.EntityFrameworkCore;
using OrderManagement.DBContext;
using OrderManagement.Model;
using OrderManagement.ViewModel;

namespace OrderManagement.Repository
{
    public interface IOrderDetailsRepository : IBaseRepository<OrderDetail>
    {
        List<OrderDetailView>? GetOrderDetailsByCustomerId();
        OrderDetail? GetOrderDetailsByOrderId(int orderId);
        bool DeleteOrderByOrderId(List<int> OrderIdList);
    }
    public class OrderDetailsRepository : BaseRepository<OrderDetail>, IOrderDetailsRepository
    {
        private readonly OrderDBContext dbContext;
        public OrderDetailsRepository(OrderDBContext dbContext) : base(dbContext) { this.dbContext = dbContext; }
   
        public List<OrderDetailView>? GetOrderDetailsByCustomerId()
        {
            return dbContext.OrderDetail?.Join(dbContext.VendorDetails , od=>od.VendorId ,vd=>vd.VendorId , (od, vd) => new {od,vd}).Select(x=>
                       new OrderDetailView
                       {
                           OrderId =x.od.OrderId,
                           OrderNumber =x.od.OrderNumber,
                           OrderDate =x.od.OrderDate,
                           VendorId =x.od.VendorId,
                           VendorName = x.vd.VendorName,
                           ShopId  = x.od.ShopId,
                           CreatedOn = x.od.CreatedOn,
                           CreatedBy = x.od.CreatedBy,
                           ModifiedBy =x.od.ModifiedBy,
                           ModifiedOn =x.od.ModifiedOn
                       }).ToList();
        }
        public bool DeleteOrderByOrderId(List<int> OrderIdList)
        {
           // List<OrderDetails> orderDetailsList = dbContext.OrderDetails.Where(x => OrderIdList.Contains(x.OrderId)).ToList();
            try
            {
                dbContext.OrderDetail?.Where(x => OrderIdList.Contains(x.OrderId)).ExecuteDelete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public OrderDetail? GetOrderDetailsByOrderId(int orderId)
        {
            return dbContext.OrderDetail?.Where(x => x.OrderId == orderId).FirstOrDefault();
        }

    }

}
