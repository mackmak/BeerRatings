using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vintri.Models.Factories
{
    public interface IBeerFactory
    {
        public Beer CreateInstance();
    }
}
