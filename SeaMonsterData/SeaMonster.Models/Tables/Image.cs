﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Models.Tables
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int PostId { get; set; }
    }
}
