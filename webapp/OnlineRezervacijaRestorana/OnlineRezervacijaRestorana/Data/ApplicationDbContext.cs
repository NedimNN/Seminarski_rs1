using System;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
            Database.EnsureCreated();
        }

        public ApplicationDbContext()
        {

        }

        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<UserFollowing> UserFollowings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFollowing>()
            .HasKey(e => new { e.UserID, e.RestaurantID });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    ID = 1,
                    Role = Role.ADMIN
                },
                new UserRole
                {
                    ID = 2,
                    Role = Role.VISITOR
                },
                new UserRole
                {
                    ID = 3,
                    Role = Role.RESTAURANT_OWNER
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    Email = "ridvan_appa@hotmail.com",
                    Password = "123",
                    UserRoleID = 1
                },
                new User
                {
                    ID = 2,
                    Email = "nedim_nurkovic@fit.ba",
                    Password = "123",
                    UserRoleID = 2
                },
                new User
                {
                    ID = 3,
                    Email = "emrah_djulan@fit.ba",
                    Password = "123",
                    UserRoleID = 3
                },
                new User
                {
                    ID = 4,
                    Email = "bob_maril@wow.ba",
                    Password = "123",
                    UserRoleID = 2
                }
            );

            modelBuilder.Entity<UserData>().HasData(
                new UserData
                {
                    ID = 1,
                    FirstName = "Ridvan",
                    LastName = "Appa",
                    PhoneNumber = "061641709",
                    UserID = 1
                },
                 new UserData
                 {
                     ID = 2,
                     FirstName = "Nedim",
                     LastName = "Nurkovic",
                     PhoneNumber = "061641709",
                     UserID = 2
                 },
                  new UserData
                  {
                      ID = 3,
                      FirstName = "Emrah",
                      LastName = "Djulan",
                      PhoneNumber = "061641709",
                      UserID = 3
                  },
                   new UserData
                   {
                       ID = 4,
                       FirstName = "Bob",
                       LastName = "Maril",
                       PhoneNumber = "061641709",
                       UserID = 4
                   }
            );
            modelBuilder.Entity<Country>().HasData(
              new Country
              {
                  ID = 1,
                  Name = "Bosna i Hercegovina"

              }
          );
            modelBuilder.Entity<City>().HasData(
               new City
               {
                   ID = 1,
                   Name = "Sarajevo",
                   CountryID = 1,

               },
               new City
               {
                   ID = 2,
                   Name = "Mostar",
                   CountryID = 1,

               }
           );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    ID = 1,
                    Name = "Restoran",
                    Description = "Description...",
                    PriceRange = PriceRange.CHEAP,
                    CityId = 1,
                    City_name = "Sarajevo"
                },
                 new Restaurant
                 {
                     ID = 2,
                     Name = "Prestige",
                     Description = "Odlican restoran malo skup...",
                     PriceRange = PriceRange.EXPENSIVE,
                     CityId = 2,
                     City_name = "Mostar"
                 },
                 new Restaurant
                 {
                     ID = 3,
                     Name = "Emen",
                     Description = "Na samom ulasku u Stari Grad...",
                     PriceRange = PriceRange.MID,
                     CityId = 2,
                     City_name = "Mostar"
                 },
                 new Restaurant
                 {
                     ID = 4,
                     Name = "Megi",
                     Description = "Hrana odlicna prikladna cijeni...",
                     PriceRange = PriceRange.MID,
                     CityId = 2,
                     City_name = "Mostar"
                 },
                 new Restaurant
                 {
                     ID = 5,
                     Name = "Metropolis",
                     Description = "Restoran je odlican i u centru...",
                     PriceRange = PriceRange.MID,
                     CityId = 1,
                     City_name = "Sarajevo"
                 },
                 new Restaurant
                 {
                     ID = 6,
                     Name = "Kimono",
                     Description = "Ako volite azijsku kuhinju...",
                     PriceRange = PriceRange.EXPENSIVE,
                     CityId = 1,
                     City_name = "Sarajevo"
                 }
            );
         
            modelBuilder.Entity<Image>().HasData(
               new Image
               {
                   ID = 1,
                   Url = "https://palaisroyalrestaurant.com/wp-content/uploads/2021/06/Palais-Royal-@Guillaume-de-Laubier-Paris-50.jpg",
                   RestaurantID = 1,

               },
               new Image
               {
                   ID = 2,
                   Url = "http://www.restoran-prestige.com/wp-content/uploads/2018/01/pr2018a.jpg",
                   RestaurantID = 2,

               },
               new Image
               {
                   ID = 3,
                   Url = "https://images.pexels.com/photos/279813/pexels-photo-279813.jpeg?auto=compress&amp;cs=tinysrgb&amp;dpr=2&amp;h=640&amp;w=480",
                   RestaurantID = 3,

               },
               new Image
               {
                   ID=4,
                   Url = "https://scontent.fsjj1-1.fna.fbcdn.net/v/t1.6435-9/98001278_155127402691859_2080217815830233088_n.jpg?_nc_cat=106&ccb=1-5&_nc_sid=730e14&_nc_ohc=jgxVcoTOYBgAX-w8K17&_nc_ht=scontent.fsjj1-1.fna&oh=00_AT9Qm_XJ9xiKaqooi7hc6jciL6-szwF9uHdi-3C-KrBfTw&oe=624D39FE",
                   RestaurantID = 4,
               }
           );

            modelBuilder.Entity<Table>().HasData(
                new Table
                {
                    ID = 1,
                    SittingPlaces = 5,
                    RestaurantId = 1
                },
                new Table
                {
                    ID = 2,
                    SittingPlaces = 3,
                    RestaurantId = 1
                },
                new Table
                {
                    ID = 3,
                    SittingPlaces = 2,
                    RestaurantId = 1
                },
                new Table
                {
                    ID = 4,
                    SittingPlaces = 5,
                    RestaurantId = 2
                },
                new Table
                {
                    ID = 5,
                    SittingPlaces = 3,
                    RestaurantId = 2
                },
                new Table
                {
                    ID = 6,
                    SittingPlaces = 4,
                    RestaurantId = 2
                },
                new Table
                {
                    ID = 7,
                    SittingPlaces = 6,
                    RestaurantId = 3
                },
                new Table
                {
                    ID = 8,
                    SittingPlaces = 6,
                    RestaurantId = 3
                },
                new Table
                {
                    ID = 9,
                    SittingPlaces = 6,
                    RestaurantId = 2
                },
                new Table
                {
                    ID = 10,
                    SittingPlaces = 2,
                    RestaurantId = 3
                },
                new Table
                {
                    ID = 11,
                    SittingPlaces = 3,
                    RestaurantId = 4
                },
                new Table
                {
                    ID = 12,
                    SittingPlaces = 5,
                    RestaurantId = 4
                },
                new Table
                {
                    ID = 13,
                    SittingPlaces = 6,
                    RestaurantId = 4
                }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    ID = 1,
                    Mark = RatingMark.FOUR_STAR,
                    Comment = "Good food, nice place...",
                    InsertTime = DateTime.Parse("2005-09-01"),
                    UserID = 1,
                    RestaurantID = 1
                }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ID = 1,
                    GuestNumber = 5,
                    StartTime = DateTime.Parse("2005-09-01"),
                    EndTime = DateTime.Parse("2005-09-01"),
                    SpecialRequest = "I want plates...",
                    IsTemporary = false,
                    CreatedOn = DateTime.Now,
                    TableID = 1,
                    UserID = 1,
                    Email = "ridvan_appa@hotmail.com",
                    Number = "38761641709",
                    NotifiedReminder = true
                }
            );
        }
    }
}
