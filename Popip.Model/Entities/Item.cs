using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popip.Model.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public bool Checked { get; set; }

        [Column("Deleted")]
        public bool IsDeleted { get; set; }
        public DateTime? DetetedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
