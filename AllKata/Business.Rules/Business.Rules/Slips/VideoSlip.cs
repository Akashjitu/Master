using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Slips
{
    public class VideoSlip : ISlip
    {
        public string FreeItem { get; set; }
        public string Name { get; internal set; }
    }
}
