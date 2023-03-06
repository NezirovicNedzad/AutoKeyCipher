using AutoKeyCipher.DTOs;
using AutoKeyCipher.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.DbContexts
{
    public class AutokeyDbContext :DbContext
    {
        public AutokeyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <UserDTO> Users { get; set; }

       public DbSet<Cipher> Ciphers { get; set; }   


    }
}
