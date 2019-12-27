using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProject.Areas.Employee.Models;

namespace CrudProject.Service.Interface
{
    public interface IGenderService
    {
        Task<bool> SaveGender(Gender gender);
        Task<IEnumerable<Gender>> GetAllGender();
        Task<bool> DeleteGenderById(int id);
        Task<Gender> GetGenderById(int id);
    }
}
