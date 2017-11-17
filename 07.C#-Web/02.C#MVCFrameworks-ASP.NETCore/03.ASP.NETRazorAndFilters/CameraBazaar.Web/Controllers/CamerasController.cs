namespace CameraBazaar.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.Models.Cameras;

    [Route("cameras")]
    public class CamerasController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICameraService cameras;

        public CamerasController(UserManager<User> userManager, ICameraService cameras)
        {
            this.userManager = userManager;
            this.cameras = cameras;
        }

        [Authorize]
        [Route(nameof(Add))]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        [Route(nameof(Add))]
        public IActionResult Add(AddCameraViewModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.cameras.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMetering,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Route(nameof(All))]
        public IActionResult All()
            => View(this.cameras.AllCameras());

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.View(this.cameras.Details(id));
    }
}