using Moq;
using NUnit.Framework;
using Online_Rezervacija_Restorana.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Repository;
using System.Collections.Generic;
using System;
using Online_Rezervacija_Restorana.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Online_Rezervacija_Restorana.Tests
{
	[TestFixture]
	public class ReservationTest
	{
		[Test]
		public void GetAvailableTableTest()
		{
			// Arrange - We're mocking our dbSet & dbContext
			// in-memory data
			IQueryable<Table> tables = new List<Table>
			{
				new Table
				{
					ID = 1,
					SittingPlaces = 3
				},
				new Table
				{
					ID = 2,
					SittingPlaces = 3

				},
				new Table
				{
					ID = 3,
					SittingPlaces = 3
				}

			}.AsQueryable();

			IQueryable<Reservation> reservations = new List<Reservation>
			{
				new Reservation
				{
					ID = 1,
					GuestNumber = 3,
					StartTime = DateTime.Now.AddHours(-2),
					EndTime = DateTime.Now,
					SpecialRequest = "None",
					IsTemporary = false,
					CreatedOn = DateTime.Now.AddHours(-10),
					TableID = 1,
					Table = tables.First(),
					UserID = 1,
					User = new User()
				}

			}.AsQueryable();

			IQueryable<Restaurant> restaurants = new List<Restaurant>
			{
				new Restaurant
				{
					ID = 1,
					Name = "Restoran",
					Description = "Description",
					PriceRange = PriceRange.EXPENSIVE,
					Ratings = new List<Rating>(),
					Tables = tables.ToList()
				}

			}.AsQueryable();

            tables.ToList().ForEach(table =>
            {
                table.RestaurantId = 1;
                table.Reservations = new List<Reservation>();
                table.Reservations.Add(reservations.First());
                table.Restaurant = restaurants.First();
            });

			// To query our database we need to implement IQueryable 
			Mock<DbSet<Table>> mockTableSet = new Mock<DbSet<Table>>();
			mockTableSet.As<IQueryable<Table>>().Setup(m => m.Provider).Returns(tables.Provider);
			mockTableSet.As<IQueryable<Table>>().Setup(m => m.Expression).Returns(tables.Expression);
			mockTableSet.As<IQueryable<Table>>().Setup(m => m.ElementType).Returns(tables.ElementType);
			mockTableSet.As<IQueryable<Table>>().Setup(m => m.GetEnumerator()).Returns(tables.GetEnumerator());

			// To query our database we need to implement IQueryable 
			Mock<DbSet<Reservation>> mockReservationSet = new Mock<DbSet<Reservation>>();
			mockReservationSet.As<IQueryable<Reservation>>().Setup(m => m.Provider).Returns(reservations.Provider);
			mockReservationSet.As<IQueryable<Reservation>>().Setup(m => m.Expression).Returns(reservations.Expression);
			mockReservationSet.As<IQueryable<Reservation>>().Setup(m => m.ElementType).Returns(reservations.ElementType);
			mockReservationSet.As<IQueryable<Reservation>>().Setup(m => m.GetEnumerator()).Returns(reservations.GetEnumerator());

			// To query our database we need to implement IQueryable 
			Mock<DbSet<Restaurant>> mockRestaurantsSet = new Mock<DbSet<Restaurant>>();
			mockRestaurantsSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
			mockRestaurantsSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
			mockRestaurantsSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
			mockRestaurantsSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

			Mock<ApplicationDbContext> mockContext = new Mock<ApplicationDbContext>();
			mockContext.Setup(c => c.Set<Table>()).Returns(mockTableSet.Object);
			mockContext.Setup(c => c.Set<Restaurant>()).Returns(mockRestaurantsSet.Object);
			mockContext.Setup(c => c.Set<Reservation>()).Returns(mockReservationSet.Object);

            mockContext.Setup(c => c.Tables).Returns(mockTableSet.Object);
            mockContext.Setup(c => c.Restaurants).Returns(mockRestaurantsSet.Object);
            mockContext.Setup(c => c.Reservations).Returns(mockReservationSet.Object);

            ITableRepository tableRepository = new TableRepository(mockContext.Object);

			Assert.AreEqual(1, tableRepository.GetAvailableTable(3, 1, DateTime.Now, DateTime.Now.AddHours(3)).ID);
        }
	}
}
