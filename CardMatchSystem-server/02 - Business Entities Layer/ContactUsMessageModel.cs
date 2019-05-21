using System;
using System.ComponentModel.DataAnnotations;

namespace CardMatch
{
    public class ContactUsMessageModel
    {
        public int id { get; set; }
        public DateTime msgDateTime { get; set; }
        public string phoneNum { get; set; }
        [RegularExpression(@"^[\w.]+@[\w.]+\.[.a-zA-Z]+$", ErrorMessage = "Email must be of the following format: ___@___.___")]
        [MaxLength(50, ErrorMessage = "Max length is 50 chars")]
        public string email { get; set; }
        [Required(ErrorMessage = "Must add your message.")]
        public string msgText { get; set; }
    }
}
