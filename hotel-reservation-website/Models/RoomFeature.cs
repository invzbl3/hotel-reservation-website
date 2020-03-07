using System;
using System.ComponentModel.DataAnnotations;

namespace hotel_reservation_website.Models
{
    public class RoomFeature
    {
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }
        public string FeatureID { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
