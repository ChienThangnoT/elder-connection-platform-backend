namespace Infracstructures.Mappers
{
	public class SaleViewModel
	{
		public int SaleId { get; set; }

		public string? SaleName { get; set; }
		public string? ImageURL { get; set; }

		public string? SaleDescription { get; set; }

		public float SalePercent { get; set; }
	}
}