LinqQueries queries = new LinqQueries();

//imprime todos los libros
// ImprimirValores(queries.TodaLaColeccion());

//libros antes del 2000
// ImprimirValores(queries.LibrosDespues2000());

//Imprime todos los libros tienen status
//Console.WriteLine($"Todos los libros tienen status? {queries.TodosLosLibrosTienenStatus()} ");

//Imprime si hay años publicados en 2005
// Console.WriteLine($"Hay libros publicados en 2005? {queries.HayLibros2005()} ");

//Imprime Libros que tienen como categoria python
// ImprimirValores(queries.LibrosPython());

//Libros de java ordenados por nombre
// ImprimirValores(queries.LibrosJavaOrden());

//3 Libros mas recientes de java.
// ImprimirValores(queries.LibrosOrdenadosPorFechaJava());

//Tercer y Cuarto libro con mas de 400 paginas
// ImprimirValores(queries.TercerYCuartoLibrosMas400Pag());

//Tres primeros libros filtrados con Select
// ImprimirValores(queries.TresPrimerosLibrosColeccion());

//Cantidad de libros que tienen entre 300 y 500 paginas
// Console.WriteLine(queries.CantidadLibros200y500());

//Fecha de publicacion menor de todos los libros
// Console.WriteLine(queries.MenorFecha());

//Libro con fecha mas reciente
// Book libro = queries.LibroConFechaPublicacionMasReciente();
// Console.WriteLine($"{libro.Title} - {libro.PublishedDate.ToShortDateString()}");

//Suma de paginas libros de 0 a 500 paginas
// Console.WriteLine(queries.SumaPaginasLibrosEntre0y500());

//Promedio de caracteres de titulos de libros
// Console.WriteLine(queries.PromedioCaracteresTitulos());

//Libros publicados a partir del 2000 agrupados por año
//ImprimirGrupo(queries.LibrosDesdeAño2000AgrupadosPorAño());

//Diccionario de libros por letra
var grupo = queries.DiccionarioLibrosPorLetra();
ImprimirDiccionario(grupo, 'A');
void ImprimirValores(IEnumerable<Book> listaLibros)
{
  Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "# paginas", "Fecha publicacion");
  foreach (var item in listaLibros)
  {
    Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
  }
}
void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
  foreach (var grupo in ListadeLibros)
  {
    Console.WriteLine("");
    Console.WriteLine($"Grupo: {grupo.Key}");
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in grupo)
    {
      Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }
  }
}
void ImprimirDiccionario(ILookup<char, Book> listBooks, char letter)
{
  char letterUpper = Char.ToUpper(letter);
  if (listBooks[letterUpper].Count() == 0)
  {
    Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
  }
  else
  {
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
    foreach (var book in listBooks[letterUpper])
    {
      Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
  }
}