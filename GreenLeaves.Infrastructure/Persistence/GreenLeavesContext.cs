using GreenLeaves.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Infrastructure.Persistence
{
    public class GreenLeavesContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }

        public GreenLeavesContext(DbContextOptions<GreenLeavesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var country = new Country
            {
                Id=1,
                Name = "Colombia"
            };

            builder.Entity<Country>().HasData(country);

            List<State> stateList = new List<State>() {
                new State() {Id=1, Name = "Amazonas" ,IdCountry=1},
                new State() {Id=2, Name = "Antioquia" ,IdCountry=1},
                new State() {Id=3, Name = "Arauca" ,IdCountry=1},
                new State() {Id=4, Name = "Atlántico" ,IdCountry=1},
                new State() {Id=5, Name = "Bogotá" ,IdCountry=1},
                new State() {Id=6, Name = "Bolívar",IdCountry=1 },
                new State() {Id=7, Name = "Boyacá",IdCountry=1 },
                new State() {Id=8, Name = "Caldas",IdCountry=1 },
                new State() {Id=9, Name = "Caquetá",IdCountry=1 },
                new State() {Id=10, Name = "Casanare",IdCountry=1 }
              
            };

            builder.Entity<State>().HasData(stateList);

            List<City> cityList = new List<City>() {
                new City() {Id=1, Name="Leticia", IdState = 1 ,IdCountry=1},
                new City() {Id=2, Name="Medellín",IdState = 2 ,IdCountry=1},
                new City() {Id=3, Name="Arauca",IdState = 3 ,IdCountry=1},
                new City() {Id=4, Name="Barranquilla",IdState = 4 ,IdCountry=1},
                new City() {Id=5, Name="Bogotá",IdState = 5 ,IdCountry=1},
                new City() {Id=6, Name="Cartagena",IdState = 6,IdCountry=1 },
                new City() {Id=7, Name="Tunja",IdState = 7,IdCountry=1 },
                new City() {Id=8, Name="Manizales",IdState = 8,IdCountry=1 },
                new City() {Id=9, Name="Florencia",IdState = 9,IdCountry=1 },
                new City() {Id=10, Name="Yopal",IdState = 10,IdCountry=1 }

            };

            builder.Entity<City>().HasData(cityList);

            base.OnModelCreating(builder);

        }
    }
}
