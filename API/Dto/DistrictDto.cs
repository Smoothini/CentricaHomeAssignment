﻿using System.ComponentModel.DataAnnotations;

namespace API.Dto
{
    /// <summary>
    /// District Data Transfer Object
    /// </summary>
    public class DistrictDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PSPID { get; set; }
        public string PSPName { get; set; }
        public int SSPCount { get; set; }
    }
}
