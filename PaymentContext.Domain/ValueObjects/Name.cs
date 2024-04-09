using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects 
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            var contract = new Contract<Name>().Requires()
                .IsLowerThan(FirstName, 3, "Name.FirstName", "Invalid first name")
                .IsLowerThan(LastName, 3, "Name.LastName", "Invalid last name");
            
            AddNotifications(contract);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}