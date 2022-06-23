using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using mixasses.applicationservice.Services.Interfaces;
using mixasses.applicationservice.Model;

namespace mixasses.applicationservice.Services
{
    public class VehicleService
    {
        private readonly IVehicleSerializer serializer;
        private readonly List<Vehicle> vehicles;
        public VehicleService(IVehicleSerializer serializer)
        {
            this.serializer = serializer;
            this.vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public int NumberOfVehicles()
        {
            return vehicles.Count();
        }

        public List<Vehicle> GetAll()
        {
            return vehicles;
        }

        public Vehicle Get(string registrationNumber)
        {
            return vehicles.Single(a => a.VehicleRegistration.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
        }

        public void Serialize(string filePath)
        {
            serializer.Serialize(vehicles, filePath);
        }

        public List<Vehicle> Deserialize(string filePath)
        {
            List<Vehicle> vehicles = serializer.Deserialize(filePath) as List<Vehicle>;
            return vehicles;
        }



    }
}
