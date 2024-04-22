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
using MVC.Controllers.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class CoachesController : MvcControllerBase
    {
        // TODO: Add service injections here
        private readonly ICoachService _coachService;
        private readonly IClubService _clubService;

        public CoachesController(ICoachService coachService, IClubService clubService)
        {
            _coachService = coachService;
            _clubService = clubService;
        }

        // GET: Coaches
        public IActionResult Index()
        {
            List<CoachModel> coachList = _coachService.Query().ToList(); // TODO: Add get collection service logic here
			return View(coachList);
        }

        // GET: Coaches/Details/5
        public IActionResult Details(int id)
		{
			
			CoachModel coach = _coachService.Query().SingleOrDefault(c => c.Id == id); // TODO: Add get item service logic here
			if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
			// Fetch the list of clubs
			var clubs = _clubService.Query().ToList();

			// Map the list of clubs to SelectListItems
			var clubList = clubs.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(),
				Text = c.Name
			}).ToList();
			// TODO: Add get related items service logic here to set ViewData if necessary
			// Pass the SelectList to the view
			ViewData["ClubId"] = new SelectList(clubList, "Value", "Text");
			return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoachModel coach)
        {

			if (ModelState.IsValid)
			{
				// TODO: Add insert service logic here

				Result result = _coachService.Add(coach);
				if (result.IsSuccessful)
				{
					// Way 1:
					//return RedirectToAction("Index", "Species");
					// Way 2:
					TempData["CoachMessage"] = result.Message;
					return RedirectToAction(nameof(Index));
				}

				ModelState.AddModelError("", result.Message);
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			return View(coach);
		}

        // GET: Coaches/Edit/5
        public IActionResult Edit(int id)
        {
			// Fetch the list of clubs
			var clubs = _clubService.Query().ToList();

			// Map the list of clubs to SelectListItems
			var clubList = clubs.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(),
				Text = c.Name
			}).ToList();
			// TODO: Add get related items service logic here to set ViewData if necessary
			// Pass the SelectList to the view
			
		
			CoachModel coach = _coachService.Query().SingleOrDefault(c => c.Id == id); // TODO: Add get item service logic here
            if (coach == null)
            {
                return NotFound();
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewData["ClubId"] = new SelectList(clubList, "Value", "Text");
			return View(coach);
        }

        // POST: Coaches/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoachModel coach)
        {

			if (ModelState.IsValid)
			{
				// TODO: Add update service logic here
				Result result = _coachService.Update(coach);
				if (result.IsSuccessful)
				{
					TempData["CoachMessage"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = coach.Id });
				}
				ModelState.AddModelError("", result.Message);
			}
			return View(coach);
			
		}

		// GET: Coaches/Delete/5
		public IActionResult Delete(int id)
        {
            CoachModel coach = _coachService.Query().SingleOrDefault(c => c.Id == id); // TODO: Add get item service logic here
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            Result result = _coachService.Delete(id);

            TempData["CoachMessage"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
	}
}
