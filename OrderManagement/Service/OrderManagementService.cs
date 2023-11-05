using OrderManagement.Model;
using OrderManagement.Repository;
using OrderManagement.ViewModel;

namespace OrderManagement.Service
{
    public class OrderManagementService
    {
        private readonly IOrderDetailsRepository orderDetailsRepository;
        public OrderManagementService (IOrderDetailsRepository orderDetailsRepository)
        {
            this.orderDetailsRepository = orderDetailsRepository;
        }
        public List<OrderDetailView> GetOrderDetailsList()
        {
            return orderDetailsRepository.GetOrderDetailsByCustomerId();
        }

        public bool DeleteOrderByOrderId(List<int> OrderIdList)
        {
            return orderDetailsRepository.DeleteOrderByOrderId(OrderIdList);
        }

        public async Task<int> AddOrUodateOrders(OrderDetailView orderDetail)
        {
            OrderDetail order = orderDetailsRepository.GetOrderDetailsByOrderId(orderDetail.OrderId);
            if(order == null)
            {
                order = new OrderDetail();
            }
            order.OrderNumber = Guid.NewGuid();
            order.OrderDate = orderDetail.OrderDate;
            order.VendorId= orderDetail.VendorId;
            order.ShopId = orderDetail.ShopId;
            if(order.OrderId == 0)
            {
                order.CreatedBy = orderDetail.CreatedBy;
                order.CreatedOn = DateTime.Now;
                await orderDetailsRepository.AddAsync(order);
                await orderDetailsRepository.SaveChangesAsync();
            }
            else
            {
                order.ModifiedBy = orderDetail.ModifiedBy;
                order.ModifiedOn = DateTime.Now;
                orderDetailsRepository.Update(order);
                await orderDetailsRepository.SaveChangesAsync();
            }
            return order.OrderId;

        }
        public OrderDetail GetOrderDetailsByOrderId(int orderId)
        {
            return orderDetailsRepository.GetOrderDetailsByOrderId(orderId);
        }

    }
}
