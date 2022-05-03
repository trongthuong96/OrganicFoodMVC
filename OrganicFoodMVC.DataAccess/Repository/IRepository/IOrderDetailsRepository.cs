﻿using OrganicFoodMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganicFoodMVC.DataAccess.Repository.IRepository
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        void Update(OrderDetails orderDetails);
    }
}
