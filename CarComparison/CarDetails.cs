namespace CarComparisonApp
{
    internal class CarDetails
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal TCCRating { get; set; }
        public decimal HwyMPG { get; set; }

        public string PriceFormatted => Price.ToString("C");
        public decimal FuelByDistance(decimal distance) => distance / HwyMPG;
    }
}
