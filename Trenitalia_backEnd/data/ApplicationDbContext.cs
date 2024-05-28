using Microsoft.EntityFrameworkCore;
using Trenitalia_backEnd.Models;

namespace Trenitalia_backEnd.data
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Passeggeri> Passeggeri { get; set; }
		public DbSet<Percorsi> Percorsi { get; set; }
		public DbSet<Prenotazioni> Prenotazioni { get; set; }
		public DbSet<Servizi> Servizi { get; set; }
		public DbSet<ServiziInTreno> ServiziInTreno { get; set; }
		public DbSet<Stazioni> Stazioni { get; set; }
		public DbSet<StazioniInPercorso> StazioniInPercorso { get; set; }
		public DbSet<Treni> Treni { get; set; }

		public DbSet<News> News { get; set; }

		public DbSet<ImgsCaroselloMain> ImgsCaroselloMain { get; set; }
	}
}
