using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoIGraphParser.Helpers;
using RoIGraphParser.Parsing;

namespace RoIGraphParser.Calculation {
	public class ProductionChain {
		private const int HarvesterPerBuilding = 3;
		private static readonly List<string> HarvesterBuildings = new List<string> {
			"SAND COLLECTOR", "WATER SIPHON", "COAL MINE", "COPPER MINE", "GAS PUMP",
			"IRON MINE", "LUMBERYARD", "OIL DRILL", "WATER WELL", "FISHERMAN PIER"
		};
		
		public List<ProductionChainResource> ProductionChainResources { get; set; } = new List<ProductionChainResource>();

		public void AddOrUpdate(Building building, double count, double buildingCount) {
			var item = ProductionChainResources.Find(i => i.Building == building);

			if (item == null) {
				ProductionChainResources.Add(new ProductionChainResource {
					Building = building,
					BuildingCount = buildingCount,
					MonthlyProduction = count
				});
			} else {
				item.MonthlyProduction += count;
				item.BuildingCount += buildingCount;
			}
		}

		public void PostProcess() {
			var additionalHarvesters = new List<ProductionChainResource>();
			
			foreach (var resource in ProductionChainResources) {
				if (HarvesterBuildings.Contains(resource.Building.BuildingName))
					additionalHarvesters.Add(HarvesterForResource(resource));
			}

			ProductionChainResources.AddRange(additionalHarvesters);
		}

		private static ProductionChainResource HarvesterForResource(ProductionChainResource resource) {
			var building = resource.Building;
			var harvesterCount = resource.BuildingCount;
			var resourceCount = resource.MonthlyProduction;
					
			resource.BuildingCount = Math.Ceiling(harvesterCount / HarvesterPerBuilding);
			resource.MonthlyProduction = 0;

			return new ProductionChainResource {
				MonthlyProduction = resourceCount,
				BuildingCount = harvesterCount,
				Building = new Building {
					BuildingName = building.BuildingName + " - Harvester",
					BaseCost = building.BaseCost - 50000
				}
			};
		}

		public override string ToString() {
			var s = ProductionChainResources.Aggregate(new StringBuilder(),
				(sb, r) => sb.AppendLine(r.ObjectToString())).ToString();
			
			s += "Total Cost: " + ProductionChainResources.Sum(r => r.TotalCost) + Environment.NewLine;
			s += "Total Upkeep: " + ProductionChainResources.Sum(r => r.TotalUpkeep);

			return s;
		}
	}
}