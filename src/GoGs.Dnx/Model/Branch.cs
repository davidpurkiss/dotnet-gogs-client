using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class Branch
    {
        public string Name { get; set; }

        public Commit Commit { get; set; }
    }
}
