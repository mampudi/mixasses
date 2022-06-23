using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using mixasses.applicationservice.Services.Interfaces;
using mixasses.applicationservice.Model;
using GeoCoordinatePortable;

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

        public Vehicle GetNearestVehiclePosion(double latitude, double longitude)
        {
            var coord = new GeoCoordinate(latitude, longitude);

            var near = 0.0d;
            Vehicle nearestVehicle = null;
            int counter = 0; //use to set it to the first distance
            foreach (var item in vehicles)
            {
                var currentVehicle = new GeoCoordinate(item.Latitude, item.Longitude);
                double distanceBetween = coord.GetDistanceTo(currentVehicle);

                //set the first one and the nearest and then look for anything closer
                if (counter.Equals(0))
                {
                    near = distanceBetween;
                    nearestVehicle = item;
                    counter++;
                }
                    

                if (distanceBetween < near)
                {
                    near = distanceBetween;
                    nearestVehicle = item;
                }
            }
            return nearestVehicle;
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
