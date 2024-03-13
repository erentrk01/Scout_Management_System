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
    public interface ICoachService
    {
        IQueryable<CoachModel> Query();
        Result Add(CoachModel model);
        Result Update(CoachModel model);

        Result Delete(int id);
    }
    public class CoachService : ICoachService
    {
        private readonly Db _db;

        public CoachService(Db db)
        {
            _db = db;
        }

        public Result Add(CoachModel model)
        {
            if (_db.Coaches.Any(c => c.UserName.ToLower() == model.UserName.ToLower().Trim()))
                return new ErrorResult("Coach with the same user name exists!");

            if(!_db.Clubs.Any(club => club.Id == model.ClubId))
				return new ErrorResult("Such Club does not  exists! Please ask your club admin to  create your club account.");
            
			Coach entity = new Coach()
            {
                UserName = model.UserName.Trim(),
                Password = model.Password,
                TacticalSystem = model.TacticalSystem,
                Experience =model.Experience,
                Formation =  model.Formation,
                ClubId = model.ClubId

            };
            _db.Coaches.Add(entity);
            _db.SaveChanges();
            var clubName = _db.Clubs.FirstOrDefault(c => c.Id == model.ClubId).Name;
            string successMessage = $"{model.UserName} added into {clubName} as a Coach successfully.";
            return new SuccessResult(successMessage);
        }

        public Result Delete(int id)
        {
            Coach entity = _db.Coaches.SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return new ErrorResult("Coach not found");

            if (entity.Positions is not null && entity.Positions.Any())
                return new ErrorResult("Coach can't be deleted because it has relational games!");

            _db.Coaches.Remove(entity);
            _db.SaveChanges();

            return new SuccessResult("Coach deleted successfully.");

        }

        public IQueryable<CoachModel> Query()
        {


            return _db.Coaches.Include(c => c.Positions).OrderBy(c => c.UserName).Select(c => new CoachModel()
            {
                Id = c.Id,
                UserName = c.UserName,
                Experience = c.Experience,
                TacticalSystem = c.TacticalSystem,
                Formation = c.Formation,
                PositionCount = c.Positions.Count,
                PositionNames = string.Join("<br />", c.Positions.Select(p => p.MainPositioning)),
                ClubName = c.Club.Name,
                ClubId = c.Club.Id,

            });
        }

        public Result Update(CoachModel model)
        {
            if (_db.Coaches.Any(c => c.Id != model.Id && c.UserName.ToLower() == model.UserName.ToLower().Trim()))
                return new ErrorResult("Coach with the same name exists!");
           Coach entity = _db.Coaches.SingleOrDefault(c => c.Id == model.Id);
            if (entity is null)
                return new ErrorResult("Coach not found");
            string oldName = entity.UserName;
            entity.UserName = model.UserName.Trim();
            entity.TacticalSystem = model.TacticalSystem;
            entity.Experience = model.Experience;
            entity.Formation = model.Formation;
            entity.ClubId = model.ClubId;

            _db.Coaches.Update(entity);
            _db.SaveChanges();
            string successMessage = $"{oldName} updated successfully.";
            return new SuccessResult(successMessage);
        }
    }
}
