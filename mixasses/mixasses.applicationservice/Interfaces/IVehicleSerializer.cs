namespace mixasses.applicationservice.Services.Interfaces
{
    public interface IVehicleSerializer
    {
        object Deserialize(string filePath);
        void Serialize(object data, string filePath);
    }
}