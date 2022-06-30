using BBA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BBA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedUsers(modelBuilder);
            SeedBooks(modelBuilder);
        }
        private void SeedBooks(ModelBuilder builder)
        {
            Book firstBook = new Book()
            {
                BookID = 1,
                BookImage = "e43bf711-67bd-48cb-992c-9e95488492c9-9781948226448_grande.webp",
                Title = "The Crying Book",
                Author = "Heather Christle",
                Publisher = "Catapult",
                Genre = "Other",
                Description = "Award-winning poet Heather Christle has just lost a dear friend to suicide and must reckon with her own struggles with depression and the birth of her first child. How she faces her joy, grief, anxiety, impending motherhood, and conflicted truce with the world results in a moving meditation on the nature, rapture, and perils of crying―from the history of tear-catching gadgets (including the woman who designed a gun that shoots tears) to the science behind animal tears (including moths who drink them) to the fraught role of white women's tears in racist violence."
            };

            Book secondBook = new Book()
            {
                BookID = 2,
                BookImage = null,
                Title = "Sample Book",
                Author = "Tester",
                Publisher = "Paper company",
                Genre = "Crime",
                Description = "Some description here."
            };

            builder.Entity<Book>().HasData(firstBook);
            builder.Entity<Book>().HasData(secondBook);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "admin@bba.co.nz",
                NormalizedUserName = "ADMIN@BBA.CO.NZ",
                NormalizedEmail = "ADMIN@BBA.CO.NZ",
                Email = "admin@bba.co.nz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "123456789"
            };

            ApplicationUser customer = new ApplicationUser()
            {
                UserName = "customer@bba.co.nz",
                NormalizedUserName = "CUSTOMER@BBA.CO.NZ",
                NormalizedEmail = "CUSTOMER@BBA.CO.NZ",
                Email = "customer@bba.co.nz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false
            };

            admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Admin123`");
            customer.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(customer, "Cust123`");

            builder.Entity<ApplicationUser>().HasData(admin);
            builder.Entity<ApplicationUser>().HasData(customer);
        }
    }
}