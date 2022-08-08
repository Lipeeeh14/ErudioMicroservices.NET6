using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;
using GeekShooping.Web.Utils;

namespace GeekShooping.Web.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _client;
		public const string BasePath = "api/v1/product";

		public ProductService(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}

		public async Task<IEnumerable<ProductModel>> FindAllProducts()
		{
			var response = await _client.GetAsync(BasePath);
			return await response.ReadContentAs<List<ProductModel>>();
		}

		public async Task<ProductModel> FindById(long id)
		{
			var response = await _client.GetAsync($"{BasePath}/{id}");
			return await response.ReadContentAs<ProductModel>();
		}

		public async Task<ProductModel> Create(ProductModel model)
		{
			var response = await _client.PostAsJson(BasePath, model);

			if (!response.IsSuccessStatusCode)
				throw new Exception("Something went wrong calling API");

			return await response.ReadContentAs<ProductModel>();
		}

		public async Task<ProductModel> Update(ProductModel model)
		{
			var response = await _client.PutAsJson(BasePath, model);

			if (!response.IsSuccessStatusCode)
				throw new Exception("Something went wrong calling API");

			return await response.ReadContentAs<ProductModel>();
		}

		public async Task<bool> Delete(long id)
		{
			var response = await _client.DeleteAsync($"{BasePath}/{id}");

			if (!response.IsSuccessStatusCode)
				throw new Exception("Something went wrong calling API");

			return await response.ReadContentAs<bool>();
		}
	}
}
