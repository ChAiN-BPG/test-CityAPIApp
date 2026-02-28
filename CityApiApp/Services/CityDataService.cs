using CityApiApp.Interfaces;
using CityApiApp.Models;
using System.Text.Json;

namespace CityApiApp.Services {
    public class CityDataService : ICityDataService {

        private static List<CityDataModel> _data = new List<CityDataModel>();
        public static List<CityDataModel> data {
            get {
                return _data;
            }
        }
        public async Task Initial(string pPath) {
            try {
                var json = await File.ReadAllTextAsync(pPath);
                _data = JsonSerializer.Deserialize<List<CityDataModel>>(json)!;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
