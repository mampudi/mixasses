using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services;
using System.IO;

namespace mixassess.Integration
{
    [TestClass]
    public class VehicleService_VehicleIsSerialized
    {
        private readonly VehicleService _vehicleService;
        private readonly VehicleBinarySerializer _binarySerializer;

        public VehicleService_VehicleIsSerialized()
        {
            _binarySerializer = new VehicleBinarySerializer();
            _vehicleService = new VehicleService(_binarySerializer);

        }
        [TestMethod]
        public void File_Should_Exist()
        {
            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 1,
                VehicleRegistration = "aaaaaa",
                Latitude = -25.98953,
                Longitude = 28.12843,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });

            _vehicleService.AddVehicle(new Vehicle
            {
                PositionId = 2,
                VehicleRegistration = "bbbbb",
                Latitude = -30.98953,
                Longitude = 35.12843,
                RecordedTimeUTC = DateTime.UtcNow.Ticks
            });
            var fileName = string.Format("{0}.dat", typeof(VehicleService_VehicleIsSerialized));
            _vehicleService.Serialize(fileName);
            Assert.AreEqual(true, File.Exists(fileName));
        }
    }
}
