using System.IO;
using System.Text.Json;
public class LinqQueries
{
  private List<Book> librosCollection = new List<Book>();

  public LinqQueries()
  {
    using (StreamReader reader = new StreamReader("books.json"))
    {
      string json = reader.ReadToEnd();
      this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
    }
  }
  public IEnumerable<Book> TodaLaColeccion()
  {
    return librosCollection;
  }
}