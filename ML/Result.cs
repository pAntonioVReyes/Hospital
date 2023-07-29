using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct { get; set; }
        public string Mensaje { get; set; }
        public Exception Ex { get; set; }
        public object ResultObj { get; set; }
        public List<object> ResultObjs { get; set; }
    }
}
