using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiThiVKT.Models
{
    public class VKTCau3
    {
        [Key]
        public string StudentID {get; set;}

        public string StudentName {get; set;}
        public string Gender {get; set;}
    }
}