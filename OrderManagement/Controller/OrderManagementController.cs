using Microsoft.AspNetCore.Mvc;
using OrderManagement.Model;
using OrderManagement.ViewModel;
using OrderManagement.Service;
using System.Linq.Expressions;
using log4net.Core;
using System;

namespace OrderManagement.OrderManagementController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderManagementController : ControllerBase
    {
        private readonly OrderManagementService orderManagementService;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Collaborator Controller constructor through which the manager object is assigned
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class
        /// </summary>
        /// <param name="manager">manager object is passed as parameter</param>
        private string errorMessage = "Something went wrong";
        public OrderManagementController(OrderManagementService orderManagementService)
        {
            this.orderManagementService = orderManagementService;
        }

        [HttpGet("GetOrderDetails")]
        public IActionResult GetOrderDetails()
        {
            try
            {
                List<OrderDetailView> orderDetailsList = new List<OrderDetailView>();
                orderDetailsList = orderManagementService.GetOrderDetailsList();
                if(orderDetailsList != null)
                {
                    return Ok(new
                    {
                        StatusCode = "SUCCESS",
                        Data = orderDetailsList
                    });
                }
             
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = "FAILURE",
                    StatusText = ex.Message
                });
                //    LoggerManager.LoggingErrorTrack(ex, "APIGateWay", "Accounts/ListAllAccountsByResourceId");
            }
            return Ok(new
            {
                StatusCode = "FAILURE",
                StatusText= errorMessage
            });
        }

        [HttpGet("GetOrderDetailsByOrderId")]
        public IActionResult GetOrderDetailsByOrderId(int OrderId)
        {
            try
            {
                OrderDetail orderDetails = new OrderDetail();
                orderDetails = orderManagementService.GetOrderDetailsList(OrderId);
                if (orderDetails != null)
                {
                    return Ok(new
                    {
                        StatusCode = "SUCCESS",
                        Data = orderDetails
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = "FAILURE",
                    StatusText = ex.Message
                });
                //    LoggerManager.LoggingErrorTrack(ex, "APIGateWay", "Accounts/ListAllAccountsByResourceId");
            }
            return Ok(new
            {
                StatusCode = "FAILURE",
                StatusText = errorMessage
            });
        }
        [HttpPost("DeleteOrderByOrderId")]
        public IActionResult DeleteOrderByOrderId(List<int> orderIdList)
        {
            try
            {
                bool result = orderManagementService.DeleteOrderByOrderId(orderIdList);
                if (result)
                {
                    return Ok(new
                    {
                        StatusCode = "SUCCESS",
                        StatusText = "Selected Order(s) deleted Successfully",
                        Data = result
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = "FAILURE",
                    StatusText = ex.Message
                });
                //    LoggerManager.LoggingErrorTrack(ex, "APIGateWay", "Accounts/ListAllAccountsByResourceId");
            }
            return Ok(new
            {
                StatusCode = "FAILURE",
                StatusText = errorMessage
            });
        }

        [HttpPost("AddOrUodateOrders")]
        public IActionResult AddOrUodateOrders(OrderDetailView orderDetail)
        {
            try
            {
                
                int orderId = orderManagementService.AddOrUodateOrders(orderDetail).Result;
                if (orderId != 0)
                {
                    return Ok(new
                    {
                        StatusCode = "SUCCESS",
                        Data = orderId
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = "FAILURE",
                    StatusText = ex.Message
                });
                //    LoggerManager.LoggingErrorTrack(ex, "APIGateWay", "Accounts/ListAllAccountsByResourceId");
            }
            return Ok(new
            {
                StatusCode = "FAILURE",
                StatusText = errorMessage
            });
        }
    }
}
