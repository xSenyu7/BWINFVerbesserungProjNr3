﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data
{
    internal class Ziel : IKoordinate
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PositionZ { get; set; }

        public Ziel(Schule schule)
        {
            
        }
    }
}
