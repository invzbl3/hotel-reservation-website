using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotel_reservation_website.Data;
using hotel_reservation_website.Models;
using hotel_reservation_website.Services;
using Microsoft.AspNetCore.Authorization;

namespace hotel_reservation_website.Controllers
{
    [Authorize]
    public class RoomTypesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IGenericHotelService<RoomType> _hotelService;

        //public RoomTypesController(ApplicationDbContext context)
        public RoomTypesController(IGenericHotelService<RoomType> genericHotelService)
        {
            //_context = context;
            _hotelService = genericHotelService;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index()
        {
            //return View(await _context.RoomTypes.ToListAsync());
            return View(await _hotelService.GetAllItemsAsync());
        }

        // GET: RoomTypes/Details/5    
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var roomType = await _context.RoomTypes.FirstOrDefaultAsync(m => m.ID == id);
            var roomType = await _hotelService.GetItemByIdAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }

            // var rooms = _hotelService.GetAllRooms().Where(x => x.RoomTypeID == id);
            // ViewData["CategoryRooms"] = rooms;
            return View(roomType);
        }

        // GET: RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,BasePrice,Description")] RoomType roomType)
        public async Task<IActionResult> Create([Bind("Name,BasePrice,Description,ImageUrl")] RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(roomType);
                roomType.ID = Guid.NewGuid().ToString();
                //await _context.SaveChangesAsync();
                await _hotelService.CreateItemAsync(roomType);
                return RedirectToAction(nameof(Index));
            }
            return View(roomType);
        }

        // GET: RoomTypes/Edit/5
        //public async Task<IActionResult> Edit(string id)
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var roomType = await _context.RoomTypes.FindAsync(id);
            var roomType = await _hotelService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(string id, [Bind("ID,Name,BasePrice,Description")] RoomType roomType)
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,BasePrice,Description,ImageUrl")] RoomType roomType)
        {
            if (id != roomType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(roomType);
                    //await _context.SaveChangesAsync();
                    await _hotelService.EditItemAsync(roomType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!RoomTypeExists(roomType.ID))
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
            return View(roomType);
        }

        // GET: RoomTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var roomType = await _context.RoomTypes
            //.FirstOrDefaultAsync(m => m.ID == id);
            var roomType = await _hotelService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //var roomType = await _context.RoomTypes.FindAsync(id);
            var roomType = await _hotelService.GetItemByIdAsync(id);
            //_context.RoomTypes.Remove(roomType);
            //await _context.SaveChangesAsync();
            await _hotelService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }

        //private bool RoomTypeExists(string id)
        //{
        //    return _context.RoomTypes.Any(e => e.ID == id);
        //}
    }
}
