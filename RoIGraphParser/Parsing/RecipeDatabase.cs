using System.Collections.Generic;

namespace RoIGraphParser.Parsing {
	public class RecipeDatabase {
		public Dictionary<string, Product> Products { get; } = new Dictionary<string, Product>();

		public Product GetByName(string name) => Products[name];
		
		public Product AddOrGetProduct(string name) {
			if (Products.TryGetValue(name, out var p))
				return p;

			p = new Product {
				Name = name
			};
			
			Products.Add(name, p);
			return p;
		}
	}
}