using System;
using System.IO;
using System.Text.Json;
using System.Linq;

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
  /*Utilizando el operador All verifica que todos los elementos de la coleccion tengan un valor en el campo status*/
  public bool TodosLosLibrosTienenStatus()
  {
    return librosCollection.All(p => p.Status != string.Empty);
  }

  /*Utilizando el operador Any verifica si alguno de los libros fue publicado en 2005*/
  public bool HayLibros2005()
  {
    return librosCollection.Any(p => p.PublishedDate.Year == 2005);
  }
  /*Utilizando el operador Contains retorna los elementos que pertenezcan a la categoría de Python*/
  public IEnumerable<Book> LibrosPython()
  {
    return librosCollection.Where(p => p.Categories.Contains("Python"));
  }
  /*Utilizando el operador OrderBy retorna todos los elemento que sean de la categoría de Java ordenados alfabéticamente*/
  public IEnumerable<Book> LibrosJavaOrden()
  {
    //ascendente
    return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    //descendente
    // return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.Title);
  }
  /*Utilizando el operador Take selecciona los primeros 3 libros con fecha de publicación mas reciente que esten categorizados en Java*/
  public IEnumerable<Book> LibrosOrdenadosPorFechaJava()
  {
    return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
  }
  /*Utilizando el operador Skip selecciona el tercer y cuarto libro que tengan mas de 400 páginas*/
  public IEnumerable<Book> TercerYCuartoLibrosMas400Pag()
  {
    return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
  }
  /*Utilizando el operador SELECT selecciona el titulo y el numero de paginas de los primeros 3 libros de la coleccion*/
  public IEnumerable<Book> TresPrimerosLibrosColeccion()
  {
    return librosCollection.Take(3).Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
  }
  /*Utilizando el operador Count retorna el numero de libros que tengan entre 200 y 500 paginas*/
  public int CantidadLibros200y500()
  {
    return librosCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).Count();
  }
  /*Utilizando el operador Min, retorna la menor fecha de publicación de la lista de libros*/
  public DateTime MenorFecha()
  {
    return librosCollection.Min(p => p.PublishedDate);
  }
  /*Utilizando el operador MaxBy retornar el libro con publicacion mas reciente*/
  public Book LibroConFechaPublicacionMasReciente()
  {
    return librosCollection.MaxBy(p => p.PublishedDate);
  }
  /*Retorna la suma de la cantidad de páginas de todos los libros entre 0 y 500 páginas*/
  public int SumaPaginasLibrosEntre0y500()
  {
    return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
  }
}