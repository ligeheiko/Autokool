using Autokool.Aids;
using Autokool.Domain.Repos;
using System.Collections.Generic;

namespace Autokool.Domain.Common
{
    public sealed class GetFrom<TRepository, TObject>
        where TRepository : IRepo<TObject>
    {

        internal TRepository repository
            => GetRepo.Instance<TRepository>();

        public TObject ById(string id)
            => Safe.Run(() => repository.Get(id).GetAwaiter().GetResult(), default(TObject));

        public IReadOnlyList<TObject> ListBy(string field, string value)
        {
            var r = repository;

            return list(r, field, value);
        }

        public IReadOnlyList<TObject> ListBy(string field, string value, string searchString)
        {
            var r = repository;
            r.SearchString = searchString;

            return list(r, field, value);
        }

        private static IReadOnlyList<TObject> list(TRepository r, string field, string value)
        {
            r.FixedFilter = field;
            r.FixedValue = value;
            r.PageIndex = -1;

            return r.Get().GetAwaiter().GetResult();
        }

    }
}
