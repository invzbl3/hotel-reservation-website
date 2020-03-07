using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel_reservation_website.Models
{
    public class Feature
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        public virtual List<RoomFeature> Rooms { get; set; }
    }
}
