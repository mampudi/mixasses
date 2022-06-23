using System.Collections.Generic;
using mixasses.applicationservice.Model;

namespace mixasses.applicationservice.Services.Interfaces
{
    public interface IVehicleSerializer
    {
        List<Vehicle> Deserialize(string filePath);
        void Serialize(List<Vehicle> data, string filePath);
    }
}