using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortFolioWork.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortFolioWork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<PortFolioWork.Models.Managers> Managers { get; set; }

    }
}
