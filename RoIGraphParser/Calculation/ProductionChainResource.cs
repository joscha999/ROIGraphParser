using System;
using System.Collections.Generic;
using System.Text;
using RoIGraphParser.Helpers;
using RoIGraphParser.Parsing;

namespace RoIGraphParser.Calculation
{
    public class ProductionChainResource
    {
        public Building Building { get; set; }

        public double MonthlyProduction { get; set; }

        public double MonthlyTotalProduction => MonthlyProduction * CeilBuildingCount;
        
        public double BuildingCount { get; set; }

        public double TotalCost => Building.BaseCost * CeilBuildingCount;

        public double TotalUpkeep => Building.Upkeep * CeilBuildingCount;
        
        public override string ToString() => this.ObjectToString();

        private int CeilBuildingCount => (int)Math.Ceiling(BuildingCount);
    }
}
