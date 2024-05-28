using System.ComponentModel.DataAnnotations;

namespace Trenitalia_backEnd.Models
{
	public class News
	{
		[Key]
		public int IdNews { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Image { get; set; }
	}
}
