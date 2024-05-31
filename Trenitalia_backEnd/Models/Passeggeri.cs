using System.ComponentModel.DataAnnotations;

namespace Trenitalia_backEnd.Models
{
	public class Passeggeri
	{
		[Key]
		public int IdPasseggero { get; set; }

		[Required]
		public string Nome { get; set; }

		[Required]
		public string Cognome { get; set; }


		public string NomeUtente
		{
			get { return $"{Nome}-{Cognome}{new Random().Next(10, 10000)}"; }
			set { }
		}

		public string Password
		{
			get { return $"{new Random().Next(100000, 200000)}"; }
			set { }
		}

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

		public virtual ICollection<Prenotazioni> Prenotazioni { get; set; }
	}
}
