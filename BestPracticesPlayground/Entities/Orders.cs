using System;
using System.Collections.Generic;

namespace Entities
{
    public class Orders
    {
        public int Id { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DueDate { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}