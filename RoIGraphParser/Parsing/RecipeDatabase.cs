using System.Collections.Generic;

namespace RoIGraphParser.Parsing {
	public class RecipeDatabase {
		public Dictionary<string, Product> Products { get; } = new Dictionary<string, Product>();

		public Dictionary<string, Building> Buildings { get; } = new Dictionary<string, Building>();

		public Product GetProductByName(string name) => Products[name];
		
		public Product AddOrGetProduct(string name) {
			if (Products.TryGetValue(name, out var p))
				return p;

			p = new Product {
				Name = name
			};
			
			Products.Add(name, p);
			return p;
		}

		public Building AddOrGetBuilding(Building building) {
			if (Buildings.TryGetValue(building.BuildingName, out var b))
				return b;

			Buildings.Add(building.BuildingName, building);
			return building;
		}
	}
}