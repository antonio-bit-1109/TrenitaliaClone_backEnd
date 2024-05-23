using System.ComponentModel.DataAnnotations;

namespace Trenitalia_backEnd.Models
{
	public class Treni
	{
		[Key]
		public int IdTreno { get; set; }

		[Required]
		public string NomeTreno { get; set; }

		[Required]
		public string VelocitaMax { get; set; }

		[Required]
		public int PostiASedere { get; set; }

		[Required]
		public int PostiInPiedi { get; set; }

		public int PostiTotali
		{
			get { return PostiInPiedi + PostiASedere; }
			set { }
		}

		[Required]
		public int postiPrenotati { get; set; }

		public virtual ICollection<ServiziInTreno> ServiziInTreno { get; set; }

		public virtual ICollection<Prenotazioni> Prenotazioni { get; set; }
	}
}
