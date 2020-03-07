using hotel_reservation_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_reservation_website.ViewModels
{
    public class RoomFeaturesAndImagesViewModel
    {
        public List<Image> Images { get; set; }
        public List<Feature> Features { get; set; }
    }
}
