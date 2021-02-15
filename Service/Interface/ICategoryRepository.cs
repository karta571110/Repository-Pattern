using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels.Models;
using EntityModels.ViewModels;
using Service.Models.Interface;
namespace Service.Interface
{
    public interface ICategoryRepository : IRepository<whatever>
    {
        whatever GetByID(int categoryID);
    }
}
