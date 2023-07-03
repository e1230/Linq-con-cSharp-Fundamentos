public class Book
{    
    public string Title { get; set; } = "";
    public int PageCount { get; set; } = 0;
    public DateTime PublishedDate { get; set; }
    public DateTime ThumbNailUrl { get; set; }
    public string ShortDescription { get; set; } = "";
    public string Status { get; set; } = "";
    public string[] Authors { get; set; } = Array.Empty<string>();
    public string[] Categories { get; set; } = Array.Empty<string>();
}