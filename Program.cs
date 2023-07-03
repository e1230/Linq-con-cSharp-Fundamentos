LinqQueries queries = new LinqQueries();

//imprime todos los libros
// ImprimirValores(queries.TodaLaColeccion());

//libros antes del 2000
ImprimirValores(queries.LibrosDespues2000());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
  Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "# paginas", "Fecha publicacion");
  foreach (var item in listaLibros)
  {
    Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
  }
}