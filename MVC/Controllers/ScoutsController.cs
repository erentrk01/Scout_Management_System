#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;
using DataAccess.Results.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class ScoutsController : Controller
    {
        // TODO: Add service injections here
        private readonly IScoutService _scoutService;

        public ScoutsController(IScoutService scoutService)
        {
            _scoutService = scoutService;
        }

        // GET: Scouts
        public IActionResult Index()
        {
            List<ScoutModel> scoutList = _scoutService.Query().ToList();
            return View(scoutList);
        }

        // GET: Scouts/Details/5
        public IActionResult Details(int id)
        {

            ScoutModel scout = _scoutService.Query().SingleOrDefault(c => c.Id == id);
         
            if (scout == null)
            {
                return NotFound();
            }
            return View(scout);
        }

        // GET: Scouts/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View();
        }

        // POST: Scouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ScoutModel scout)
        {

            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here

                Result result = _scoutService.Add(scout);
                if (result.IsSuccessful)
                {
                    TempData["ScoutMessage"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(scout);
        }

        // GET: Scouts/Edit/5
        public IActionResult Edit(int id)
        {

            ScoutModel scout = _scoutService.Query().SingleOrDefault(c => c.Id == id); // TODO: Add get item service logic here
            if (scout == null)
            {
                return NotFound();
            }
            
            return View(scout);
        }

        // POST: Scouts/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ScoutModel scout)
        {

            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                Result result = _scoutService.Update(scout);
                if (result.IsSuccessful)
                {
                    TempData["ScoutMessage"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = scout.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(scout);
        }

        // GET: Scouts/Delete/5
        public IActionResult Delete(int id)
        {

            ScoutModel scout = _scoutService.Query().SingleOrDefault(c => c.Id == id);
            if (scout == null)
            {
                return NotFound();
            }
            return View(scout);
        }

        // POST: Scouts/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _scoutService.Delete(id);

            TempData["ScoutMessage"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
	}
}
