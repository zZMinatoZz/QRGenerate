using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using generateqrcode.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace generateqrcode.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<DonViHanhChinh> DonViHanhChinhs { get; set; }

    }
}