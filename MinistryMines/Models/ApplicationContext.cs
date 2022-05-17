using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMines.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User_Detail> tbl_User_Details { get; set; }
        public DbSet<State> tbl_State { get; set; }
        public DbSet<District> tbl_District { get; set; }
        public DbSet<Title> tbl_Title { get; set; }
        public DbSet<District2> tbl_District2 { get; set; }
        public DbSet<State2> tbl_State2 { get; set; }


    }
}
