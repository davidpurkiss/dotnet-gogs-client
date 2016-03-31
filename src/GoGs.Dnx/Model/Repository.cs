using System.Collections.Generic;

namespace Gogs.Model
{
    public class Repository
    {
        public int Id { get; set; }

        public User Owner { get; set; }

        public string FullName { get; set; }

        public bool Private { get; set; }

        public bool Fork { get; set; }

        public string HtmlUrl { get; set; }

        public string CloneUrl { get; set; }

        public string SshUrl { get; set; }

        public Dictionary<string, bool> Permissions { get; set; }
    }
}