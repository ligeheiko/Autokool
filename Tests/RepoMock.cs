using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests
{
    internal class RepoMock<TDomainObject> : IRepo<TDomainObject> 
        where TDomainObject: IUniqueEntity
    {
        private readonly List<TDomainObject> list = new();

        public string SortOrder { get; set;}
        public string SearchString { get; set;}
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPreviousPage { get; set; }

        public string ErrorMessage => throw new NotImplementedException();

        public TDomainObject EntityInDb => throw new NotImplementedException();

        public async Task Add(TDomainObject obj)
        {
            await Update(obj);
        }

        public async Task Delete(string id)
        {
            var item = await Get(id);
            if (item is not null )list.Remove(item);
        }

        public Task<List<TDomainObject>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<TDomainObject> Get(string id)
        {
            await Task.CompletedTask;
            return (TDomainObject)GetById(id);
        }

        public object GetById(string id)
        {
            return list.Find(x => x.ID == id);
        }

        public async Task Update(TDomainObject obj)
        {
            if (obj is not null)
            {
                await Delete(obj.ID);
                list.Add(obj);
            }
        }
    }
}
