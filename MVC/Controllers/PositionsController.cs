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
    public class PositionsController : Controller
    {
        // TODO: Add service injections here
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        // GET: Positions
        public IActionResult Index()
		{
			
			List<PositionModel> positionList = _positionService.Query().ToList(); // TODO: Add get collection service logic here
			return View(positionList);
        }

        // GET: Positions/Details/5
        public IActionResult Details(int id)
        {
			PositionModel position = _positionService.Query().SingleOrDefault(x => x.Id == id);

            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
			// TODO: Add get related items service logic here to set ViewData if necessary
			
			return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PositionModel position)
        {

			Result result = _positionService.Add(position);
			if (result.IsSuccessful)
			{
				// Way 1:
				//return RedirectToAction("Index", "Species");
				// Way 2:
				TempData["PositionMessage"] = result.Message;
				return RedirectToAction(nameof(Index));
			}

			ModelState.AddModelError("", result.Message);
            return View(position);
        }

        // GET: Positions/Edit/5
        public IActionResult Edit(int id)
        {
            PositionModel position = _positionService.Query().SingleOrDefault(c => c.Id == id);
           
            if (position == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(position);
        }

        // POST: Positions/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PositionModel position)
        {

            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                Result result = _positionService.Update(position);
                if (result.IsSuccessful)
                {
                    TempData["PositionMessage"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = position.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(position);
        }

        // GET: Positions/Delete/5
        public IActionResult Delete(int id)
        {

			PositionModel position = _positionService.Query().SingleOrDefault(c => c.Id == id);
			
			if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
			Result result = _positionService.Delete(id);

			TempData["PositionMessage"] = result.Message;

			// TODO: Add delete service logic here
			return RedirectToAction(nameof(Index));
        }
	}
}
