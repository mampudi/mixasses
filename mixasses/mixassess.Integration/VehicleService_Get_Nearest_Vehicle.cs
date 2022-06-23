using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services;

namespace mixassess.Integration
{
    [TestClass]
    public class VehicleService_Get_Nearest_Vehicle_Should_Be_Two
    {
        private readonly VehicleService _vehicleService;
        private readonly VehicleBinarySerializer _binarySerializer;

        public VehicleService_Get_Nearest_Vehicle_Should_Be_Two()
        {
            _binarySerializer = new VehicleBinarySerializer();
            _vehicleService = new VehicleService(_binarySerializer);

        }
        [TestMethod]
        public void FindNearestVehiclePositionShouldBeTwo()
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

            var nearestVehicle = _vehicleService.GetNearestVehiclePosion(32.345544, -99.123124);
            Assert.AreEqual(2, nearestVehicle.PositionId);
        }
    }
}
