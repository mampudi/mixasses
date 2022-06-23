using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services.Interfaces;

namespace mixasses.applicationservice.Services
{
    public class VehicleBinarySerializer : IVehicleSerializer
    {
        public List<Vehicle> Deserialize(string filePath)
        {
            List<Vehicle> vehicles = null;
            FileStream stream;
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                stream = File.OpenRead(filePath);
                vehicles = bf.Deserialize(stream) as List<Vehicle>;
                stream.Close();
            }

            return vehicles;
        }

        public void Serialize(List<Vehicle> data, string filePath)
        {
            FileStream stream;
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(filePath)) File.Delete(filePath);

            stream = File.Create(filePath);
            bf.Serialize(stream, data);
            stream.Close();
        }
    }
}
