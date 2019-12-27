using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProject.Areas.Employee.Models;
using CrudProject.Data;
using CrudProject.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Service
{
    public class GenderService : IGenderService
    {
        private readonly ApplicationDbContext _context;

        public GenderService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> SaveGender(Gender gender)
        {
            if (gender.genderId != 0)
            {
                _context.Genders.Update(gender);
                return 1 == await _context.SaveChangesAsync();
            }

            await _context.Genders.AddAsync(gender);
            return 1 == await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<Gender>> GetAllGender()
        {
            var model = _context.Genders.AsNoTracking().ToList();
            return model;
        }

        public async Task<bool> DeleteGenderById(int id)
        {
            _context.Genders.Remove(_context.Genders.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<Gender> GetGenderById(int id)
        {
            Gender gender = await _context.Genders.FindAsync(id);

            return gender;
        }
    }
}
