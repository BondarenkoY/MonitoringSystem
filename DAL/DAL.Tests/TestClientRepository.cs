using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using DAL.Repositories.Impl;
using Xunit;

namespace DAL.tests
{
    class TestClientRepository
        : BaseRepository<location>
    {
        public TestClientRepository(DbContext context)
        : base(context)
        {
        }
    }
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputStreetInstance_CalledAddMethodOfDBSetWithStreetInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<orderContext>()
                .Options;
            var mockContext = new Mock<orderContext>(opt);
            var mockDbSet = new Mock<DbSet<location>>();
            mockContext
                .Setup(context =>
                    context.Set<location>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestClientRepository(mockContext.Object);

            location expectedStreet = new Mock<location>().Object;

            //Act
            repository.Create(expectedStreet);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<orderContext>()
                .Options;
            var mockContext = new Mock<orderContext>(opt);
            var mockDbSet = new Mock<DbSet<location>>();
            mockContext
                .Setup(context =>
                    context.Set<location>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestClientRepository(mockContext.Object);

            location expectedStreet = new location() { id_location = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.id_location)).Returns(expectedStreet);

            //Act
            repository.Delete(expectedStreet.id_location);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.id_location
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<orderContext>()
                .Options;
            var mockContext = new Mock<orderContext>(opt);
            var mockDbSet = new Mock<DbSet<location>>();
            mockContext
                .Setup(context =>
                    context.Set<location>(
                        ))
                .Returns(mockDbSet.Object);

            location expectedStreet = new location() { id_location = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.id_location))
                    .Returns(expectedStreet);
            var repository = new TestClientRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.id_location);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.id_location
                    ), Times.Once());
            location.Equals(expectedStreet, actualStreet);
        }
    }
}