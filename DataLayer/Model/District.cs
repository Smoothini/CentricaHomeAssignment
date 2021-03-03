﻿using System.Collections.Generic;
namespace DataLayer.Model
{
    public class District
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PSPID { get; set; }
        public string PSPName { get; set; }
        public int SSPCount { get; set; }
    }
}
