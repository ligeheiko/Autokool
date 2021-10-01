using System.Collections.Generic;

namespace Domain.Repos
{
    public interface IRepo<TDomainObject>
    {
        public TDomainObject GetById(string id);
        public List<TDomainObject> Get();
        public void Add(TDomainObject o);
        public void Delete(string id);
        public void Update(TDomainObject o);
    }
}
