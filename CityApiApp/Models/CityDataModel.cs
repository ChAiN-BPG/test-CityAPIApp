namespace CityApiApp.Models {
    public class CityDataModel {
        public double id { get; set; }
        public CoordModel coord { get; set; } = new();
        public string country { get; set; } = string.Empty;
        public GeonameModel geoname { get; set; } = new();
        public List<Dictionary<string, string>> langs { get; set; } = new();
        public string name { get; set; } = string.Empty;
        public StatModel stat { get; set; } = new();
        public List<StationModel> stations { get; set; } = new();
        public double zoom { get; set; }
    }

    public class CoordModel {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class GeonameModel {
        public string cl { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public double parent { get; set; }
    }

    public class StatModel {
        public double level { get; set; }
        public double population { get; set; } = 0;
    }

    public class StationModel {
        public double id { get; set; }
        public double dist { get; set; }
        public double kf { get; set; }
    }
}

