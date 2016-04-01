using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Full_Name { get; set; }

        public string Email { get; set; }

        public string Avatar_Url { get; set; }
    }
}
