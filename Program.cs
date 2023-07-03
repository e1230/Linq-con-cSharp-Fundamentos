LinqQueries queries = new LinqQueries();

//imprime todos los libros
// ImprimirValores(queries.TodaLaColeccion());

//libros antes del 2000
// ImprimirValores(queries.LibrosDespues2000());

//Imprime todos los libros tienen status
//Console.WriteLine($"Todos los libros tienen status? {queries.TodosLosLibrosTienenStatus()} ");

//Imprime si hay años publicados en 2005
//Imprime todos los libros tienen status
Console.WriteLine($"Hay libros publicados en 2005? {queries.HayLibros2005()} ");
void ImprimirValores(IEnumerable<Book> listaLibros)
{
  Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "# paginas", "Fecha publicacion");
  foreach (var item in listaLibros)
  {
    Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
  }
}