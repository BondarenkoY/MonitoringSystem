using System;
using System.Collections.Generic;
using System.Text;
using BILL.DTO;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IAddedService
    {
        IEnumerable<Added_DTO> GetAdded(int page);
    }
}