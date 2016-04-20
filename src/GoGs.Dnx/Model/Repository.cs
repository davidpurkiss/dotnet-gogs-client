using System.Collections.Generic;

namespace Gogs.Model
{
    public class Repository
    {
        public int Id { get; set; }

        public User Owner { get; set; }

        public string Full_Name { get; set; }

        public bool Private { get; set; }

        public bool Fork { get; set; }

        public string Html_Url { get; set; }

        public string Clone_Url { get; set; }

        public string Ssh_Url { get; set; }

        public Dictionary<string, bool> Permissions { get; set; }
    }
}