namespace Trenitalia_backEnd.DTO
{
	public class PostUtenteDTO
	{

		public string cellulare { get; set; }
		public string codiceFiscale { get; set; }
		public string cognome { get; set; }
		public string dataNascita { get; set; }
		public string email { get; set; }
		public string nome { get; set; }
		public string sesso { get; set; }

		public bool aderisciCartaFreccia { get; set; }
		public bool aderisciXGo { get; set; }
		public bool giveConsenso1 { get; set; }
		public bool giveConsenso2 { get; set; }
		public bool giveConsenso3 { get; set; }
		public bool mancanzaCodiceFiscale { get; set; }




	}
}
