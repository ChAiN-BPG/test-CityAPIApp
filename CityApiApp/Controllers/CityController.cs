using CityApiApp.Models;
using CityApiApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

namespace CityApiApp.Controllers {
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase {
        [HttpGet()]
        public IEnumerable<CityDataResponseModel> Get([FromQuery(Name = "CityName")] string pCityName = "") {
            List<CityDataModel> CityData = CityDataService.data;
            if (!string.IsNullOrEmpty(pCityName))
                CityData = CityData.Where(item => Regex.IsMatch(item.name, $@"^{Regex.Escape(pCityName)}", RegexOptions.IgnoreCase)).ToList();
            CityData = CityData.AsEnumerable().OrderBy(item => item.name).ToList();
            return CityData
                .Take(10)
                .Select(item => new CityDataResponseModel {
                    CityName = item.name,
                    Country = item.country,
                    population = item.stat.population
                });

        }
    }
}
