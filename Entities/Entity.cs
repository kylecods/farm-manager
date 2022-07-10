using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Entity 
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public void SetNewId()
        {
            Id = Guid.NewGuid();
        }
    }
}
