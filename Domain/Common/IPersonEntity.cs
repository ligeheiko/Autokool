namespace Autokool.Domain.Common
{
    public interface IPersonEntity : IDateEntity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNr { get; }
        public string RoleTypeID { get;}
    }
    public interface IPersonEntity<out TData> : IPersonEntity, IDateEntity<TData> { }
}
