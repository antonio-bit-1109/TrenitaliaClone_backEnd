using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trenitalia_backEnd.Models
{
	public class Prenotazioni
	{
		[Key]
		public int IdPrenotazione { get; set; }

		[Required]
		public DateTime DataOraPrenotazione { get; set; }

		[Required]
		public int NumPostiPrenotati { get; set; }

		[Required]
		public double PrezzoPrenotazione { get; set; }

		[ForeignKey("Passeggeri")]
		public int IdPasseggero { get; set; }

		[ForeignKey("Treni")]
		public int IdTreno { get; set; }

		[ForeignKey("Percorsi")]
		public int IdPercorso { get; set; }

		public virtual Passeggeri Passeggero { get; set; }
		public virtual Treni TrenoPrenotato { get; set; }
		public virtual Percorsi TrattaDIPercorso { get; set; }
	}
}
