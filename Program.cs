﻿LinqQueries queries = new LinqQueries();

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
Console.WriteLine(queries.CantidadLibros200y500());
void ImprimirValores(IEnumerable<Book> listaLibros)
{
  Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "# paginas", "Fecha publicacion");
  foreach (var item in listaLibros)
  {
    Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
  }
}