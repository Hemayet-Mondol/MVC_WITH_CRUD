using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyMvc.Models;

namespace MyMvc.Data
{
    public class employeeDbcontext : DbContext
    {
        public employeeDbcontext(DbContextOptions<employeeDbcontext> options) : base(options)
        {

        }
        public DbSet<employee> employeeTable { get; set; }


    }
}
