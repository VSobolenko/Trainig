using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorsWEB.Models
{
    public class Monitor
    {
        [Key]
        public int idMonitors { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string Resolution { get; set; }
        public string ManufacturerID { get; set; }
    }
}
