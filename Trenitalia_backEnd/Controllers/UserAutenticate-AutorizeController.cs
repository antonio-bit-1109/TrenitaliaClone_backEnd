using Microsoft.AspNetCore.Mvc;
using Trenitalia_backEnd.data;

namespace Trenitalia_backEnd.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UserAutenticate_AutorizeController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

		public UserAutenticate_AutorizeController(ApplicationDbContext db)
		{
			_db = db;
		}


	}
}
