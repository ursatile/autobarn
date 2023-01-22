using Autobarn.Data;
using Autobarn.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Autobarn.Website.Controllers.Api {
	[Route("api/[controller]")]
	[ApiController]
	public class VehiclesController : ControllerBase {
		private readonly IAutobarnDatabase db;

		public VehiclesController(IAutobarnDatabase db) {
			this.db = db;
		}

		// GET: api/vehicles
		[HttpGet]
		public IEnumerable<Vehicle> Get() => db.ListVehicles();
	}
}
