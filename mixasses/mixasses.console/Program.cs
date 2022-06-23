using System;
using System.Linq;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services;

namespace mixasses.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var _vehicleService = AddVehicleWithVehicleService();

            //serialize to binary
            var fileName = "vehiclesbinary.dat";
            _vehicleService.Serialize(fileName);
            Console.WriteLine(string.Format("The serialized file has been created with the name {0}", fileName));


            var deserializedVehiclesFromBianry = _vehicleService.Deserialize(fileName);
            Console.WriteLine(string.Format("The number of vehicles desirialized from binary is {0}", deserializedVehiclesFromBianry.Count()));

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
            var _vehicleService = new VehicleService(binarySerializer);

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 1,
                VehicleRegistration = "aaaaaa",
                Latitude = 34.544909,
                Longitude = -102.100843,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 2,
                VehicleRegistration = "bbbbb",
                Latitude = 32.345544,
                Longitude = -99.123124,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 3,
                VehicleRegistration = "cccccc",
                Latitude = 33.234235,
                Longitude = -100.214124,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 4,
                VehicleRegistration = "ddddd",
                Latitude = 35.195739,
                Longitude = -95.348899,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 5,
                VehicleRegistration = "eeeee",
                Latitude = 31.895839,
                Longitude = -97.789573,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 6,
                VehicleRegistration = "fffff",
                Latitude = 32.895839,
                Longitude = -101.789573,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 7,
                VehicleRegistration = "ggggg",
                Latitude = 34.115839,
                Longitude = -100.225732,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 8,
                VehicleRegistration = "hhhhh",
                Latitude = 32.335839,
                Longitude = -99.992232,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 9,
                VehicleRegistration = "iiiii",
                Latitude = 33.535339,
                Longitude = -94.792232,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 10,
                VehicleRegistration = "jjjjj",
                Latitude = 32.234235,
                Longitude = -100.222222,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            Console.WriteLine(string.Format("The number of vehicles is {0}", _vehicleService.NumberOfVehicles().ToString()));

            return _vehicleService;
        }
    }
}
