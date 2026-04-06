using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuto_03_EFCore.Entities;

namespace Tuto_03_EFCore.DataBase
{
    public class AppDbContext :DbContext
    {
        private static readonly string _databaseString = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"; 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_databaseString);
            }
        }
        public DbSet<BookEntity> Books {  get; set; }
    }
}
