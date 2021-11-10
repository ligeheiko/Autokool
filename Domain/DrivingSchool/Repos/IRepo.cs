namespace Autokool.Domain.DrivingSchool.Repos
{
    public interface IRepo<TDomainObject> : ICrudMethods<TDomainObject>, ISorting, IFiltering, IPaging, IRepo
    {
    }
    public interface IRepo
    {
        object GetById(string id);
    }
}
