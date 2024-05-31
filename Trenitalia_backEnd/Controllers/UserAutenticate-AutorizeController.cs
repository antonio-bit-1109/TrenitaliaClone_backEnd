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
			if (ModelState.IsValid)
			{

				var Passeggero = new Passeggeri
				{
					Nome = datiUtente.nome,
					Cognome = datiUtente.cognome,
					CodiceFiscale = datiUtente.codiceFiscale,
					Email = datiUtente.email,
					DataNascita = Convert.ToDateTime(datiUtente.dataNascita),
					Sesso = datiUtente.sesso,
					Cellulare = datiUtente.cellulare
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
			var utente = await _db.Passeggeri.FirstOrDefaultAsync(x => x.NomeUtente == userDataLogin.nomeUtente && x.Password == userDataLogin.password);

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
					Ruolo = utente.Ruolo
				};
			}

		}

		private string BuildToken(Passeggeri user)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Jti, Convert.ToString( user.IdPasseggero)),
				new Claim(JwtRegisteredClaimNames.Name, user.Nome),
				new Claim(ClaimTypes.Role, user.Ruolo),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),

			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
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
