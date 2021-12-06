﻿using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CV19.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public IEnumerable<ComfirmedCount> Counts { get; set; }
    }
}
