using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotel_reservation_website.Data;
using hotel_reservation_website.Models;
using hotel_reservation_website.Services;
using System;

namespace hotel_reservation_website.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IGenericHotelService<Room> _hotelService;

        public RoomsController(IGenericHotelService<Room> hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: Rooms
        public IActionResult Index()
        {
            return View(_hotelService.GetAllRoomsAndRoomTypes());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _hotelService.GetItemByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            var RoomTypes = _hotelService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.ID = Guid.NewGuid().ToString();
                await _hotelService.CreateItemAsync(room);
                return RedirectToAction(nameof(Index));
            }
           
            //var RoomTypes = _hotelService.GetAllRoomTypesAsync().Result;
            //ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "Name", room.RoomType.ID);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _hotelService.GetItemByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            var RoomTypes = _hotelService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "Name", room.RoomType.ID);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotelService.EditItemAsync(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_hotelService.GetItemByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var RoomTypes = _hotelService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "ID", room.RoomTypeID);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _hotelService.GetItemByIdAsync(id);
               
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roomType = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }

        //private bool RoomExists(string id)
        //{
        //    return _context.Rooms.Any(e => e.ID == id);
        //}
    }
}
