using System.Collections.Generic;

namespace Entities
{
    public class Route
    {
        public int Id { get; set; }

        public bool IsDropoff { get; set; }

        public int DestinationId { get; set; }

        public virtual ICollection<Waypoint> Waypoints { get; set; }
    }
}