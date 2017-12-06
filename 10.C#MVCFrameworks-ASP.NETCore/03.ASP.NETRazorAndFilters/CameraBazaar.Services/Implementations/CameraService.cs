namespace CameraBazaar.Services.Implementations
{
    using Interfaces;
    using Data;
    using Data.Models;
    using Models.Cameras;
    using System.Collections.Generic;
    using System.Linq;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public void Create(
            CameraMake make,
            string model, 
            decimal price,
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
                LightMetering = (LightMetering)lightMetering.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }

        public IEnumerable<AllCameraModel> AllCameras()
            => this.db
                .Cameras
                .Select(c => new AllCameraModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    ImageUrl = c.ImageUrl,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity
                })
                .ToList();

        public DetailCameraModel Details(int id)
            => this.db
                .Cameras
                .Where(c => c.Id == id)
                .Select(c => new DetailCameraModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    MinShutterSpeed = c.MinShutterSpeed,
                    MaxShutterSpeed = c.MaxShutterSpeed,
                    MinISO = c.MinISO,
                    MaxISO = c.MaxISO,
                    IsFullFrame = c.IsFullFrame,
                    VideoResolution = c.VideoResolution,
                    LightMetering = c.LightMetering,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    UserName =c.User.UserName,
                    UserId = c.UserId
                })
                .FirstOrDefault();

        
    }
}
