//using IMyWindowsFormsApp.Data.DB;
//using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    internal class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly MyDbContext _dbContext;
        private readonly DbSet<Address> addresses = null;

        public AddressRepository() : base()
        {
            _dbContext = new MyDbContext();
            addresses = _dbContext.Set<Address>();

        }
        public AddressRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            addresses = _dbContext.Set<Address>();

        }
        public override void Add(Address model)
        {
            _dbContext.Addresses.Add(model);
        }

        public override Address Get(Guid id)
        {
            Address address = new Address();
            foreach (var item in _dbContext.Addresses)
            {
                if (item.StudentId == id)
                    address = item;
            }
            return address;
        }

        public override void Remove(Address model)
        {
            Address address = _dbContext.Addresses.Find(model.Id);
            _dbContext.Addresses.Remove(address);
        }

        public override void Update(Address model)
        {
            Address oldAddress = _dbContext.Addresses.Find(model.Id);
            _dbContext.Addresses.Remove(oldAddress);
            _dbContext.SaveChanges();
            _dbContext.Addresses.Add(model);
            //_dbContext.SaveChanges();
            //_dbContext.Addresses.Attach(model);   // chi linum
            //if (model.Id > 0)
            //{
            //    _dbContext.Entry(model).State = EntityState.Modified;
            //    _dbContext.SaveChanges();
            //}
            //else
            //{
            //    _dbContext.Entry(model).State = EntityState.Added;
            //    _dbContext.SaveChanges();
            //}
        }
        public override void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
