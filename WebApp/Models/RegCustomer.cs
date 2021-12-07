using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RegCustomer
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string mobile { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string email { get; set; }
    }
}
