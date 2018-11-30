using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class User
    {
        [Key]
        public virtual string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
