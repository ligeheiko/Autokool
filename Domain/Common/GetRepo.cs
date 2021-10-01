using Domain.Repos;
using System;

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
