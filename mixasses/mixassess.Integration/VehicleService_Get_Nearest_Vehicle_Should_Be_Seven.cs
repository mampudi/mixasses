using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services;

namespace mixassess.Integration
{
    [TestClass]
    public class VehicleService_Get_Nearest_Vehicle_Should_Be_Seven
    {
        private readonly VehicleService _vehicleService;
        private readonly VehicleBinarySerializer _binarySerializer;

        public VehicleService_Get_Nearest_Vehicle_Should_Be_Seven()
        {
            _binarySerializer = new VehicleBinarySerializer();
            _vehicleService = new VehicleService(_binarySerializer);

        }
        [TestMethod]
        public void FindNearestVehiclePositionShouldBeSeven()
        {
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

            var nearestVehicle = _vehicleService.GetNearestVehiclePosion(34.115839, -100.225732);
            Assert.AreEqual(7, nearestVehicle.PositionId);
        }
    }
}
