using System;
using System.Collections.Generic;
using System.Text;

namespace JBATechTest.DAL
{
    class RainData
    {
        public int RainDataID { get; set; }
        public int XRef { get; set; }
        public int YRef { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
