using System;
using System.Collections.Generic;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services.Interfaces;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace mixasses.applicationservice.Services
{
    public class VehicleXmlSerializer : IVehicleSerializer
    {
        public List<Vehicle> Deserialize(string filePath)
        {
            var vehicles = new List<Vehicle>();
            var xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));

            if (File.Exists(filePath))
            {
                var reader = new StreamReader(filePath);
                vehicles = xmlSerializer.Deserialize(reader) as List<Vehicle>;
                Console.WriteLine(string.Format("{0} xml vehicles deserialized", vehicles.Count()));
                reader.Close();
            }


            return vehicles;
        }

        public void Serialize(List<Vehicle> data, string filePath)
        {
            Console.WriteLine("The Xml serializer has started");
            var xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));

            if (File.Exists(filePath)) File.Delete(filePath);

            var writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, data);
            writer.Close();
        }
    }
}
