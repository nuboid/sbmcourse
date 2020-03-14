using MyApplication.DomainModel.Enums;
using MySoftwareCompany.DDD;
using System.Collections.Generic;

namespace MyApplication.DomainModel.PlannedRouteAggregate
{
    public class PlannedRoute : BaseEntity
    {
        public string OnDate { get; set; }
        public string VehiclePlate { get; set; }
        public string StartLocation { get; set; }
        public string StartLocationDescription { get; set; }
        public string EndLocation { get; set; }
        public string EndLocationDescription { get; set; }
        public MeansOfTransportEnum MeansOfTransport { get; set; }
        public double TotalWeight { get; set; }
        public double TotalVolume { get; set; }
        public double TotalDistance { get; set; }
        public double TotalDrivingTime { get; set; }
        public double TotalDwellTime { get; set; }
        public double TotalTime { get; set; }
        public List<RoutePart> RouteParts { get; set; }
    }
}
