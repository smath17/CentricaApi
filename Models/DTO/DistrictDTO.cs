namespace CentricaApi.Models.DTO
{
    public class DistrictDTO
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required List<SalespersonDTO> SalespersonDTOs { get; set; }

        public required List<StoreDTO> StoreDTOs { get; set; }
    }
}
