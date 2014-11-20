using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Models
{
    [Table("DummyItens")]
    public class DummyItem
    {
        [Key]
        public int DummyItemID { get; set; }
        [Required]
        public string DummyDescription { get; set; }
    }
}
