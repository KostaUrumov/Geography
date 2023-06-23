using GeographyCore.ViewModels.ContinentModels;
using GeorgaphyStracture.Data;

namespace GeographyCore.Services
{
    public class ContinentService
    {
        private readonly GeographyDb data;
        public ContinentService(GeographyDb _data)
        {
            data = _data;
        }
        public List<HomePageContinentViewModel> getAllContinents()
        {
            List<HomePageContinentViewModel> listedContinents = data
                .Continents
                .Select(x => new HomePageContinentViewModel
                {
                    Name = x.Name,
                    PctureUrl = x.PctureUrl
                })
                .ToList();

            return listedContinents;
        }
    }
}
