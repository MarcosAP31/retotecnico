namespace Backend.DTOs
{
    public class BookReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Year { get; set; }
        public string Publisher { get; set; } = null!;
        public int Pages { get; set; }
        public string Category { get; set; } = null!;
        public string? Isbn { get; set; }  // opcional
    }
}
