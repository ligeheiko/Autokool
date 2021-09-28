using Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public static class GetRepo
    {
        public static dynamic Instance<T>() where T: IRepo<object>
        {
            throw new NotImplementedException();
        }
    }
}
