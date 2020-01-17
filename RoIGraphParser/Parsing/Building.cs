using RoIGraphParser.Helpers;

namespace RoIGraphParser.Parsing {
	public class Building {
		public string BuildingName { get; set; }
		
		public double BaseCost { get; set; }

		public double Upkeep => BaseCost * 0.25;

		public override string ToString() => this.ObjectToString();
	}
}