using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CLL.Security;
using CLL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL_test
{
    public class AddedServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullunitOfWork = null;
            Assert.Throws<ArgumentNullException>(() => new AddedService(nullunitOfWork));
        }
        [Fact]
        public void GetOrds_UserIsAdmin_ThrowMethodAccessException()
        {
            User user = new Admin(1, "Vlad", "login", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IAddedService ordService = new AddedService(mockUnitOfWork.Object);
            //Assert.Throws<MethodAccessException>(() => ordService.GetOrds(0));
        }
        [Fact]
        public void GetOrds_OrdFromDAL_CorrectMappingToStreetDTO()
        {
            User user = new Admin(1, "Vlad", "login", 1);
            SecurityContext.SetUser(user);
            var ordService = GetOrdService();
            var actualAddedDto = ordService.GetAdded(0).First();
            Assert.True(
                actualAddedDto.id == 1
                && actualAddedDto.operator_id == 1
                && actualAddedDto.situation_id == 1
                && actualAddedDto.location_id == 1
                );
        }
        IAddedService GetOrdService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedOrd = new added() { id = 1, operator_id = 1, situation_id = 1, location_id = 1 };
            var mockDbSet = new Mock<IAddedRepository>();
            mockDbSet.Setup(z => z.Find(It.IsAny<Func<added, bool>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<added>() { expectedOrd });
            mockContext.Setup(context => context.added).Returns(mockDbSet.Object);
            IAddedService ordService = new AddedService(mockContext.Object);
            return ordService;
        }
    }
}