﻿using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.IServices
{
	public interface IProductService
	{
		Task<IEnumerable<ProductModel>> FindAllProducts();
		Task<ProductModel> FindById(long id);
		Task<ProductModel> Create(ProductModel model);
		Task<ProductModel> Update(ProductModel model);
		Task<bool> Delete(long id);
	}
}
