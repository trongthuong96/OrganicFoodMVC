using System;
using System.Collections.Generic;
using System.Text;

namespace OrganicFoodMVC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        IBrandRepositoty Brand { get; }

        IProductRepository Product { get; }

        ISP_Call SP_Call { get; }

        void Save();
    }
}
