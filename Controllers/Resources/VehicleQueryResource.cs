namespace kartzmax.Controllers.Resources
{
    public class VehicleQueryResource
    {

        public int? MakeId { get; set; }


        public int? ModelId { get; set; }
        public int? SortBy { get; set; }

        public bool IsSortAscending { get; set; }

          public int Page { get; set; }
        public byte PageSize { get; set; }

    }
}