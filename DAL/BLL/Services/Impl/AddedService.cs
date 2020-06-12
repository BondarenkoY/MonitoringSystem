using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using CLL.Security;
using CLL.Security.Identity;
using BILL.DTO;

namespace BLL.Services.Impl
{
    public class AddedService
        : IAddedService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public AddedService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<Added_DTO> GetAdded(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Client)
                && userType != typeof(Admin))
            {
                throw new MethodAccessException();
            }
            var AddedId = user.UserID;
            var ordsEntities =
                _database
                    .added
                    .Find(z => z.id == AddedId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<added, Added_DTO>()
                    ).CreateMapper();
            var ordsDto =
                mapper
                    .Map<IEnumerable<added>, List<Added_DTO>>(
                        ordsEntities);
            return ordsDto;
        }

        public void AddOrd(Added_DTO ord)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Client)
                || userType != typeof(Admin))
            {
                throw new MethodAccessException();
            }
            if (ord == null)
            {
                throw new ArgumentNullException(nameof(ord));
            }

            //validate(ord);  

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Added_DTO, added>()).CreateMapper();
            var ordEntity = mapper.Map<Added_DTO, added>(ord);
            _database.added.Create(ordEntity);
        }




    }
}