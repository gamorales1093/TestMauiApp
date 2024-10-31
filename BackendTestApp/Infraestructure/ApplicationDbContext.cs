using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using BackendTestApp.Models.Entities;

namespace BackendTestApp.Infraestructure
{
    public class ApplicationDbContext : DbContext // si se requiere agregar campos a la usuario de Identity
                                                                         // se debe especificar el <IdentityUser> y a la clase custom con los campos adicionales heredar de IdentityUser
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Types> Types { get; set; }
    }

}
