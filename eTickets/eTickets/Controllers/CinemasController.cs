﻿using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //GET: Cinemas/Create
        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")]Cinema cinema)
        {
            if(!ModelState.IsValid) return View(cinema);
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
