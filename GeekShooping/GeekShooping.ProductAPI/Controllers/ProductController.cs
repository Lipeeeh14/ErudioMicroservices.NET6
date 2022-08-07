using GeekShooping.ProductAPI.Data.ValueObjects;
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

		[HttpPost]
		public async Task<IActionResult> Create(ProductVO productVO)
		{
			if (productVO == null) return BadRequest();
			var product = await _productRepository.Create(productVO);

			return Ok(product);
		}

		[HttpPut]
		public async Task<IActionResult> Update(ProductVO productVO)
		{
			if (productVO == null) return BadRequest();
			var product = await _productRepository.Update(productVO);

			return Ok(product);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(long id)
		{
			var status = await _productRepository.Delete(id);

			if (!status) return BadRequest();

			return Ok(status);
		}
	}
}
