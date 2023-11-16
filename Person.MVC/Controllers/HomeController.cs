using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Person.Application;
using Person.Application.Queries;
using Person.MVC.Models;
using System.Diagnostics;

namespace Person.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache, IMediator mediator)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery());
            var contact = contacts.OrderByDescending(c => c.Id).First();
            var memoryCacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(100))
                .SetPriority(CacheItemPriority.Normal);

            _memoryCache.Set("cache", contact, memoryCacheOptions);
            return View();
        }

        public IActionResult Privacy()
        {
            var contact = new ContactDTO();
            if(_memoryCache.TryGetValue("cache", out contact))
            {
                TempData["success"] = "Successfully get data";
            }
            else
            {
                TempData["failed"] = "There's not any data";
            }
            
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}