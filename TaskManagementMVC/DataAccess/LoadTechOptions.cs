using Newtonsoft.Json;
using TechfolioMVC.Models;
using TechfolioMVC.Models.Enums;

namespace TechfolioMVC.DataAccess
{
    public static class LoadTechOptions
    {
        public static TechModel Load(TechEnum option)
        {
            const string path = @"\\wwwroot\\tech.json";
            string text = File.ReadAllText(path);
            List<TechModel>? models = JsonConvert.DeserializeObject<List<TechModel>>(text);

            switch (option)
            {
                case TechEnum.HTML:
                    return models.FirstOrDefault(x => x.Name == "HTML");
                case TechEnum.CSS:
                    return models.FirstOrDefault(x => x.Name == "CSS");
                case TechEnum.JavaScript:
                    return models.FirstOrDefault(x => x.Name == "JavaScript");
                case TechEnum.CSharp:
                    return models.FirstOrDefault(x => x.Name == "C#");
                case TechEnum.NET:
                    return models.FirstOrDefault(x => x.Name == ".NET");
                case TechEnum.ASPNET:
                    return models.FirstOrDefault(x => x.Name == "ASP.NET");
                case TechEnum.WebAPI:
                    return models.FirstOrDefault(x => x.Name == "WebAPI");
            }

            return null;
        }
    }
}
