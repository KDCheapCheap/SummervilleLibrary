namespace SummervilleLibrary.Models.DatabaseEntities
{
    public class Book : DatabaseObject
    {
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Blurb { get; set; } = string.Empty;
    }
}
