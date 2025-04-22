using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.DataAccess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDBContext _db;
        public FoodTypeRepository(ApplicationDBContext db):base(db) 
        {
            _db = db;
        } 

        public void Update(FoodType foodType)
        {
            var objFromDb=_db.FoodType.FirstOrDefault(u=>u.Id == foodType.Id);
            objFromDb.Name=foodType.Name;

        }
    }
}
