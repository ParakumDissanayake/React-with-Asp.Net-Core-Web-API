using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RegistrationDBContext : DbContext
    {
        public RegistrationDBContext(DbContextOptions<RegistrationDBContext> options) : base(options)
        {

        }
        public DbSet<RegCustomer> RegCustomers { get; set; }
    }
}
