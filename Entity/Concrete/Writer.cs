using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Writer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
