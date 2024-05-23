using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
	/// <inheritdoc />
	public partial class db_Creation : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Passeggeri",
				columns: table => new
				{
					IdPasseggero = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
					Sesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Cellulare = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Passeggeri", x => x.IdPasseggero);
				});

			migrationBuilder.CreateTable(
				name: "Servizi",
				columns: table => new
				{
					IdServizio = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NomeServizio = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Prezzo = table.Column<double>(type: "float", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Servizi", x => x.IdServizio);
				});

			migrationBuilder.CreateTable(
				name: "Stazioni",
				columns: table => new
				{
					IdStazione = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NomeStazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Regione = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Stazioni", x => x.IdStazione);
				});

			migrationBuilder.CreateTable(
				name: "Treni",
				columns: table => new
				{
					IdTreno = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NomeTreno = table.Column<string>(type: "nvarchar(max)", nullable: false),
					VelocitaMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
					PostiASedere = table.Column<int>(type: "int", nullable: false),
					PostiInPiedi = table.Column<int>(type: "int", nullable: false),
					PostiTotali = table.Column<int>(type: "int", nullable: false),
					postiPrenotati = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Treni", x => x.IdTreno);
				});

			migrationBuilder.CreateTable(
				name: "Percorsi",
				columns: table => new
				{
					IdPercorso = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdStazionePartenza = table.Column<int>(type: "int", nullable: false),
					IdStazioneArrivo = table.Column<int>(type: "int", nullable: false),
					OraPartenza = table.Column<DateTime>(type: "datetime2", nullable: false),
					OraArrivo = table.Column<DateTime>(type: "datetime2", nullable: false),
					StazionePartenzaIdStazione = table.Column<int>(type: "int", nullable: false),
					StazioneArrivoIdStazione = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Percorsi", x => x.IdPercorso);
					table.ForeignKey(
						name: "FK_Percorsi_Stazioni_StazioneArrivoIdStazione",
						column: x => x.StazioneArrivoIdStazione,
						principalTable: "Stazioni",
						principalColumn: "IdStazione",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Percorsi_Stazioni_StazionePartenzaIdStazione",
						column: x => x.StazionePartenzaIdStazione,
						principalTable: "Stazioni",
						principalColumn: "IdStazione",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "ServiziInTreno",
				columns: table => new
				{
					IdServizioInTreno = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdServizio = table.Column<int>(type: "int", nullable: false),
					IdTreno = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ServiziInTreno", x => x.IdServizioInTreno);
					table.ForeignKey(
						name: "FK_ServiziInTreno_Servizi_IdServizio",
						column: x => x.IdServizio,
						principalTable: "Servizi",
						principalColumn: "IdServizio",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ServiziInTreno_Treni_IdTreno",
						column: x => x.IdTreno,
						principalTable: "Treni",
						principalColumn: "IdTreno",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Prenotazioni",
				columns: table => new
				{
					IdPrenotazione = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DataOraPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
					NumPostiPrenotati = table.Column<int>(type: "int", nullable: false),
					PrezzoPrenotazione = table.Column<double>(type: "float", nullable: false),
					IdPasseggero = table.Column<int>(type: "int", nullable: false),
					IdTreno = table.Column<int>(type: "int", nullable: false),
					IdPercorso = table.Column<int>(type: "int", nullable: false),
					PasseggeroIdPasseggero = table.Column<int>(type: "int", nullable: false),
					TrenoPrenotatoIdTreno = table.Column<int>(type: "int", nullable: false),
					TrattaDIPercorsoIdPercorso = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Prenotazioni", x => x.IdPrenotazione);
					table.ForeignKey(
						name: "FK_Prenotazioni_Passeggeri_PasseggeroIdPasseggero",
						column: x => x.PasseggeroIdPasseggero,
						principalTable: "Passeggeri",
						principalColumn: "IdPasseggero",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Prenotazioni_Percorsi_TrattaDIPercorsoIdPercorso",
						column: x => x.TrattaDIPercorsoIdPercorso,
						principalTable: "Percorsi",
						principalColumn: "IdPercorso",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Prenotazioni_Treni_TrenoPrenotatoIdTreno",
						column: x => x.TrenoPrenotatoIdTreno,
						principalTable: "Treni",
						principalColumn: "IdTreno",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "StazioniInPercorso",
				columns: table => new
				{
					IdStazioniInPercorso = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdStazione = table.Column<int>(type: "int", nullable: false),
					IdPercorso = table.Column<int>(type: "int", nullable: false),
					StazioneIdStazione = table.Column<int>(type: "int", nullable: false),
					PercorsoIdPercorso = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StazioniInPercorso", x => x.IdStazioniInPercorso);
					table.ForeignKey(
						name: "FK_StazioniInPercorso_Percorsi_PercorsoIdPercorso",
						column: x => x.PercorsoIdPercorso,
						principalTable: "Percorsi",
						principalColumn: "IdPercorso",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_StazioniInPercorso_Stazioni_StazioneIdStazione",
						column: x => x.StazioneIdStazione,
						principalTable: "Stazioni",
						principalColumn: "IdStazione",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Percorsi_StazioneArrivoIdStazione",
				table: "Percorsi",
				column: "StazioneArrivoIdStazione");

			migrationBuilder.CreateIndex(
				name: "IX_Percorsi_StazionePartenzaIdStazione",
				table: "Percorsi",
				column: "StazionePartenzaIdStazione");

			migrationBuilder.CreateIndex(
				name: "IX_Prenotazioni_PasseggeroIdPasseggero",
				table: "Prenotazioni",
				column: "PasseggeroIdPasseggero");

			migrationBuilder.CreateIndex(
				name: "IX_Prenotazioni_TrattaDIPercorsoIdPercorso",
				table: "Prenotazioni",
				column: "TrattaDIPercorsoIdPercorso");

			migrationBuilder.CreateIndex(
				name: "IX_Prenotazioni_TrenoPrenotatoIdTreno",
				table: "Prenotazioni",
				column: "TrenoPrenotatoIdTreno");

			migrationBuilder.CreateIndex(
				name: "IX_ServiziInTreno_IdServizio",
				table: "ServiziInTreno",
				column: "IdServizio");

			migrationBuilder.CreateIndex(
				name: "IX_ServiziInTreno_IdTreno",
				table: "ServiziInTreno",
				column: "IdTreno");

			migrationBuilder.CreateIndex(
				name: "IX_StazioniInPercorso_PercorsoIdPercorso",
				table: "StazioniInPercorso",
				column: "PercorsoIdPercorso");

			migrationBuilder.CreateIndex(
				name: "IX_StazioniInPercorso_StazioneIdStazione",
				table: "StazioniInPercorso",
				column: "StazioneIdStazione");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Prenotazioni");

			migrationBuilder.DropTable(
				name: "ServiziInTreno");

			migrationBuilder.DropTable(
				name: "StazioniInPercorso");

			migrationBuilder.DropTable(
				name: "Passeggeri");

			migrationBuilder.DropTable(
				name: "Servizi");

			migrationBuilder.DropTable(
				name: "Treni");

			migrationBuilder.DropTable(
				name: "Percorsi");

			migrationBuilder.DropTable(
				name: "Stazioni");
		}
	}
}
