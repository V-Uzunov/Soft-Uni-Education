namespace CameraBazaar.Services.Interfaces
{
    using Data.Models;
    using System.Collections.Generic;
    using Models.Cameras;

    public interface ICameraService
    {
        void Create(
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
            string userId);

        IEnumerable<AllCameraModel> AllCameras();

        DetailCameraModel Details(int id);
    }
}
