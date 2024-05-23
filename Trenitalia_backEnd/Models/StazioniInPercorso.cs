using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trenitalia_backEnd.Models
{
	public class StazioniInPercorso
	{
		[Key]
		public int IdStazioniInPercorso { get; set; }

		[ForeignKey("Stazioni")]
		public int IdStazione { get; set; }

		[ForeignKey("Percorsi")]
		public int IdPercorso { get; set; }

		public virtual Stazioni Stazione { get; set; }
		public virtual Percorsi Percorso { get; set; }
	}

}
