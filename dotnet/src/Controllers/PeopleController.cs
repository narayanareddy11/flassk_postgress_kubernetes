using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TitanicAPI.Models;

namespace TitanicAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PeopleController : ControllerBase
	{
		private readonly ILogger _logger;

		public PeopleController(ILogger<PeopleController> logger)
		{
			_logger = logger;
		}

		// GET /people
		[HttpGet]
		[Produces(typeof(Person))]
		public ActionResult Get()
		{
			var db = new PeopleDb();

			_logger.LogDebug("Returning all items - GET /people");
			return Ok(db.People);
		}


		// POST /people
		[HttpPost]
		public ActionResult Post([FromBody] Person toPost)
		{
			using (var db = new PeopleDb())
			{
				db.People.Add(toPost);
				db.SaveChanges();
			}

			_logger.LogDebug("Post one item - POST /people");
			return Ok(toPost);
		}

		// GET /people/uuid
		[HttpGet("{uuid}")]
		public ActionResult Get(string uuid)
		{
			Person toReturn = null;
			using (var db = new PeopleDb())
			{
				if (db.People.Count(t => t.Uuid == uuid) == 0)
				{
					_logger.LogDebug("Item for {UUID} not found - GET /people/uuid", uuid);
					return NotFound();
				}

				toReturn = db.People.First(t => t.Uuid == uuid);
				_logger.LogDebug("Returning one item - GET /people/uuid");
				return Ok(toReturn);
			}
		}


		// DELETE /people/uuid
		[HttpDelete("{uuid}")]
		public ActionResult Delete(string uuid)
		{
			using (var db = new PeopleDb())
			{
				if (db.People.Count(t => t.Uuid == uuid) == 0)
				{
					_logger.LogDebug("Item for {UUID} not found - DELETE /people/uuid", uuid);
					return NotFound();
				}

				db.People.Remove(db.People.First(t => t.Uuid == uuid));
				db.SaveChanges();
				_logger.LogDebug("Deleted one item - DELETE /people/uuid");
				return Ok();
			}
		}


		// PUT /people/uuid
		[HttpPut("{uuid}")]
		public ActionResult Put(string uuid, [FromBody] Person toUpdate)
		{
			toUpdate.Uuid = uuid; // Attach ID to Person Object.

			using (var db = new PeopleDb())
			{
				if (db.People.Count(t => t.Uuid == uuid) == 0)
				{
					_logger.LogDebug("Item for {UUID} not found - PUT /people/uuid", uuid);
					return NotFound();
				}

				db.People.Update(toUpdate);
				db.SaveChanges();
				_logger.LogDebug("Returning one item - PUT /people/uuid");
				return Ok(toUpdate);
			}
		}
	}
}