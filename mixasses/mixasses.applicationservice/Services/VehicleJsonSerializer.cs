using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mixasses.applicationservice.Services
{
    public class VehicleJsonSerializer : IVehicleSerializer
    {
        public List<Vehicle> Deserialize(string filePath)
        {
            var vehicles = new List<Vehicle>();
            JObject obj = null;
            var serializer = new JsonSerializer();


            if (File.Exists(filePath))
            {
                var reader = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(reader);
                obj = serializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                reader.Close();
                
            }

            vehicles = obj.ToObject(typeof(List<Vehicle>)) as List<Vehicle>;
            Console.WriteLine(string.Format("{0} xml vehicles deserialized", vehicles.Count()));
            return vehicles;
        }

        public void Serialize(List<Vehicle> data, string filePath)
        {
            Console.WriteLine("The Json serializer has started");
            var serializer = new JsonSerializer();

            if (File.Exists(filePath)) File.Delete(filePath);

            var streamWriter = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            serializer.Serialize(jsonWriter, data);
            streamWriter.Close();
            streamWriter.Close();
        }
    }
}
