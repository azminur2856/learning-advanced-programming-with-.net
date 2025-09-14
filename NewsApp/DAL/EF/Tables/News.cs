using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int Cid { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual Category Category { get; set; }
    }
}
