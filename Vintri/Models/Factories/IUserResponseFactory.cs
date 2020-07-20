using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vintri.Models.Factories
{
    public interface IUserResponseFactory
    {
        public UserResponse CreateInstance(int id, string name, string description, IList<UserJson> userRatings);
    }
}
