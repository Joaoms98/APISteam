using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISteam.Web.FormRequest
{
    public class UpdateUserFormRequest 
    {
        public string NickName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Resume { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
    }
}