using System;
using System.Collections.Generic;

namespace NetBank.Api.Models
{

   public class IssuingNetworkData
   {
      public string IssuingNetworkName { get; set; }
      public List<int> StartsWithNumbers { get; set; }
      public RangeNumber InRange {get; set;}
   }
}