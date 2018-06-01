using System;
using System.Collections.Generic;
using AwesomeToDo.Domain.Data.Abstract;

namespace AwesomeToDo.Domain.Entities
{
    public class Card : Entity
    {
        private List<ToDo> toDos = new List<ToDo>();

        public string Title { get; protected set; }
        public DateTime CreationDateTime { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual IReadOnlyCollection<ToDo> ToDos => toDos;

        protected Card()
        {
        }

        public Card(string title)
        {
            SetId(Guid.NewGuid());
            SetTitle(title);
            SetCreatonDateTime(DateTime.Now);
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetCreatonDateTime(DateTime dateTime)
        {
            CreationDateTime = dateTime;
        }

        public void AddToDo(ToDo toDo)
        {
            toDos.Add(toDo);
        }
    }
}
