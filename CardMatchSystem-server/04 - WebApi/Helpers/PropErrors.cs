using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//this class will holds messages for   cases of validation error/s. For example: valdate user name.
namespace CardMatch
{
    public class PropErrors
    {
        //propery name
        public string property { get; set; }
        //all errors of this property
        public List<string> errors { get; set; } = new List<string>();
    }
}