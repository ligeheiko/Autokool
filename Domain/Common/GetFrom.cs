using Autokool.Aids;
using Autokool.Domain.DrivingSchool.Repos;
using System.Collections.Generic;

namespace Autokool.Domain.Common
{
    public sealed class GetFrom<TIRepository, TObject>
        where TIRepository : IRepo<TObject>
    {

        internal TIRepository repository
            => GetRepo.Instance<TIRepository>();

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

        private static IReadOnlyList<TObject> list(TIRepository r, string field, string value)
        {
            r.FixedFilter = field;
            r.FixedValue = value;
            r.PageIndex = -1;

            return r.Get().GetAwaiter().GetResult();
        }

    }
}
