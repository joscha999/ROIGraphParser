using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RoIGraphParser.Parsing;

namespace RoIGraphParser {
	public static class Program {
		public static void Main(string[] args) {
			var db = GraphParser.Parse(true);
			
			CalcTimeToMarket(db);
			
			Console.WriteLine("Done!");
		}

		private static void CalcTimeToMarket(RecipeDatabase db) {
			var product = db.GetByName("Doll");
			const double avgDist = (190d / 13d);
			
			var finalTime = (avgDist / 20) * product.Count + (product.Count - 1) * 0.5;
			
			var ttm = CalcProductionTime(product) + CalcTransportTime(product, avgDist) + finalTime;
			Console.WriteLine($"Time to market for {product.Name}: {ttm} days.");
		}
		
		private static void CalcOneProdTime(RecipeDatabase db) {
			const string productName = "Car";
			Console.WriteLine($"Production time of {productName}: {CalcProductionTime(db.GetByName(productName))}");
		}
		
		private static void CalcAllProdTimes(RecipeDatabase db) {
			Console.WriteLine(db.Products.Values
				.Select(p => (CalcProductionTime(p), p.Name))
				.OrderBy(a => a.Item1)
				.Select(a => $"Product: {a.Name}, Time: {a.Item1}")
				.Aggregate(new StringBuilder(), (sb, a) => sb.AppendLine(a))
			);
		}

		private static double CalcTransportTime(Product p, double avgDistance) {
			if (p.Ingredients.Count == 0)
				return 0;

			double longestTransportTime = 0;
			foreach (var ingredient in p.Ingredients) {
				var time = (ingredient.Count - 1) * 0.5;
				time += ingredient.Count * (avgDistance / 20);
				time += CalcTransportTime(ingredient.Product, avgDistance);

				if (longestTransportTime < time)
					longestTransportTime = time;
			}

			return longestTransportTime;
		}
		
		private static int CalcProductionTime(Product p) {
			if (p.Ingredients.Count == 0)
				return p.Time;

			if (p.Ingredients.Count == 1)
				return p.Time + CalcProductionTime(p.Ingredients[0].Product);

			var longestTime = 0;
			foreach (var ingredient in p.Ingredients) {
				var time = CalcProductionTime(ingredient.Product);
				if (time > longestTime)
					longestTime = time;
			}

			return longestTime + p.Time;
		}

		private static string CalNeededBuildings(Product p, int amount) {
			//calc needed buildings to produce amount products per month
			
			//1. calc "myself" (building and time for p)
			//1.1 normal => #buildings
			//1.2 collector building => #buildings AND #collectors
			
			//2. foreach resource for p CalcNeededBuildings(resource, needed)

			return "";
		}
	}
}