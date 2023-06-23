namespace GeographyCore.ViewModels.CountryModels
{
    public class ShowCountriesModel
    {
        public string Name { get; set; } = null!;

        public string Flag { get; set; } = null!;

        public int Population { get; set; }

        public double Area { get; set; }

        public string Continent { get; set; } = null!;

        public string GoogleMapsUrl { get; set; } = null!;

    }
}
