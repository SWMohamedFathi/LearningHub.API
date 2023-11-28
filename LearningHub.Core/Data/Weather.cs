using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Data
{
    public class Main
    {
        public string Temp { get; set; }
        public string humidity { get; set; }
    }

    public class Wind
    {
        public string speed { get; set; }
    }
    public class Weather
    {
        public string name { get; set; }
        public string timeZone { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
   


    }
}
