namespace GeographyCore.ViewModels.CityModels
{
    public class ShowCityModelView
    {
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Population { get; set; }
        public double Area { get; set; }
        public string Landscape { get; set; } = null!;
    }
}
