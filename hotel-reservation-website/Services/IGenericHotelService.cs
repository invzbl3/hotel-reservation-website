﻿using hotel_reservation_website.Models;
using hotel_reservation_website.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hotel_reservation_website.Services
{
    public interface IGenericHotelService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();

        Task<TEntity> GetItemByIdAsync(string id);

        Task<IEnumerable<TEntity>> SearchFor(Expression<Func<TEntity, bool>> expression);

        Task CreateItemAsync(TEntity entity);

        Task EditItemAsync(TEntity entity);

        Task DeleteItemAsync(TEntity entity);


        //This section contains methods particular to specific controllers
        #region Specific Controller Methods          

        RoomsAdminIndexViewModel GetAllRoomsAndRoomTypes();

        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();

        IEnumerable<Room> GetAllRooms();

        IEnumerable<Booking> GetAllBookings();

        IEnumerable<Room> GetAllRoomsWithFeature(string feature);

        List<SelectedRoomFeatureViewModel> PopulateSelectedFeaturesForRoom(Room room);

        void UpdateRoomFeaturesList(Room room, string[] SelectedFeatureIDs);

        Task<AddImagesViewModel> AddImagesAsync(List<IFormFile> files);

        Task RemoveImageAsync(Image image);

        Task<RoomFeaturesAndImagesViewModel> GetRoomFeaturesAndImagesAsync(Room room);

        void UpdateRoomImagesList(Room room, string[] imageIDs);

        #endregion


    }
}