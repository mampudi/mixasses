using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services;

namespace mixassess.Integration
{
    [TestClass]
    public class VehicleService_VehicleIsAdded
    {
        private readonly VehicleService _vehicleService;
        private readonly VehicleBinarySerializer _binarySerializer;

        public VehicleService_VehicleIsAdded()
        {
            _binarySerializer = new VehicleBinarySerializer();
            _vehicleService = new VehicleService(_binarySerializer);

        }
        [TestMethod]
        public void Number_Of_Vehicles_Should_Be_One()
        {
            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 1,
                VehicleRegistration = "CV47WVGP",
                Latitude = -25.98953,
                Longitude = 28.12843,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            Assert.AreEqual(1, _vehicleService.NumberOfVehicles());
        }
    }
}
