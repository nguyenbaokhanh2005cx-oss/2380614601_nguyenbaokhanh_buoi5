using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Buoi5.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    [Unicode(true)]
    [Column(TypeName = "nvarchar(150)")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    [Unicode(true)]
    [Column(TypeName = "nvarchar(150)")]
    public string Author { get; set; } = string.Empty;

    [Range(0, 1_000_000_000)]
    [Column(TypeName = "decimal(18,0)")]
    public decimal Price { get; set; }

    [Required]
    [Unicode(true)]
    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    [Column(TypeName = "nvarchar(300)")]
    public string Image { get; set; } = string.Empty;

    [Display(Name = "Category")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn chủ đề.")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
