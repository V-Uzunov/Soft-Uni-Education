﻿namespace GameraBazaar.Services.Implementations
{
    using Data;
    using Data.Models;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Cameras;

    public class CameraService : ICameraService
    {
        private readonly GameraBazaarDbContext db;

        public CameraService(GameraBazaarDbContext db)
        {
            this.db = db;
        }

        public void Create(
            CameraMake make,
            string model, decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMetering,
            string description,
            string imageUrl,
            string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LIsLightMetering = (LightMetering)lightMetering.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }

        public CameraDetailsModel Details(int id)
            => this.db
                .Cameras
                .Where(c => c.Id == id)
                .Select(c => new CameraDetailsModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,
                    Quantity = c.Quantity,
                    Make = c.Make,
                    Description = c.Description,
                    IsFullFrame = c.IsFullFrame,
                    LightMetering = c.LIsLightMetering,
                    MaxISO = c.MaxISO,
                    MinISO = c.MinISO,
                    MaxShutterSpeed = c.MaxShutterSpeed,
                    MinShutterSpeed = c.MinShutterSpeed,
                    UserId = c.UserId,
                    VideoResolution = c.VideoResolution
                })
                .FirstOrDefault();

        public void Delete(int id)
        {
            var camera = this.db.Cameras.Find(id);

            if (camera == null)
            {
                return;
            }

            this.db.Cameras.Remove(camera);
            this.db.SaveChanges();
        }

        public bool Edit(
            int id, 
            CameraMake make, 
            string model, decimal price,
            int quantity,
            int minShutterSpeed, 
            int maxShutterSpeed,
            MinISO minISO, 
            int maxISO, 
            bool isFullFrame, 
            string videoResolution,
            IEnumerable<LightMetering> 
            lightMetering, 
            string description,
            string imageUrl,
            string userId)
        {
            var camera = this.db
                .Cameras
                .FirstOrDefault(c => c.Id == id && c.UserId == userId);

            if (camera == null)
            {
                return false;
            }

            camera.Make = make;
            camera.Model = model;
            camera.Price = price;
            camera.Quantity = quantity;
            camera.MinShutterSpeed = minShutterSpeed;
            camera.MaxShutterSpeed = maxShutterSpeed;
            camera.MinISO = minISO;
            camera.MaxISO = maxISO;
            camera.IsFullFrame = isFullFrame;
            camera.VideoResolution = videoResolution;
            camera.LIsLightMetering = (LightMetering) lightMetering.Cast<int>().Sum();
            camera.Description = description;
            camera.ImageUrl = imageUrl;

            this.db.SaveChanges();

            return true;
        }

        public bool Exists(int id, string userId)
            => this.db.Cameras.Any(c => c.Id == id && c.UserId == userId);

        IEnumerable<CameraListModel> ICameraService.All()
        {
            return All();
        }

        public IEnumerable<CameraListModel> All()
            => this.db
                .Cameras
                .OrderByDescending(c => c.Id)
                .Select(c => new CameraListModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price,
                    Quantity = c.Quantity
                })
                .ToList();
    }
}
