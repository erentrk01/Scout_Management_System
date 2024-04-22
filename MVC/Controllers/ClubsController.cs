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
	public class ClubsController : MvcControllerBase
    {
		// TODO: Add service injections here
		private readonly IClubService _clubService;

		public ClubsController(IClubService clubService)
		{
			_clubService = clubService;
		}

		// GET: Clubs
		public IActionResult Index()
		{
			List<ClubModel> clubList = _clubService.Query().ToList(); // TODO: Add get collection service logic here
			return View(clubList);
		}

		// GET: Clubs/Details/5
		public IActionResult Details(int id)
		{
		   ClubModel club = _clubService.Query().SingleOrDefault(c => c.Id == id);
			if (club == null)
			{
				return NotFound();
			}
			return View(club);
		}

		// GET: Clubs/Create
		public IActionResult Create()
		{
			// TODO: Add get related items service logic here to set ViewData if necessary
			return View();
		}

		// POST: Clubs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(ClubModel club)

		{
            if (ModelState.IsValid)
			{
                // TODO: Add insert service logic here

                Result result = _clubService.Add(club);
                if (result.IsSuccessful)
                {
                    // Way 1:
                    //return RedirectToAction("Index", "Species");
                    // Way 2:
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", result.Message);
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			return View(club);
		}

		// GET: Clubs/Edit/5
		public IActionResult Edit(int id)
		{
			ClubModel club = _clubService.Query().SingleOrDefault( c => c.Id == id); // TODO: Add get item service logic here
			if (club == null)
			{
				return NotFound();
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			return View(club);
		}

		// POST: Clubs/Edit
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ClubModel club)
		{
			if (ModelState.IsValid)
			{
                // TODO: Add update service logic here
                Result result = _clubService.Update(club);
				if(result.IsSuccessful)
				{
					TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = club.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			return View(club);
		}

		// GET: Clubs/Delete/5
		public IActionResult Delete(int id)
		{
			ClubModel club = _clubService.Query().SingleOrDefault(c => c.Id == id);
	
			if (club == null)
			{
				return NotFound();
			}
			return View(club);
		}

		// POST: Clubs/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			// TODO: Add delete service logic here
			Result result = _clubService.Delete(id);
			
			TempData["Message"] = result.Message;
			
			return RedirectToAction(nameof(Index));
		}
	}
}


