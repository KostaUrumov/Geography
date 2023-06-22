namespace GeographyCore.ViewModels.SearchModels
{
    public class SearchViewModel
    {
        public List<string>? listed { get; set; } = new List<string>();

        public string Find { get; set; } = null!;

        public int SelectionOfTheList { get; set; }
    }
}
