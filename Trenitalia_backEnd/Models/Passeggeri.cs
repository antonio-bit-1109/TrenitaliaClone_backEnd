using System.ComponentModel.DataAnnotations;

namespace Trenitalia_backEnd.Models
{
	public class Passeggeri
	{

		//public Passeggeri()
		//{

		//}

		[Key]
		public int IdPasseggero { get; set; }

		[Required]
		public string Nome { get; set; }

		[Required]
		public string Cognome { get; set; }

		public string NomeUtente { get; set; }

		public string Password { get; set; }

		[Required]
		public string CodiceFiscale { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public DateTime DataNascita { get; set; }

		[Required]
		public string Sesso { get; set; }

		[Required]
		public string Cellulare { get; set; }

		public string Ruolo { get; set; } = "Utente";

		public bool AderisciCartaFreccia { get; set; }

		public bool AderisciXGo { get; set; }

		public bool GiveConsenso1 { get; set; }
		public bool GiveConsenso2 { get; set; }
		public bool GiveConsenso3 { get; set; }

		public bool MancanzaCodiceFiscale { get; set; }

		public virtual ICollection<Prenotazioni> Prenotazioni { get; set; }
	}
}
