using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QRMenuAPI.Models;

namespace QRMenuAPI.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Column(TypeName = "nvarchar(100)")]
        public required string Name { get; set; } = "";

        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }

        [Column(TypeName = "tinyint")]
        public byte StateId { get; set; }
        [ForeignKey("StateId")]  
        public State? State { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        //fotoğraf ve indirim yazılacak
    }
}