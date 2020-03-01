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

        public double Count { get; set; }

        public double BuildingCount { get; set; }

        public double TotalCost => Building.BaseCost * Math.Ceiling(BuildingCount);

        public override string ToString() => this.ObjectToString();
    }
}
