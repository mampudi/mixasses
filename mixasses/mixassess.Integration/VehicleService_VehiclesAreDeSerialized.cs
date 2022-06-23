using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixasses.applicationservice.Model;
using mixasses.applicationservice.Services;

namespace mixassess.Integration
{
    [TestClass]
    public class VehicleService_VehiclesAreDeSerialized
    {
        private readonly VehicleService _vehicleService;
        private readonly VehicleBinarySerializer _binarySerializer;

        public VehicleService_VehiclesAreDeSerialized()
        {
            _binarySerializer = new VehicleBinarySerializer();
            _vehicleService = new VehicleService(_binarySerializer);

        }
        [TestMethod]
        public void File_Should_Exist_And_Should_Be_Loaded_In_Object()
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
            var vehicles = _vehicleService.Deserialize(fileName);
            var numberOfDeserializedVehicles = vehicles.Count();
            Assert.AreEqual(_vehicleService.NumberOfVehicles(), numberOfDeserializedVehicles);
        }
    }
}
