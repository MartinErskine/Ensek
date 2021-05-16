using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensek.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    }
}
