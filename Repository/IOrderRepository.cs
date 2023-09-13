using WebApplicationAngularWebPortal.DataTransferObjects;
using WebApplicationAngularWebPortal.Models;

namespace WebApplicationAngularWebPortal.Repository;

public interface IOrderRepository
{
	List<OrderDto> GetOrders();
	Order CreateOrder();
	List<Product> GetProducts(int orderId, int customerId, int status);
}