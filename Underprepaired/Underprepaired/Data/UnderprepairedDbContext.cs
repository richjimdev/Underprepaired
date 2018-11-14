using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Data
{
    public class UnderprepairedDbContext : DbContext
    {
        public UnderprepairedDbContext(DbContextOptions<UnderprepairedDbContext> options) : base(options)
        {

        }
    }
}
