namespace SummervilleLibrary.DTOs
{
    public class CreateBookDTO
    {
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int PublicationYear { get; set; } = 0;
    }
}
