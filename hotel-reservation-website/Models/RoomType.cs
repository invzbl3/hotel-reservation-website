using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel_reservation_website.Models
{
    public class RoomType
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal BasePrice { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
