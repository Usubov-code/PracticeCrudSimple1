using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCrudSimple.ViewModels
{
    public class VmRegister
    {
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
       
       
       
    }
}
