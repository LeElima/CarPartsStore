using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public int Role { get; set; }
    }
}
