using System.Text.Json.Serialization;

namespace Autobarn.Data.Entities;

public class VehicleMake
{

		public string Code { get; set; } = "";

		public string Name { get; set; } = "";

		[JsonIgnore]
		public virtual ICollection<VehicleModel> Models { get; set; } = new HashSet<VehicleModel>();
}
