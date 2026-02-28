# CityAPI

A RESTful Web API built with ASP.NET Core (.NET 8) that provides city data including name, country, and population.

---

## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio or VS Code

### Run the API
```bash
git clone https://github.com/your-repo/CityAPI.git
cd CityAPI
dotnet run
```

### Configuration
Set the city data file path in `appsettings.json`:
```json
{
  "AppSettings": {
    "DataPath": "fullpath.json"
  }
}
```

---

## Approach

### Data Loading
City data is loaded once at application startup from a JSON file and warp into List of model as a object.

### API 
City name search uses Regex get only start with searched City name , sorting with City name and take only first 10 rows 

