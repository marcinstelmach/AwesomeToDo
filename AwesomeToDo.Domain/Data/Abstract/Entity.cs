using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeToDo.Domain.Data.Abstract
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
