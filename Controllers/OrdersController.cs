using Microsoft.AspNetCore.Mvc;
using WebApplicationAngularWebPortal.Models;
using WebApplicationAngularWebPortal.Repository;

namespace WebApplicationAngularWebPortal.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderRepository _repository;

		public OrdersController(IOrderRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("GetOrders")]
		public ActionResult<List<Order>> GetOrders()
		{
			return Ok(_repository.GetOrders());
		}

		[HttpPost("CreateOrder")]
		public ActionResult<Order> CreateOrder()
		{
			var newOrder = _repository.CreateOrder();
			return CreatedAtAction(nameof(GetOrders), new {id = newOrder.ID}, newOrder);
		}

		[HttpGet("GetProducts")]
		public ActionResult<List<Product>> GetProducts(int orderId, int customerId, int status)
		{
			var products = _repository.GetProducts(orderId, customerId, status);
			if (products is null || products.Count == 0)
			{
				return NotFound();
			}

			return Ok(products);
		}
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = Random.Shared.Next(-20, 55),
					Summary = Summaries[Random.Shared.Next(Summaries.Length)]
				})
				.ToArray();
		}
	}
}