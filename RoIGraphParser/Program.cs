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
			
			TimeCalculations.CalcTimeToMarket(db);
			
			Console.WriteLine("Done!");
		}
	}
}