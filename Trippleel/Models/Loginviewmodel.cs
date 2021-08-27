using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trippleel.Models
{
    public class Loginviewmodel
    {
        [Required(ErrorMessage = "Emailaddress or Phonenumer is required!")]
        [Display(Name = "Username")]
        public string Emailaddress { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
