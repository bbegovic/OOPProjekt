using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.data
{
    public class JsonFileService
    {

        private readonly string _baseFolder;

        public JsonFileService(string baseFolder)
        {
            _baseFolder = baseFolder;
        }

        private string GetJsonFilePath(string genderFolder, string fileName)
        {
            return Path.Combine(_baseFolder, genderFolder, fileName);
        }

        public async Task<T?> LoadJsonAsync<T>(string genderFolder, string jsonFileName)
        {
            var path = GetJsonFilePath(genderFolder, jsonFileName);
            if (!File.Exists(path))
                throw new FileNotFoundException($"JSON file not found: {path}");

            using FileStream stream = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }


    }
}
