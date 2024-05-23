﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trenitalia_backEnd.data;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240523171056_db_Creation")]
    partial class db_Creation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trenitalia_backEnd.Models.Passeggeri", b =>
                {
                    b.Property<int>("IdPasseggero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPasseggero"));

                    b.Property<string>("Cellulare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodiceFiscale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sesso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPasseggero");

                    b.ToTable("Passeggeri");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Percorsi", b =>
                {
                    b.Property<int>("IdPercorso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPercorso"));

                    b.Property<int>("IdStazioneArrivo")
                        .HasColumnType("int");

                    b.Property<int>("IdStazionePartenza")
                        .HasColumnType("int");

                    b.Property<DateTime>("OraArrivo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OraPartenza")
                        .HasColumnType("datetime2");

                    b.Property<int>("StazioneArrivoIdStazione")
                        .HasColumnType("int");

                    b.Property<int>("StazionePartenzaIdStazione")
                        .HasColumnType("int");

                    b.HasKey("IdPercorso");

                    b.HasIndex("StazioneArrivoIdStazione");

                    b.HasIndex("StazionePartenzaIdStazione");

                    b.ToTable("Percorsi");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Prenotazioni", b =>
                {
                    b.Property<int>("IdPrenotazione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrenotazione"));

                    b.Property<DateTime>("DataOraPrenotazione")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPasseggero")
                        .HasColumnType("int");

                    b.Property<int>("IdPercorso")
                        .HasColumnType("int");

                    b.Property<int>("IdTreno")
                        .HasColumnType("int");

                    b.Property<int>("NumPostiPrenotati")
                        .HasColumnType("int");

                    b.Property<int>("PasseggeroIdPasseggero")
                        .HasColumnType("int");

                    b.Property<double>("PrezzoPrenotazione")
                        .HasColumnType("float");

                    b.Property<int>("TrattaDIPercorsoIdPercorso")
                        .HasColumnType("int");

                    b.Property<int>("TrenoPrenotatoIdTreno")
                        .HasColumnType("int");

                    b.HasKey("IdPrenotazione");

                    b.HasIndex("PasseggeroIdPasseggero");

                    b.HasIndex("TrattaDIPercorsoIdPercorso");

                    b.HasIndex("TrenoPrenotatoIdTreno");

                    b.ToTable("Prenotazioni");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Servizi", b =>
                {
                    b.Property<int>("IdServizio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServizio"));

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeServizio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("IdServizio");

                    b.ToTable("Servizi");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.ServiziInTreno", b =>
                {
                    b.Property<int>("IdServizioInTreno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServizioInTreno"));

                    b.Property<int>("IdServizio")
                        .HasColumnType("int");

                    b.Property<int>("IdTreno")
                        .HasColumnType("int");

                    b.HasKey("IdServizioInTreno");

                    b.HasIndex("IdServizio");

                    b.HasIndex("IdTreno");

                    b.ToTable("ServiziInTreno");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Stazioni", b =>
                {
                    b.Property<int>("IdStazione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStazione"));

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeStazione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStazione");

                    b.ToTable("Stazioni");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.StazioniInPercorso", b =>
                {
                    b.Property<int>("IdStazioniInPercorso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStazioniInPercorso"));

                    b.Property<int>("IdPercorso")
                        .HasColumnType("int");

                    b.Property<int>("IdStazione")
                        .HasColumnType("int");

                    b.Property<int>("PercorsoIdPercorso")
                        .HasColumnType("int");

                    b.Property<int>("StazioneIdStazione")
                        .HasColumnType("int");

                    b.HasKey("IdStazioniInPercorso");

                    b.HasIndex("PercorsoIdPercorso");

                    b.HasIndex("StazioneIdStazione");

                    b.ToTable("StazioniInPercorso");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Treni", b =>
                {
                    b.Property<int>("IdTreno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTreno"));

                    b.Property<string>("NomeTreno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostiASedere")
                        .HasColumnType("int");

                    b.Property<int>("PostiInPiedi")
                        .HasColumnType("int");

                    b.Property<int>("PostiTotali")
                        .HasColumnType("int");

                    b.Property<string>("VelocitaMax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postiPrenotati")
                        .HasColumnType("int");

                    b.HasKey("IdTreno");

                    b.ToTable("Treni");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Percorsi", b =>
                {
                    b.HasOne("Trenitalia_backEnd.Models.Stazioni", "StazioneArrivo")
                        .WithMany()
                        .HasForeignKey("StazioneArrivoIdStazione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trenitalia_backEnd.Models.Stazioni", "StazionePartenza")
                        .WithMany()
                        .HasForeignKey("StazionePartenzaIdStazione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StazioneArrivo");

                    b.Navigation("StazionePartenza");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Prenotazioni", b =>
                {
                    b.HasOne("Trenitalia_backEnd.Models.Passeggeri", "Passeggero")
                        .WithMany("Prenotazioni")
                        .HasForeignKey("PasseggeroIdPasseggero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trenitalia_backEnd.Models.Percorsi", "TrattaDIPercorso")
                        .WithMany("Prenotazioni")
                        .HasForeignKey("TrattaDIPercorsoIdPercorso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trenitalia_backEnd.Models.Treni", "TrenoPrenotato")
                        .WithMany("Prenotazioni")
                        .HasForeignKey("TrenoPrenotatoIdTreno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passeggero");

                    b.Navigation("TrattaDIPercorso");

                    b.Navigation("TrenoPrenotato");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.ServiziInTreno", b =>
                {
                    b.HasOne("Trenitalia_backEnd.Models.Servizi", "Servizi")
                        .WithMany("ServiziInTreno")
                        .HasForeignKey("IdServizio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trenitalia_backEnd.Models.Treni", "Treni")
                        .WithMany("ServiziInTreno")
                        .HasForeignKey("IdTreno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servizi");

                    b.Navigation("Treni");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.StazioniInPercorso", b =>
                {
                    b.HasOne("Trenitalia_backEnd.Models.Percorsi", "Percorso")
                        .WithMany("StazioniInPercorso")
                        .HasForeignKey("PercorsoIdPercorso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trenitalia_backEnd.Models.Stazioni", "Stazione")
                        .WithMany("StazioniInPercorso")
                        .HasForeignKey("StazioneIdStazione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Percorso");

                    b.Navigation("Stazione");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Passeggeri", b =>
                {
                    b.Navigation("Prenotazioni");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Percorsi", b =>
                {
                    b.Navigation("Prenotazioni");

                    b.Navigation("StazioniInPercorso");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Servizi", b =>
                {
                    b.Navigation("ServiziInTreno");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Stazioni", b =>
                {
                    b.Navigation("StazioniInPercorso");
                });

            modelBuilder.Entity("Trenitalia_backEnd.Models.Treni", b =>
                {
                    b.Navigation("Prenotazioni");

                    b.Navigation("ServiziInTreno");
                });
#pragma warning restore 612, 618
        }
    }
}