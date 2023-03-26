using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyOnline.Shared.Models
{
    public class Element
    {
        [Key]
        public int Nr { get; set; }
        public string Sign { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public double MolarMass { get; set; }
    }
}

