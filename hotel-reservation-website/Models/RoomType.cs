using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_reservation_website.Models
{
    public class RoomType
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BasePrice { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
