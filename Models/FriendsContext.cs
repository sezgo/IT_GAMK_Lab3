using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace IT_GAMK_Lab3.Models
{
    public class FriendsContext : DbContext
    {
        public DbSet<Friend> friends { get; set; }
        public FriendsContext() : base("DefaultConnection")
        {
        }

        public static FriendsContext Create()
        {
            return new FriendsContext();
        }
    }
}