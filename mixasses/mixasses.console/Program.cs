using System;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services;

namespace mixasses.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleService = AddVehicleWithVehicleService();

            //serialize to binary

            Console.ReadLine();
        }

        private static VehicleService AddVehicleWithVehicleService()
        {
            //The only responsibility of the binarySerializer is to serialise and deserialize to binary
            //The BinaryFormatter type is dangerous and is not recommended for data processing.
            //Applications should stop using BinaryFormatter as soon as possible, even if they believe the data
            //they're processing to be trustworthy. BinaryFormatter is insecure and can't be made secure.
            var binarySerializer = new VehicleBinarySerializer();

            //injecting is so that if there changes in future we can switch to json or xml serializer with minimum change here
            //The only responsibility of the vehicle service is to manage vehicles (SRP)
            var vehicleService = new VehicleService(binarySerializer);

            //Show the number of vehicles when the program started
            Console.WriteLine(string.Format("Number of vehicles when the program started {0}", vehicleService.NumberOfVehicles().ToString()));

            vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 1,
                VehicleRegistration = "CV47WVGP",
                Latitude = -25.98953,
                Longitude = 28.12843,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            //Show the number of vehicles after adding one vehicle
            Console.WriteLine(string.Format("Number of vehicles after adding 1 vehicle is {0}", vehicleService.NumberOfVehicles().ToString()));
            return vehicleService;
        }
    }
}
