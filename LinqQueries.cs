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

  /*Utilizando el operador where retorna los libros que fueron publicados después del año 2000*/
  public IEnumerable<Book> LibrosDespues2000()
  {
    //extension method
    //return librosCollection.Where(p => p.PublishedDate.Year > 2000);
    //query method
    return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
  }
}