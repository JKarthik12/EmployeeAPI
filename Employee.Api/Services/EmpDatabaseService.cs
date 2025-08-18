using Newtonsoft.Json;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
namespace Employee.Api.Services
{
    public class EmpDatabaseService
    {
        private readonly string filePath = "C:\\Users\\VSOFT\\source\\repos\\Employee.Api\\Employee.Api\\Data\\Details.json";

        public DataStore Load()
        {
            if (!File.Exists(filePath))
            {
                var newData = new DataStore();
                Save(newData);
                return newData;
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<DataStore>(json) ?? new DataStore();
        }

        public void Save(DataStore data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

}
