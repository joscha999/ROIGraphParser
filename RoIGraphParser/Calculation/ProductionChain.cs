using System.Collections.Generic;
using RoIGraphParser.Parsing;

namespace RoIGraphParser.Calculation {
	public class ProductionChain {
		public List<ProductionChainResource> ProductionChainResources { get; set; } = new List<ProductionChainResource>();

		public void AddOrUpdate(Building building, double count, double buildingCount)
		{
			var item = ProductionChainResources.Find(i => i.Building == building);

			if (item == null)
			{
				ProductionChainResources.Add(new ProductionChainResource
				{
					Building = building, 
					BuildingCount = buildingCount,
					Count = count
				});
			}
			else
			{
				item.Count += count;
				item.BuildingCount += buildingCount;
			}
		}
	}
}