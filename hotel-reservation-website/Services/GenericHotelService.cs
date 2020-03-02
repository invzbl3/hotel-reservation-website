﻿using hotel_reservation_website.Data;
using hotel_reservation_website.Models;
using hotel_reservation_website.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hotel_reservation_website.Services
{
    public class GenericHotelService<TEntity> : IGenericHotelService<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> DbSet;

        //GenericHotelService requires a context class to work. 
        //Constructor sets the DbSet property to the appropriate DbSet representing the Model Entity, ready for use.
        public GenericHotelService(ApplicationDbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllItemsAsync()
        {
            return await DbSet.ToArrayAsync();
        }

        public async Task<TEntity> GetItemByIdAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> SearchFor(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).ToArrayAsync();
        }

        public async Task CreateItemAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task EditItemAsync(TEntity entity)
        {
            _context.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        //This section contains methods particular to specific controllers
        #region Specific Controller Methods


        public RoomsAdminIndexViewModel GetAllRoomsAndRoomTypes()
        {

            var rooms = _context.Rooms.ToList();
            var roomtypes = _context.RoomTypes.ToList();

            var RoomsAdminIndeViewModel = new RoomsAdminIndexViewModel
            {
                Rooms = rooms,
                RoomTypes = roomtypes
            };
            return RoomsAdminIndeViewModel;
        }
        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            return await _context.RoomTypes.ToArrayAsync();
        }

        #endregion
    }
}
