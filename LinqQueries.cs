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
  /*Utilizando el operador Average retorna el promedio de caracteres que tienen los títulos de los libros*/
  public double PromedioCaracteresTitulos()
  {
    return librosCollection.Average(p => p.Title.Length);
  }
  /*Retorna todos los libros que fueron publicados a partir del año 2000 agrupados por año*/
  public IEnumerable<IGrouping<int, Book>> LibrosDesdeAño2000AgrupadosPorAño()
  {
    return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
  }
  /*Retorna un diccionario usando LookUp que permita consultar los libros de acuerdo a la letra con la que inicia cada titulo del libro*/
  public ILookup<char, Book> DiccionarioLibrosPorLetra()
  {
    return librosCollection.ToLookup(p => p.Title[0], p => p);
  }
  /*Obten una coleccion que contenga todos los libros con mas de 500 paginas y otra que contnga los libros publicados después del 2005
  Utilizando la cláusula Join, retorna los libros que esten en ambas colecciones*/
  public IEnumerable<Book> LibrosDespues2005ConMasDe500Pag()
  {
    var LibrosDespues2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);
    var LibrosMas500Paginas = librosCollection.Where(p => p.PageCount > 500);
    return LibrosDespues2005.Join(LibrosMas500Paginas, p => p.Title, x => x.Title, (p, x) => p);
  }
}