using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sampleApi.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250),Required]
        public string? ProductName { get; set; }
        [Required]
        public long Price{ get; set; }
    }
}
