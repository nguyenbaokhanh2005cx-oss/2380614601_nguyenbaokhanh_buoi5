using Buoi5.Models;

namespace Buoi5.Data;

public static class SeedData
{
    public static void Initialize(BookDbContext context)
    {
        if (context.Categories.Any())
        {
            return;
        }

        var categories = new List<Category>
        {
            new() { CategoryName = "Cuộc sống" },
            new() { CategoryName = "Lập trình" },
            new() { CategoryName = "Sức khỏe" }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();

        var books = new List<Book>
        {
            new()
            {
                Title = "Cho Tôi Xin Một Vé Đi Tuổi Thơ",
                Author = "Nguyễn Nhật Ánh",
                Price = 61600,
                Description = "Tác phẩm nổi tiếng dành cho mọi lứa tuổi với nhiều cảm xúc trong trẻo.",
                Image = "https://www.nxbtre.com.vn/Images/Book/nxbtre_thumb_08142018_091438.jpg",
                CategoryId = categories[0].CategoryId
            },
            new()
            {
                Title = "Cuộc Sống Rất Giống Cuộc Đời",
                Author = "Hải Đỗ",
                Price = 61000,
                Description = "Những câu chuyện gần gũi về cuộc sống thường ngày và góc nhìn tích cực.",
                Image = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_195509_1_23751.jpg",
                CategoryId = categories[0].CategoryId
            },
            new()
            {
                Title = "Lập Trình C",
                Author = "Lê Lợi",
                Price = 89000,
                Description = "Nền tảng lập trình C cho người mới bắt đầu.",
                Image = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_195509_1_11801.jpg",
                CategoryId = categories[1].CategoryId
            }
        };

        context.Books.AddRange(books);
        context.SaveChanges();
    }
}
