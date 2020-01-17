using RoIGraphParser.Parsing;

namespace RoIGraphParser.Calculation {
	public static class BuildingCalculations {
		public static string CalNeededBuildings(Product p, int amount) {
			//calc needed buildings to produce amount products per month
			
			//1. calc "myself" (building and time for p)
			//1.1 normal => #buildings
			//1.2 collector building => #buildings AND #collectors
			
			//2. foreach resource for p CalcNeededBuildings(resource, needed)

			return "";
		}
	}
}