using Autokool.Domain.Repos;
using System;

namespace Autokool.Domain.Common
{
    public static class GetRepo
    {
        public static dynamic Instance<T>() where T: IRepo<object>
        {
            throw new NotImplementedException();
        }
    }
}
