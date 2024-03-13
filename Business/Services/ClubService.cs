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
    public interface IClubService
    {
        IQueryable<ClubModel> Query();
        Result Add(ClubModel model);
        Result Update(ClubModel model);

        Result Delete(int id);
    }
    public class ClubService : IClubService
    {
        private readonly Db _db;

        public ClubService(Db db)
        {
            _db = db;
        }

        public Result Add(ClubModel model)
        {
            if (_db.Clubs.Any(s => s.Name.ToLower() == model.Name.ToLower().Trim())) 
                return new ErrorResult("Club with the same name exists!");
             Club entity = new Club()
            {
                Name = model.Name.Trim(),
                Country = model.Country,
                City = model.City,
                Mail = model.Mail

            };
            _db.Clubs.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Club added successfully.");
        }

        public Result Delete(int id)
        {
            Club entity = _db.Clubs.SingleOrDefault(c => c.Id == id);
            if(entity is null )
            return new ErrorResult("Club not found");

            if (entity.Coachs is not null && entity.Coachs.Any())
            return new ErrorResult("Club can't be deleted because it has relational games!");
           
            _db.Clubs.Remove(entity);
            _db.SaveChanges();

            return new SuccessResult("Club deleted successfully.");

        }

        public IQueryable<ClubModel> Query()
        {

            return _db.Clubs.Include(c => c.ClubScouts).OrderBy(c => c.Name).Select(c => new ClubModel()
            {
                Id = c.Id,
                Name = c.Name,
                Country = c.Country,
                City = c.City,
                Mail = c.Mail,
                ScoutCount = c.ClubScouts.Count, 
                CoachNames = string.Join("<br />", c.Coachs.Select(coach => coach.UserName))
            });
        }

        public Result Update(ClubModel model)
        {
            if (_db.Clubs.Any( c => c.Id != model.Id &&  c.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResult("Club with the same name exists!");
            Club entity = _db.Clubs.SingleOrDefault(c=>c.Id == model.Id);
            if (entity is null)
                return new ErrorResult("Club not found");
            string oldName = entity.Name;
            entity.Name = model.Name.Trim();
            entity.Country = model.Country;
            entity.City = model.City;
            entity.Mail = model.Mail;

            _db.Clubs.Update(entity);
            _db.SaveChanges();
            string successMessage = $"{oldName} updated successfully.";
            return new SuccessResult(successMessage);
        }
    }
}
