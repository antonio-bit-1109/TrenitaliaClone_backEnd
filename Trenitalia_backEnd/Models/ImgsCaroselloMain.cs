using System.ComponentModel.DataAnnotations;

namespace Trenitalia_backEnd.Models
{
	public class ImgsCaroselloMain
	{

		[Key]
		public int IdImgs { get; set; }

		[Required]
		public string Image { get; set; }

		[Required]
		public string Title { get; set; }
	}
}
