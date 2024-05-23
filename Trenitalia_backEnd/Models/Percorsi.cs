using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trenitalia_backEnd.Models
{
	public class Percorsi
	{
		[Key]
		public int IdPercorso { get; set; }

		[ForeignKey("Stazioni")]
		public int IdStazionePartenza { get; set; }

		[ForeignKey("Stazioni")]
		public int IdStazioneArrivo { get; set; }

		[Required]
		public DateTime OraPartenza { get; set; }

		[Required]
		public DateTime OraArrivo { get; set; }

		public virtual Stazioni StazionePartenza { get; set; }
		public virtual Stazioni StazioneArrivo { get; set; }

		public virtual ICollection<StazioniInPercorso> StazioniInPercorso { get; set; }
		public virtual ICollection<Prenotazioni> Prenotazioni { get; set; }
	}

}
