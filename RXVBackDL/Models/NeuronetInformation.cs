using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXVBackDL.Models.Implementations
{
    public class NeuronetInformation
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Gender { get; set; }
        public sbyte Age { get; set; }
        public string Mood { get; set; }
    }
}
