﻿using OrganicFoodMVC.DataAccess.Data;
using OrganicFoodMVC.DataAccess.Repository.IRepository;
using OrganicFoodMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganicFoodMVC.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Brand = new BrandRepository(_db);
            Product = new ProductRepository(_db);
            SP_Call = new SP_Call(_db);
            

        }

        public ICategoryRepository Category { get; private set; }
        public IBrandRepositoty Brand { get; private set; }
        public IProductRepository Product { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        // to release occupied resources - when the object is destroyed
        // giai phong tai nguyen khi doi tuong bi huy
        public void Dispose()
        {
            _db.Dispose();
        }

        // save change to database
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
