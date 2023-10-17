using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TivitSystemBL.ImplementationOfManagers;
using TivitSystemBL.InterfacesOfManagers;
using TivitSystemEL.IdentityModels;
using TivitSystemEL.ViewModels;
using TivitSystemPL.Models;

namespace TivitSystemPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserTivitManager _userTivitManager;
        private readonly IMapper _mapper;
        private readonly IUserTivitMediaManager _userTivitMediaManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IUserTivitManager userTivitManager, IMapper mapper, IUserTivitMediaManager userTivitMediaManager)
        {
            _logger = logger;
            _userManager = userManager;
            _userTivitManager = userTivitManager;
            _mapper = mapper;
            _userTivitMediaManager = userTivitMediaManager;
        }

        public IActionResult Index()
        {
			//         var tivits = _userTivitManager.GetAll(x => !x.isDeleted).Data.OrderByDescending(x=>x.InsertedDate).ToList();


			//return View(tivits);
			var tivits = _userTivitManager.GetAll(x => !x.isDeleted).Data.OrderByDescending(x => x.InsertedDate).ToList();
			var model = _mapper.Map<List<SendTivitViewModel>>(tivits);
			foreach (var tivit in model)
			{
				var media = _userTivitMediaManager.GetAll(x => x.UserTivitId == tivit.Id).Data;
				tivit.TivitMedias = new List<UserTivitMediaViewModel>();
				foreach (var item in media)
				{
					tivit.TivitMedias.Add(item);
				}
			}

			return View(model);
		}
	

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [Authorize]
        public IActionResult SendTivit()
        {
            //try
            //{
                //useridyi sayfaya gönderelim böylece adres eklemede useridyi metoda aktarabiliriz
                var username = User.Identity?.Name;
                var user = _userManager.FindByNameAsync(username).Result;
                SendTivitViewModel model = new SendTivitViewModel();
                model.TivitPictures = new List<IFormFile>();
                model.UserId = user.Id;
                return View(model);
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError("", "Beklenmedik bir sorun oldu!");
            //    _logger.LogError(ex, "HATA: Home/SendTivit");
            //    return View();
            //}

        }

        [HttpPost]
        [Authorize]
        public IActionResult SendTivit(SendTivitViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _logger.LogError($"HATA: Home/SendTivit post model:{JsonConvert.SerializeObject(model)}");
                    ModelState.AddModelError("", "Lütfen bilgileri eksiksiz giriniz!");
                    return View(model);

                }

                var tivit = _mapper.Map<UserTivitViewModel>(model);
                tivit.InsertedDate = DateTime.Now;
                var result = _userTivitManager.Add(tivit);
                //_userTivitManager.Update(tivit);
                if (!result.IsSuccess)
                {
                    _logger.LogError($"HATA: Home/SendTivit post model:{JsonConvert.SerializeObject(model)}");
                    ModelState.AddModelError("", "Tivit kaydedilemedi!");
                    return View(model);
                }

                // resimleri eklenebilir.
                foreach (var item in model.TivitPictures)
                {
                    if (item.ContentType.Contains("image") && item.Length > 0)
                    {
                        string fileName = $"{item.FileName.Substring(0, item.FileName.IndexOf('.'))}-{Guid.NewGuid().ToString().Replace("-", "")}";

                        string uzanti = Path.GetExtension(item.FileName);

                        string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/TivitPictures/{fileName}{uzanti}");

                        string directoryPath =
                           Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/TivitPictures/");

                        if (!Directory.Exists(directoryPath))
                            Directory.CreateDirectory(directoryPath);

                        using var stream = new FileStream(path, FileMode.Create);

                        item.CopyTo(stream);
                        UserTivitMediaViewModel p = new UserTivitMediaViewModel()
                        {
                            UserTivitId = result.Data.Id,
                            MediaPath = $"/TivitPictures/{fileName}{uzanti}"
                        };
                        _userTivitMediaManager.Add(p);

                    }
                }

                TempData["TivitIndexSuccessMsg"] = "Tivit attınız!";
                _logger.LogInformation($"Home/SendTivit atılan tivit: {JsonConvert.SerializeObject(model)}");
                return RedirectToAction("SendTivit", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"HATA: Home/SendTivit post model:{JsonConvert.SerializeObject(model)}");
                ModelState.AddModelError("", "Beklenmedik bir sorun oluştu!");
                return View(model);
            }
            //try
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        ModelState.AddModelError("", "Eksik ya da hatalı bilgi girdiniz");
            //        _logger.LogError("HATA: Home/SendTivit");
            //        return View();
            //    }
            //    var tivit = _mapper.Map<UserTivitViewModel>(model);
            //    tivit.InsertedDate = DateTime.Now;
            //    var result = _userTivitManager.Add(tivit);
            //    if (!result.IsSuccess)
            //    {
            //        ModelState.AddModelError("", "Eksik ya da hatalı bilgi girdiniz");
            //        _logger.LogError("HATA: Home/SendTivit");
            //        return View();
            //    }
            //    TempData["TivitIndexSuccessMsg"] = "Tivit attınız!";
            //    _logger.LogError("HATA: Home/SendTivit");
            //    return View(model);
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError("", "Beklenmedik bir sorun oldu!");
            //    _logger.LogError(ex, "HATA: Home/SendTivit");
            //    return View();
            //}

        }

        [Authorize]
        public IActionResult TivitIndex()
        {
            return View();
        }
    }
}