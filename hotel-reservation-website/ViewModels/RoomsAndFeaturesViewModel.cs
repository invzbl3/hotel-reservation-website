using hotel_reservation_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_reservation_website.ViewModels
{
    public class RoomsAndFeaturesViewModel
    {
        public List<Room> Rooms { get; set; }
        public List<RoomFeature> Features { get; set; }
    }
}
