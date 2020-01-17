using System.Collections.Generic;

namespace RoIGraphParser.Parsing {
	public class Product {
		public string Name { get; set; }

		public int Count { get; set; }

		public int Time { get; set; }
		
		public List<Ingredient> Ingredients { get; } = new List<Ingredient>();

		public Building Building { get; set; }
	}
}