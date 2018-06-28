using System;
using System.Collections.Generic;
using AwesomeToDo.Infrastructure.Dto.ToDo;

namespace AwesomeToDo.Infrastructure.Dto.Card
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CreationDateTime { get; set; }
        public IList<ToDoDto> ToDos { get; set; }
    }
}
