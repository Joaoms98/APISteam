using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISteam.Domain.Inputs
{
    public class UserDeleteInput
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
    }
}