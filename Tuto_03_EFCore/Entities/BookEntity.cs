using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuto_03_EFCore.Entities
{
    [Table("Books")]
    public class BookEntity
    {
        [Column(name:"BookId")]
        [Key]
        public int BookId { get; set; }

        [Column("Title")]
        public string Title { get; set; } = string.Empty;

        [Column("Author")]
        public string Author { get; set; } = string.Empty;

        [Column("Year")]
        public int Year { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; } = false;

    }
}
