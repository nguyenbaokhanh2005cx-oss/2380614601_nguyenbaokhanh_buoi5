using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Buoi5.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(150)]
    [Unicode(true)]
    [Column(TypeName = "nvarchar(150)")]
    public string CategoryName { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
