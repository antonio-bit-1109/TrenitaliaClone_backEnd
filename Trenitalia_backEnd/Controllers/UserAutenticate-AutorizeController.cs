using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trenitalia_backEnd.data;
using Trenitalia_backEnd.DTO;
using Trenitalia_backEnd.Models;

namespace Trenitalia_backEnd.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UserAutenticate_AutorizeController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		private readonly EmailSender _emailSender;
		private readonly IConfiguration _configuration;

		public UserAutenticate_AutorizeController(ApplicationDbContext db, EmailSender emailSender, IConfiguration configuration)
		{
			_db = db;
			_emailSender = emailSender;
			_configuration = configuration;
		}

		[HttpPost("PostDatiRegistrazione")]
		public async Task<IActionResult> postUtente(PostUtenteDTO datiUtente)
		{
			if (datiUtente.codiceFiscale != null && datiUtente.mancanzaCodiceFiscale == true)
			{
				return BadRequest();
			}

			if (ModelState.IsValid)
			{

				var Passeggero = new Passeggeri
				{
					Nome = (datiUtente.nome).ToLower(),
					Cognome = datiUtente.cognome.ToLower(),
					CodiceFiscale = datiUtente.codiceFiscale.ToLower(),
					Email = datiUtente.email.ToLower(),
					DataNascita = Convert.ToDateTime(datiUtente.dataNascita),
					Sesso = datiUtente.sesso.ToLower(),
					Cellulare = datiUtente.cellulare.ToLower(),
					AderisciCartaFreccia = datiUtente.aderisciCartaFreccia,
					AderisciXGo = datiUtente.aderisciXGo,
					GiveConsenso1 = datiUtente.giveConsenso1,
					GiveConsenso2 = datiUtente.giveConsenso2,
					GiveConsenso3 = datiUtente.giveConsenso3,
					NomeUtente = $"{datiUtente.nome.ToLower()}-{datiUtente.cognome.ToLower()}{new Random().Next(10, 10000)}",
					Password = $"{new Random().Next(100000, 200000)}",
				};

				var UtenteEsistente = await _db.Passeggeri.FirstOrDefaultAsync(x => x.CodiceFiscale == datiUtente.codiceFiscale && (x.DataNascita) == Convert.ToDateTime(datiUtente.dataNascita));

				if (UtenteEsistente != null)
				{
					return BadRequest(new { message = "utente già registrato." });
				}

				if (Passeggero == null)
				{
					return NotFound();
				}

				await _db.Passeggeri.AddAsync(Passeggero);
				await _db.SaveChangesAsync();

				string htmlMessage = $"<h1> Benvenuto nel portale Trenitalia. </h1> <br>" +
					$" I Tuoi Dati: <br>" +
					$" NOME : {Passeggero.Nome} <br>" +
					$" COGNOME : {Passeggero.Cognome} <br>" +
					$" CF : {Passeggero.CodiceFiscale} <br>" +
					$" EMAIL : {Passeggero.Email} <br>" +
					$" DATA NASCITA : {Passeggero.DataNascita} <br>" +
					$" ADERISCI CARTA FRECCIA : {(Passeggero.AderisciCartaFreccia == true ? "SI" : "NO")} <br>" +
					$" ADERISCI XGO : {(Passeggero.AderisciXGo == true ? "SI" : "NO")} <br>" +
					$"------------------------------------------------------- <br>" +
					$"------------------------------------------------------- <br>" +
					$" CREDENZIALI PER L'ACCESSO : <br>" +
					$" NOME UTENTE : {Passeggero.NomeUtente} <br>" +
					$"PASSWORD : {Passeggero.Password}";

				await _emailSender.SendEmailAsync(Passeggero.Email, "Dati Accesso Portale Trenitalia", htmlMessage);
				return Ok(Passeggero);
			}
			return BadRequest();
		}







		[HttpPost("AutenticationUser")]
		public async Task<IActionResult> LoginAutentication(LoginUserDTO userDataLogin)
		{
			var User = await Autenticate(userDataLogin);

			if (User == null)
			{
				return BadRequest(new { message = "Credenziali non valide" });
			}

			var Token = BuildToken(User);

			if (Token == null)
			{
				return BadRequest(new { message = "Errore nella generazione del token" });
			}

			return Ok(new { token = Token });
		}


		private async Task<Passeggeri> Autenticate(LoginUserDTO userDataLogin)
		{
			var utente = await _db.Passeggeri.FirstOrDefaultAsync(x => x.NomeUtente == userDataLogin.nomeUtente.Trim() && x.Password == userDataLogin.password.Trim());

			if (utente == null)
			{
				return null;
			}
			else
			{
				return new Passeggeri
				{
					IdPasseggero = utente.IdPasseggero,
					Nome = utente.Nome,
					Cognome = utente.Cognome,
					CodiceFiscale = utente.CodiceFiscale,
					Email = utente.Email,
					DataNascita = utente.DataNascita,
					Sesso = utente.Sesso,
					Cellulare = utente.Cellulare,
					Password = utente.Password,
					Ruolo = utente.Ruolo,
					NomeUtente = utente.NomeUtente
				};
			}

		}

		private string BuildToken(Passeggeri user)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Jti, Convert.ToString( user.IdPasseggero)),
				new Claim(JwtRegisteredClaimNames.Name, user.Nome),
				new Claim(JwtRegisteredClaimNames.Sub, user.Cognome),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.NomeUtente),
				new Claim(JwtRegisteredClaimNames.Acr, user.Ruolo),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

			if (key == null)
			{
				return null;
			}

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				_configuration["Jwt:Issuer"],
				_configuration["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddDays(7),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);

		}
	}
}
