using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bridge
{
    public class Donar
    {
        [Key]
        public int DonorID { get; set; }
        public string? Name { get; set; }
        public string? BloodType { get; set; }
        public string? Contact { get; set; }
        
        public string? Address { get; set; }
    
    }
}
