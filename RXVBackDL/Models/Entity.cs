using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXVBackDL.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        protected Entity()
        {
            Id = -1;
        }
        public bool IsNew()
        {
            return Id == -1;
        }
    }
}
