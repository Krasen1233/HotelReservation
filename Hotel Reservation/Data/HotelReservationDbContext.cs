using HotelReservation.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Data
{
    public class HotelReservationDbContext : IdentityDbContext<HotelUser, IdentityRole<int>, int>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ClientReservations> ClientReservations { get; set; }

        public HotelReservationDbContext(DbContextOptions options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientReservations>(cr =>
            {
                cr.HasKey(x => new { x.ClientId, x.ReservationId });
            });
        }
    }
}
