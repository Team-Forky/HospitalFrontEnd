using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models.Interfaces
{
    public interface IResourceManager
    {
        Task<List<Resource>> GetAllResources();
        Task<Resource> GetResourceById(int id);

    }
}
