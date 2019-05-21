using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class UserDetailsModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Missing Full Name.")]
        public string fullName { get; set; }
        [Required(ErrorMessage = "Missing User Name.")]
        [MinLength(6, ErrorMessage = "min legth at least 6 charcters")]
        [MaxLength(20, ErrorMessage = "Max length is 20 chars")]
        public string userName { get; set; }
        [MinLength(6, ErrorMessage = "min legth at least 6 charcters")]
        [MaxLength(20, ErrorMessage = "Max length is 20 chars")]
        [Required(ErrorMessage = "Missing Password.")]
        public string password { get; set; }
        [RegularExpression(@"^[\w.]+@[\w.]+\.[.a-zA-Z]+$", ErrorMessage = "Email must be of the following format: ___@___.___")]
        public string email { get; set; }
        public DateTime ?birthDate { get; set; }
    }
}
