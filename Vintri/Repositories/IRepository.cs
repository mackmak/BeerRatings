using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Vintri.Repositories
{
    public interface IBusinessRepository<T> where T: class
    {
        Task<T> FindById(int id);
        Task<IList<T>> FindByName(string name);
    }
}
