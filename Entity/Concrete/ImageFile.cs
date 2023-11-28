using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ImageFile
    {
        [Key]
        public int ImageId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Path { get; set; }
    }
}
