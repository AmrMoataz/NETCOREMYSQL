using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NETCORE.MYSQL.Data.Models;
using NETCORE.MYSQL.Data.UnitOfWork;

namespace NETCORE.MYSQL.Controllers
{
	[DisableCors]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		// GET: api/<ProductsController>
		[HttpGet]
		public IActionResult Get()
		{
			var products = _unitOfWork.Products.GetAll();
			return Ok(products.ToList());
		}

		// GET api/<ProductsController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var product = _unitOfWork.Products.Get(id);
			return Ok(product);
		}

		// POST api/<ProductsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<ProductsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ProductsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
