using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testing
    {
        [Key]
        public int TestId { get; set; }
        public string Name { get; set; }
    }
}
