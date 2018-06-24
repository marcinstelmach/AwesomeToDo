using System;

namespace AwesomeToDo.Infrastructure.Dto.Card
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CreationDateTime { get; set; }
    }
}
