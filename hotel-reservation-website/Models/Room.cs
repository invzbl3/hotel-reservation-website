using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_reservation_website.Models
{
    public class Room
    {
        public string ID { get; set; }
        [Required]
        public int Number { get; set; }

        public string RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public bool Available { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public int MaximumGuests { get; set; }
        public virtual ICollection<RoomFeature> Features { get; set; }
        public virtual ICollection<Image> RoomImages { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
