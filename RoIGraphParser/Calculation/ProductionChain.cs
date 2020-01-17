using System.Collections.Generic;
using RoIGraphParser.Parsing;

namespace RoIGraphParser.Calculation {
	public class ProductionChain {
		public Dictionary<Building, double> Buildings { get; } = new Dictionary<Building, double>();
	}
}