using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace RoIGraphParser.Parsing {
	public static class GraphParser {
		public static RecipeDatabase Parse(bool writeToFile) {
			var serializerSettings = new JsonSerializerSettings {
				Formatting = Formatting.Indented
			};
			var deserializerSettings = new JsonSerializerSettings {
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			
			Console.WriteLine("Parsing Json ...");
			dynamic data = JsonConvert.DeserializeObject(File.ReadAllText("recipeGraph.json"), deserializerSettings);

			var db = new RecipeDatabase();
			foreach (var node in data) {
				try {
					var origin = node.originatingFrom[0];

					foreach (var result in origin.result) {
						Product product = db.AddOrGetProduct(result.definition.name.ToString());
    
						foreach (var ingredient in origin.ingredients) {
							string name = ingredient.definition.name.ToString();
	                        
							if (product.Ingredients.Any(i => i.Name == name))
								continue;
	                        
							product.Ingredients.Add(new Ingredient {
								Name = name,
								Count = ingredient.amount
							});
						}

						product.Count = result.amount;
						product.Time = origin._gameDaysEasyChains;
						product.BuildingName = node.originBuildings[0].buildingPanelName;
					}
				} catch (Exception e) {
					Console.WriteLine(e);
				}
			}

			foreach (var product in db.Products.Values) {
				foreach (var ingredient in product.Ingredients) {
					var ip = db.GetByName(ingredient.Name);

					if (ip == null) {
						Console.WriteLine($"Could not find ingredient product: {ingredient}");
						continue;
					}

					ingredient.Product = ip;
				}
			}
			
			if (writeToFile)
				File.WriteAllText("parsedGraph.json", JsonConvert.SerializeObject(db, serializerSettings));

			return db;
		}
	}
}