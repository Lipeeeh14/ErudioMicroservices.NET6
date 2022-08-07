using GeekShooping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
		}

		[HttpGet]
		public async Task<IActionResult> FindAll()
		{
			var products = await _productRepository.FindAll();

			return Ok(products);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> FindById(long id) 
		{
			var product = await _productRepository.FindById(id);

			if (product == null) return NotFound();

			return Ok(product);
		}


	}
}
