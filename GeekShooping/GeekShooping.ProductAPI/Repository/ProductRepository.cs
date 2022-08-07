using AutoMapper;
using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Model;
using GeekShooping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly SqlServerContext _context;
		private IMapper _mapper;

		public ProductRepository(SqlServerContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductVO>> FindAll()
		{
			List<Product> products = await _context.Products.ToListAsync();
			return _mapper.Map<IEnumerable<ProductVO>>(products);
		}

		public async Task<ProductVO> FindById(long id)
		{
			Product product = await _context.Products
				.Where(p => p.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ProductVO>(product);
		}

		public async Task<ProductVO> Create(ProductVO vo)
		{
			Product product = _mapper.Map<Product>(vo);
			await _context.AddAsync(product);
			await _context.SaveChangesAsync();

			return _mapper.Map<ProductVO>(product);
		}

		public async Task<ProductVO> Update(ProductVO vo)
		{
			Product product = _mapper.Map<Product>(vo);
			_context.Update(product);
			await _context.SaveChangesAsync();

			return _mapper.Map<ProductVO>(product);
		}

		public async Task<bool> Delete(long id)
		{
			try
			{
				Product product = await _context.Products
					.Where(p => p.Id == id).FirstOrDefaultAsync();

				if (product == null) return false;

				_context.Remove(product);
				await _context.SaveChangesAsync();

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
