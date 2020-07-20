using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vintri.Models.Factories
{
    public class BeerFactory : IBeerFactory
    {
        public Beer CreateInstance()
        {
             return new Beer(); 
        }
    }
}
