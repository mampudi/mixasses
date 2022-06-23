using System;
using System.Collections.Generic;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services.Interfaces;

namespace mixasses.applicationservice.Services
{
    public class VehicleJsonSerializer : IVehicleSerializer
    {
        public List<Vehicle> Deserialize(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Serialize(List<Vehicle> data, string filePath)
        {
            Console.WriteLine("The Json serializer has started");
            //throw new NotImplementedException();
        }
    }

}
