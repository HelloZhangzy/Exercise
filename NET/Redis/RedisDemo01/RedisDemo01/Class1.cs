using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo01
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Job Job { get; set; }
    }

    public class Job
    {
        public long Id { get; set; }
        public string Position { get; set; }
    }
}
