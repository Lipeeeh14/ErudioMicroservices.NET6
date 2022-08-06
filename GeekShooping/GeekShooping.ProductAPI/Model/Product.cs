using GeekShooping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShooping.ProductAPI.Model
{
	[Table("product")]
	public class Product : BaseEntity
	{
		[Column("name")]
		[Required]
		[StringLength(150)]
		public string Name { get; private set; }

		[Column("price")]
		[Required]
		[Range(1, 10000)]
		public decimal Price { get; private set; }

		[Column("description")]
		[StringLength(500)]
		public string? Description { get; private set; }

		[Column("category_name")]
		[StringLength(50)]
		public string? CategoryName { get; private set; }

		[Column("image_url")]
		[StringLength(300)]
		public string? ImageURL { get; private set; }
	}
}
