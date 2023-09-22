using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Models;

namespace API.Services
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetPortfoliosAsync(string firmId, string apiToken);
    }
}
