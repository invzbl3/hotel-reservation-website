using hotel_reservation_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_reservation_website.ViewModels
{
    public class AddImagesViewModel
    {
        public List<string> UploadErrors { get; set; }
        public List<Image> AddedImages { get; set; }
    }
}
