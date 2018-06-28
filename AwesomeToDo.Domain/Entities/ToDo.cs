using System;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Enums;

namespace AwesomeToDo.Domain.Entities
{
    public class ToDo : Entity
    {
        public string Title { get; protected set; }
        public DateTime CreationDateTime { get; protected set; }
        public DateTime LastModified { get; protected set; }
        public ToDoStatus Status { get; protected set; }
        public virtual Card Card { get; protected set; }

        protected ToDo()
        {

        }

        public ToDo(string title)
        {
            SetId(Guid.NewGuid());
            SetTitle(title);
            SetCreationDateTime(DateTime.Now);
            SetLastModified(DateTime.Now);
            SetStatus(ToDoStatus.New);
        }

        public void SetId(Guid id)
        {
            Id = id;
        }


        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetCreationDateTime(DateTime dateTime)
        {
            CreationDateTime = dateTime;
        }

        public void SetLastModified(DateTime dateTime)
        {
            LastModified = dateTime;
        }

        public void SetStatus(ToDoStatus status)
        {
            Status = status;
        }
    }
}
