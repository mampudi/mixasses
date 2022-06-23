using System;
namespace mixasses.applicationservice.Model
{
    /// <summary>
    /// This is a domain class that represents a vehicle
    /// </summary>
    public class Vehicle
    {
        public int PositionId { get; set; }

        public string VehicleRegistration { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public long RecordedTimeUTC { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(int positionId, string vehicleRegistration, double latitude, double longitude, long recordedTimeUTC)
        {
            PositionId = positionId;
            VehicleRegistration = vehicleRegistration;
            Latitude = latitude;
            Longitude = longitude;
            RecordedTimeUTC = recordedTimeUTC;
        }
    }
}
