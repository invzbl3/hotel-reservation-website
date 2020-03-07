using hotel_reservation_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_reservation_website.ViewModels
{
    public class SelectedRoomFeatureViewModel
    {
        public string FeatureID { get; set; }
        public virtual Feature Feature { get; set; }
        public bool Selected { get; set; }
    }
}
