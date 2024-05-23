using System.ComponentModel.DataAnnotations;

namespace Trenitalia_backEnd.Models
{
	public class Servizi
	{
		[Key]
		public int IdServizio { get; set; }

		[Required]
		public string NomeServizio { get; set; }

		[Required]
		public string Descrizione { get; set; }

		[Required]
		public double Prezzo { get; set; }

		public virtual ICollection<ServiziInTreno> ServiziInTreno { get; set; }
	}
}
