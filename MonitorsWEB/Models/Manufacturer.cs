using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorsWEB.Models
{
    public class Manufacturer
    {
        [Key]
        public int idManufacturer { get; set; }
        public string Brend { get; set; }
    }
}
