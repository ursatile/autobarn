using System.Text.Json.Serialization;

namespace Autobarn.Data.Entities;

public class VehicleModel
{

		public string Code { get; set; } = "";

		public VehicleMake VehicleMake { get; set; } = null!;

		public string MakeCode { get; set; } = "";

		public string Name { get; set; } = "";

		[JsonIgnore]
		public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
