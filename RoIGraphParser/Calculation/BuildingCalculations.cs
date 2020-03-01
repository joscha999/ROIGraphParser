using System;
using System.Text;
using RoIGraphParser.Parsing;

namespace RoIGraphParser.Calculation {
	public static class BuildingCalculations {
		public static ProductionChain CalcNeededBuildings(Product p, double amount, ProductionChain chain = null) {
			//calc needed buildings to produce amount products per month
			if (chain == null)
				chain = new ProductionChain();
			
			//1. calc "myself" (building and time for p)
			//count per cycle / (cycle time / 30)
			var resourcePerMonth = p.Count / (p.Time / 30d);
			var buildingsNeeded = amount / resourcePerMonth;

			chain.AddOrUpdate(p.Building, resourcePerMonth, buildingsNeeded);

			//2. foreach resource for p CalcNeededBuildings(resource, needed)
			foreach (var ingredient in p.Ingredients) {
				CalcNeededBuildings(ingredient.Product, (ingredient.Count / (double)p.Count) * amount, chain);
			}

			return chain;
		}
	}
}