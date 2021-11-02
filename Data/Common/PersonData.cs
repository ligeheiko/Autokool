namespace Autokool.Data.Common
{
    public abstract class PersonData : DateData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
    }
}
