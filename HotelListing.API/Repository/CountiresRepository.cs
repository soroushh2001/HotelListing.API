﻿using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class CountiresRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;

        public CountiresRepository(HotelListingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int? id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
