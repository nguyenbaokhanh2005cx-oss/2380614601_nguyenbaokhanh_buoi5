namespace Buoi5.Models;

public class HomeIndexViewModel
{
    public IReadOnlyList<Book> Books { get; set; } = Array.Empty<Book>();
    public IReadOnlyList<CategoryCountViewModel> Categories { get; set; } = Array.Empty<CategoryCountViewModel>();
    public int? SelectedCategoryId { get; set; }
}
