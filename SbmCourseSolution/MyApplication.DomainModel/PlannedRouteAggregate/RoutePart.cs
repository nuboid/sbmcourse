using MyApplication.DomainModel.Enums;
using MySoftwareCompany.DDD;

namespace MyApplication.DomainModel.PlannedRouteAggregate
{
    public class RoutePart : BaseEntity
    {
        public RoutePartTypeEnum RoutePartType { get; set; }
        public int Order { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public string DropDeliveryId { get; set; } //only when StopAtDeliveryAddress
        public string RoutePolygon { get; set; }
    }
}
