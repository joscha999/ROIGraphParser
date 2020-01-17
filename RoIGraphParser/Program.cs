using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RoIGraphParser.Calculation;
using RoIGraphParser.Parsing;

namespace RoIGraphParser {
	public static class Program {
		public static void Main(string[] args) {
			var db = GraphParser.Parse(true);
			
			//TimeCalculations.CalcTimeToMarket(db);

			var p = db.Products["Doll"];
			var result = BuildingCalculations.CalcNeededBuildings(p, 8);

			foreach (var kvp in result.Buildings) {
				Console.WriteLine();
				Console.Write(kvp.Key);
				Console.WriteLine($"Needed {kvp.Value} times");
			}
			
			Console.WriteLine("Done!");
		}
	}
}