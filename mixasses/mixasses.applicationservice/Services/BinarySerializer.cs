using System;
using mixasses.applicationservice.Services.Interfaces;

namespace mixasses.applicationservice.Services
{
    public class BinarySerializer : IVehicleSerializer
    {
        public object Deserialize(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Serialize(object data, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
