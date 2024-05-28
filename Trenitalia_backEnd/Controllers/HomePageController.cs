using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trenitalia_backEnd.data;

namespace Trenitalia_backEnd.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class HomePageController : ControllerBase
	{

		private readonly ApplicationDbContext _db;

		public HomePageController(ApplicationDbContext db)
		{
			_db = db;
		}

		[HttpGet("getImmagini")]
		public async Task<IActionResult> getImmaginiStore()
		{
			try
			{
				var images = await _db.News.ToListAsync();

				if (images == null)
				{
					return NotFound();
				}


				return Ok(images);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}


		[HttpGet("getDataCarosello")]
		public async Task<IActionResult> GetCaroselloDataMain()
		{
			try
			{
				var dataCarosello = await _db.ImgsCaroselloMain.ToListAsync();
				return Ok(dataCarosello);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
