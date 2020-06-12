using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DAL.Repositories.Impl
{
    class situationRepository
       : BaseRepository<situation>, ISituationRepository
    {
        internal situationRepository(orderContext context)
            : base(context)
        {

        }
    }
}