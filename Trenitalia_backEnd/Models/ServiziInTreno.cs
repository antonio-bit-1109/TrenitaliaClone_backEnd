using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trenitalia_backEnd.Models
{
	public class ServiziInTreno
	{
		[Key]
		public int IdServizioInTreno { get; set; }

		[ForeignKey("Servizi")]
		public int IdServizio { get; set; }

		[ForeignKey("Treni")]
		public int IdTreno { get; set; }

		public virtual Servizi Servizi { get; set; }
		public virtual Treni Treni { get; set; }
	}
}
