using System.ComponentModel.DataAnnotations;

namespace Trenitalia_backEnd.Models
{
	public class Stazioni
	{
		[Key]
		public int IdStazione { get; set; }

		[Required]
		public string NomeStazione { get; set; }

		[Required]
		public string Citta { get; set; }

		[Required]
		public string Regione { get; set; }

		public virtual ICollection<StazioniInPercorso> StazioniInPercorso { get; set; }

	}
}
