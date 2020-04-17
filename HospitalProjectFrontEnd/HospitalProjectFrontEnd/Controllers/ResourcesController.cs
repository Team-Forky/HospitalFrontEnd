using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalProjectFrontEnd.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProjectFrontEnd.Controllers
{
    public class ResourcesController : Controller
    {
        private IResourceManager _resourceService;
        public ResourcesController(IResourceManager resourceService)
        {
            _resourceService = resourceService;
        }
        
        [HttpGet, Route("/resources")]
        public async Task<IActionResult> Index()
        {
            var result = await _resourceService.GetAllResources();
            return View(result);
        }
    }
}