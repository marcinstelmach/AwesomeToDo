using System;
using System.Collections.Generic;
using AwesomeToDo.Domain.Data.Abstract;

namespace AwesomeToDo.Domain.Entities
{
    public class User : Entity
    {
        private List<Card> cards = new List<Card>();

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatationDateTime { get; protected set; }
        public virtual IReadOnlyCollection<Card> Cards => cards;


        protected User()
        {

        }

        public User(string firstName, string lastName, string email, string password, string salt)
        {
            SetId(Guid.NewGuid());
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password, salt);
            SetCreationDateTime(DateTime.Now);
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetPassword(string password, string salt)
        {
            Password = password;
            Salt = salt;
        }

        public void SetCreationDateTime(DateTime dateTime)
        {
            CreatationDateTime = dateTime;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }
    }
}
