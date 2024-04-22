using Business.Models;
using Business.Services.Bases;
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
    public interface IScoutService
    {
        IQueryable<ScoutModel> Query();
        Result Add(ScoutModel model);
        Result Update(ScoutModel model);

        Result Delete(int id);
    }
    public class ScoutService : ServiceBase, IScoutService
    {
    
        public ScoutService(Db db) : base(db)
        {
   
        }

        public Result Add(ScoutModel model)
        {
            if (_db.Scouts.Any(c => c.UserName.ToLower() == model.UserName.ToLower().Trim()))
                return new ErrorResult("Scout with the same user name exists!");
           
            Scout entity = new Scout()
            {
                UserName = model.UserName.Trim(),
                Password = model.Password,
                
          
            };

            _db.Scouts.Add(entity);
            _db.SaveChanges();
            
            string successMessage = $"{model.UserName} registered as a Scout successfully.";
            return new SuccessResult(successMessage);
        }

        public Result Delete(int id)
        {
            Scout entity = _db.Scouts.SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return new ErrorResult("Scout not found");

            if (entity.ScoutReports is not null && entity.ScoutReports.Any())
                return new ErrorResult("Scout can't be deleted because it has relational reports!");

            _db.Scouts.Remove(entity);
            _db.SaveChanges();

            return new SuccessResult("Scout deleted successfully.");

        }

        public IQueryable<ScoutModel> Query()
        {


            return _db.Scouts.Include(c => c.ClubScouts).OrderBy(c => c.UserName).Select(c => new ScoutModel()
            {
                Id = c.Id,
                UserName = c.UserName,
                Password = c.Password,
                ReportCount = c.ScoutReports.Count,
                ClubNames = string.Join("<br />", c.ClubScouts.Select(p => p.Club.Name)),
            

            });
        }

        public Result Update(ScoutModel model)
        {
            if (_db.Scouts.Any(c => c.Id != model.Id && c.UserName.ToLower() == model.UserName.ToLower().Trim()))
                return new ErrorResult("Scout with the same name exists!");
            Scout entity = _db.Scouts.SingleOrDefault(c => c.Id == model.Id);
            if (entity is null)
                return new ErrorResult("Scout not found");
            string oldName = entity.UserName;
            entity.UserName = model.UserName.Trim();
            entity.Password = model.Password;

            _db.Scouts.Update(entity);
            _db.SaveChanges();
            string successMessage = $"{oldName} updated successfully.";
            return new SuccessResult(successMessage);
        }
    }
}
