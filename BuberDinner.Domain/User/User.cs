using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User
{
    public class User : AggregateRoot<UserId>
    {
        private User(UserId id,
            string firstName,
            string lastName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
        {
            var id = UserId.CreateUnique();
            return new(
                id,
                firstName,
                lastName,
                email,
                password,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }


    }
}
