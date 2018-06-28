using System;
using System.Collections.Generic;
using System.Text;
using AwesomeToDo.Domain.Enums;

namespace AwesomeToDo.Infrastructure.Dto.ToDo
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CreationDateTime { get; set; }
        public string LastModified { get; set; }
        public ToDoStatus Status { get; set; }
    }
}
