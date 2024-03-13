using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IPositionService
    {
        IQueryable<PositionModel> Query();
        Result Add(PositionModel model);
        Result Update(PositionModel model);

        Result Delete(int id);
    }
    public class PositionService : IPositionService
    {
        private readonly Db _db;

        public PositionService(Db db)
        {
            _db = db;
        }

        public Result Add(PositionModel model)
        {
            if (_db.Positions.Any(s => s.Description.ToLower() == model.Description.ToLower().Trim()))
                return new ErrorResult("Position with the same description exists!");
			DateTime currentlocalTime = DateTime.Now;
			Position entity = new Position()
            {
                MainPositioning = model.MainPositioning,
                TechnicalProficiency = model.TechnicalProficiency,
                SecondaryPositioning = model.SecondaryPositioning,
                Description = model.Description,
                Experience = model.Experience,
                SpecialSkill = model.SpecialSkill,
                Personality = model.Personality,
                DribblingAbility = model.DribblingAbility,
                PressingAbility = model.PressingAbility,
                LastUpdatedAt = currentlocalTime,
                CreatedAt = currentlocalTime,
                
            

            };
            _db.Positions.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("New Position created successfully.");
        }

        public Result Delete(int id)
        {
            Position entity = _db.Positions.SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return new ErrorResult("Position not found");
            _db.Positions.Remove(entity);
            _db.SaveChanges();

            return new SuccessResult("Position deleted successfully.");

        }

        public IQueryable<PositionModel> Query()
        {

            return _db.Positions.OrderByDescending(c => c.LastUpdatedAt).Select(c => new PositionModel()
            {
                Id = c.Id,
                LastUpdatedAt = c.LastUpdatedAt,
                CreatedAt = c.CreatedAt,
                Description = c.Description,
                SpecialSkill = c.SpecialSkill,
                Personality = c.Personality,
                MainPositioning = c.MainPositioning,
                SecondaryPositioning = c.SecondaryPositioning,
                PressingAbility = c.PressingAbility,
                DribblingAbility = c.DribblingAbility,
                TechnicalProficiency = c.TechnicalProficiency,
                Experience = c.Experience,
                Guid = c.Guid,
                ReportCount = 0 ,// Fıx here after updated the db to create a relationship between position and report
                CoachName = c.Coach.UserName
            });
        }

        public Result Update(PositionModel model)
        {
            if (_db.Positions.Any(c => c.Id != model.Id && c.Description.ToLower() == model.Description.ToLower().Trim()))
                return new ErrorResult("Position with the same description exists!");
            Position entity = _db.Positions.SingleOrDefault(c => c.Id == model.Id);
            if (entity is null)
                return new ErrorResult("Position not found");
            string oldName = entity.Description;
           entity.Description = model.Description;
           entity.MainPositioning = model.MainPositioning;
           entity.SecondaryPositioning = model.SecondaryPositioning;
            entity.PressingAbility = model.PressingAbility;
            entity.DribblingAbility = model.PressingAbility;
            entity.Personality = model.Personality;
            entity.Experience = model.Experience;
            entity.TechnicalProficiency = model.TechnicalProficiency;
           

            _db.Positions.Update(entity);
            _db.SaveChanges();
            string successMessage = $"Position Request: '{entity.Experience} {entity.MainPositioning}' updated successfully.";
            return new SuccessResult(successMessage);
        }
    }
}
