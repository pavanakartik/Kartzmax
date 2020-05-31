using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace kartzmax.Controllers.Resources {
   
   
    public class SaveVehicleResource {

        public int Id { get; set; }
        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ContactResource Contact { get; set; }

        // we are just passing Id's of the feature
        public ICollection<int> Features { get; set; }

        public SaveVehicleResource()
        {
            Features=  new Collection<int>();
        }
    }


}