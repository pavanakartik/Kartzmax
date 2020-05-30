using System.ComponentModel.DataAnnotations.Schema;

namespace kartzmax.Core.Models
{


    [Table("VehicleFeatures")]
    public class VehicleFeature
    {

// combination of vehicle id and feature id will be a composite key
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }

        public Vehicle Vehicle { get; set; }
        
         public Feature Feature { get; set; }
  
  }
}
