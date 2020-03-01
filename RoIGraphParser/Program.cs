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

			var p = db.Products["Wooden Train"];
			var result = BuildingCalculations.CalcNeededBuildings(p, 12);

			foreach (var pcr in result.ProductionChainResources) {
				Console.WriteLine();
				Console.WriteLine(pcr);
			}
			
			Console.WriteLine("Done!");
		}
	}
}