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

            //Position 1 34.544909 -102.100843
            var position1ClosestVehicle = _vehicleService.GetNearestVehiclePosion(34.544909, -102.100843);
            Console.WriteLine(string.Format("The closest vehicle to position 1 (34.544909, -102.100843) is Lat {0} Long {1}", position1ClosestVehicle.Latitude, position1ClosestVehicle.Longitude));

            //Position 2 32.345544, -99.123124
            var position2ClosestVehicle = _vehicleService.GetNearestVehiclePosion(32.345544, -99.123124);
            Console.WriteLine(string.Format("The closest vehicle to position 2 (32.345544, -99.123124) is Lat {0} Long {1}", position2ClosestVehicle.Latitude, position2ClosestVehicle.Longitude));

            //Position 3 33.234235, -100.214124
            var position3ClosestVehicle = _vehicleService.GetNearestVehiclePosion(33.234235, -100.214124);
            Console.WriteLine(string.Format("The closest vehicle to position 3 (33.234235, -100.214124) is Lat {0} Long {1}", position3ClosestVehicle.Latitude, position3ClosestVehicle.Longitude));

            //Position 4 35.195739, -95.348899
            var position4ClosestVehicle = _vehicleService.GetNearestVehiclePosion(35.195739, -95.348899);
            Console.WriteLine(string.Format("The closest vehicle to position 4 (35.195739, -95.348899) is Lat {0} Long {1}", position4ClosestVehicle.Latitude, position3ClosestVehicle.Longitude));

            //Position 5 31.895839, -97.789573
            var position5ClosestVehicle = _vehicleService.GetNearestVehiclePosion(31.895839, -97.789573);
            Console.WriteLine(string.Format("The closest vehicle to position 5 (31.895839, -97.789573) is Lat {0} Long {1}", position5ClosestVehicle.Latitude, position5ClosestVehicle.Longitude));

            //Position 6 32.895839,  -101.789573
            var position6ClosestVehicle = _vehicleService.GetNearestVehiclePosion(32.895839, -101.789573);
            Console.WriteLine(string.Format("The closest vehicle to position 6 (32.895839,  -101.789573) is Lat {0} Long {1}", position6ClosestVehicle.Latitude, position6ClosestVehicle.Longitude));

            //Position 7 34.115839,  -100.225732
            var position7ClosestVehicle = _vehicleService.GetNearestVehiclePosion(34.115839, -100.225732);
            Console.WriteLine(string.Format("The closest vehicle to position 7 (34.115839,  -100.225732) is Lat {0} Long {1}", position7ClosestVehicle.Latitude, position7ClosestVehicle.Longitude));

            //Position 8 32.335839,  -99.992232
            var position8ClosestVehicle = _vehicleService.GetNearestVehiclePosion(32.335839, -99.992232);
            Console.WriteLine(string.Format("The closest vehicle to position 8 (32.335839  -99.992232) is Lat {0} Long {1}", position8ClosestVehicle.Latitude, position8ClosestVehicle.Longitude));

            //Position 9 33.535339,  -94.792232
            var position9ClosestVehicle = _vehicleService.GetNearestVehiclePosion(33.535339, -94.792232);
            Console.WriteLine(string.Format("The closest vehicle to position 9 (33.535339  -94.792232) is Lat {0} Long {1}", position9ClosestVehicle.Latitude, position9ClosestVehicle.Longitude));

            //Position 10 32.234235,  -100.222222
            var position10ClosestVehicle = _vehicleService.GetNearestVehiclePosion(32.234235, -100.222222);
            Console.WriteLine(string.Format("The closest vehicle to position 10 (32.234235  -100.222222) is Lat {0} Long {1}", position10ClosestVehicle.Latitude, position10ClosestVehicle.Longitude));


            //xml serialization
            _vehicleService = AddVehicleWithVehicleServiceForXmlSeriqlization();
            fileName = "vehiclesxml.dat";
            _vehicleService.Serialize(fileName);
            _vehicleService.Deserialize(fileName);

            //json serialization
            _vehicleService = AddVehicleWithVehicleServiceForJsonSerialization();
            fileName = "vehiclesjson.dat";
            _vehicleService.Serialize(fileName);

            


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

        private static VehicleService AddVehicleWithVehicleServiceForXmlSeriqlization()
        {
            var binarySerializer = new VehicleXmlSerializer();

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


        //Due to DI I souldn't change anything in ther service, I should only inject a json serializer
        private static VehicleService AddVehicleWithVehicleServiceForJsonSerialization()
        {
            var binarySerializer = new VehicleJsonSerializer();

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
