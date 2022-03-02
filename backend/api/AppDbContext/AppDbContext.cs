using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Helper;

namespace api.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Disease> Diseases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SeedDiseases(modelBuilder);
            this.SeedPersons(modelBuilder);
            this.SeedUsers(modelBuilder);
        }

        private void SeedDiseases(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disease>().HasData(
                    new Disease { Id = 1, Name = "Hipertensión arterial" },
                    new Disease { Id = 2, Name = "Tabaquismo" },
                    new Disease { Id = 3, Name = "Covid"},
                    new Disease { Id = 4, Name = "Obesidad"},
                    new Disease { Id = 5, Name = "Insuficiencia renal"},
                    new Disease { Id = 6, Name = "EPOC" },
                    new Disease { Id = 7, Name = "Leucemia" },
                    new Disease { Id = 8, Name = "Cólicos" },
                    new Disease { Id = 9, Name = "Hepatitis" },
                    new Disease { Id = 10, Name = "Sordera" }
            );
        }

        private void SeedPersons(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                    new Person { Dni = "11111111", FirstName = "Horacio", LastName = "Perez", Age = 23, Gender = "HOMBRE", Enable = true, Diabetic=false, Drive=true, Glasses=true, Diseases=null  },
                    new Person { Dni = "22222222", FirstName = "Ignacio", LastName = "Garcia", Age = 32, Gender = "HOMBRE", Enable = true, Diabetic = false, Drive = true, Glasses = true, Diseases = null },
                    new Person { Dni = "33333333", FirstName = "Rocio", LastName = "Robles", Age = 34, Gender = "MUJER", Enable = true, Diabetic = true, Drive = true, Glasses = true, Diseases = null },
                    new Person { Dni = "44444444", FirstName = "Dante", LastName = "Gomez", Age = 75, Gender = "HOMBRE", Enable = true, Diabetic = true, Drive = false, Glasses = true, Diseases = null },
                    new Person { Dni = "55555555", FirstName = "Carmen", LastName = "Rodriguez", Age = 52, Gender = "MUJER", Enable = true, Diabetic = false, Drive = true, Glasses = true, Diseases = null },
                    new Person { Dni = "66666666", FirstName = "Brian", LastName = "Ramirez", Age = 43, Gender = "HOMBRE", Enable = true, Diabetic = false, Drive = true, Glasses = false, Diseases = null },
                    new Person { Dni = "77777777", FirstName = "Lucas", LastName = "Lopez", Age = 54, Gender = "HOMBRE", Enable = true, Diabetic = false, Drive = true, Glasses = false, Diseases = null },
                    new Person { Dni = "88888888", FirstName = "Estela", LastName = "Carnivale", Age = 28, Gender = "MUJER", Enable = true, Diabetic = false, Drive = true, Glasses = false, Diseases = null },
                    new Person { Dni = "99999999", FirstName = "Patricia", LastName = "Fleita", Age = 29, Gender = "MUJER", Enable = false, Diabetic = false, Drive = true, Glasses = false, Diseases = null }
            );
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "admin1",
                        LastName = "lastNameAdmin1",
                        Email = "admin1@ficticia.com",
                        Password = EncryptHelper.GetSHA256("admin1")
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "admin2",
                        LastName = "lastNameAdmin2",
                        Email = "admin2@ficticia.com",
                        Password = EncryptHelper.GetSHA256("admin2")
                    }
            );
        }
    }
}
