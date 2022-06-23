using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixasses.applicationservice.Services;

namespace mixassess.Integration
{
    [TestClass]
    public class VehicleService_IsInitialized
    {
        private readonly VehicleService _vehicleService;
        private readonly VehicleBinarySerializer _binarySerializer;

        public VehicleService_IsInitialized()
        {
            _binarySerializer = new VehicleBinarySerializer();
            _vehicleService = new VehicleService(_binarySerializer);
            
        }
        [TestMethod]
        public void Number_Of_Vehicles_Should_Be_Zero()
        {
            var numberOdVehicles = _vehicleService.NumberOfVehicles();
            Assert.AreEqual(0, _vehicleService.NumberOfVehicles());
            Console.WriteLine(string.Format("Expected 0 and got {0}", numberOdVehicles));
        }
    }
}
