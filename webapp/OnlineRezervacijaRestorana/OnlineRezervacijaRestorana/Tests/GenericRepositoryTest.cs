using Moq;
using NUnit.Framework;
using Online_Rezervacija_Restorana.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Repository;
using System.Collections.Generic;

namespace Online_Rezervacija_Restorana.Tests
{
    [TestFixture]
    public class GenericRepositoryTest
    {
        [Test]
        public void FetchUserRolesTest()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<UserRole> userRoles = new List<UserRole>
            {
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

            }.AsQueryable();

            // To query our database we need to implement IQueryable 
            Mock<DbSet<UserRole>> mockSet = new Mock<DbSet<UserRole>>();
            mockSet.As<IQueryable<UserRole>>().Setup(m => m.Provider).Returns(userRoles.Provider);
            mockSet.As<IQueryable<UserRole>>().Setup(m => m.Expression).Returns(userRoles.Expression);
            mockSet.As<IQueryable<UserRole>>().Setup(m => m.ElementType).Returns(userRoles.ElementType);
            mockSet.As<IQueryable<UserRole>>().Setup(m => m.GetEnumerator()).Returns(userRoles.GetEnumerator());

            Mock<ApplicationDbContext> mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Set<UserRole>()).Returns(mockSet.Object);

            // Act - fetch user roles
            UserRoleRepository roleRepository = new UserRoleRepository(mockContext.Object);
            IList<UserRole> actual = roleRepository.GetPaged(1).Results;

            // Asset
            // Ensure that 3 roles are returned and
            // the first is Role.ADMIN
            Assert.AreEqual(3, actual.Count());
            Assert.AreEqual(Role.ADMIN, actual.First().Role);
        }
    }
}
