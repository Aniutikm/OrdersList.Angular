using Microsoft.EntityFrameworkCore;
using WebApplicationAngularWebPortal.DataTransferObjects;
using WebApplicationAngularWebPortal.Entities;
using WebApplicationAngularWebPortal.Models;

namespace WebApplicationAngularWebPortal.Repository;

public class OrderRepository : IOrderRepository
{
	private readonly AppDbContext _context;

	public OrderRepository(AppDbContext context)
	{
		_context = context;
	}

	public List<OrderDto> GetOrders()
	{
		var orders = _context.Orders.Include(o => o.Customer).ToList();
		var result= orders.Select(ConvertToDto).ToList();
		return result;
	}


	public Order CreateOrder()
	{
		var newOrder = new Order
		{
			CustomerID = 1, // Assuming customer with ID=1 exists
			ProductID = 1, // Assuming product with ID=1 exists
			TotalCost = 1.20m, 
			Status = Status.New
		};

		_context.Orders.Add(newOrder);
		_context.SaveChanges();

		return newOrder;
	}

	public List<Product> GetProducts(int orderId, int customerId, int status)
	{
		return _context.Orders
			.Where(o => o.ID == orderId && o.CustomerID == customerId && (int) o.Status == status)
			.Include(o => o.Product)
			.Select(o => o.Product)
			.ToList();
	}
	
	public OrderDto ConvertToDto(Order order)
	{
		return new OrderDto
		{
			Id = order.ID,
			CustomerId = order.CustomerID,
			CustomerName = order.Customer.CustomerName,
			CustomerAddress = order.Customer.Address,
			StatusName = Enum.GetName(typeof(Status), order.Status),
			TotalCost = order.TotalCost,
			StatusID = (int) order.Status
		};
	}
}