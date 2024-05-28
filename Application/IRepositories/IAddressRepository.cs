﻿using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<Pagination<Address>> GetAccountAddressByAccountIdAsync(string accountId, int pageSize, int pageIndex);

    }
}
