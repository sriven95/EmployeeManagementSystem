// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

var movies = new List<MovieTutorial.Movie>
{
    new MovieTutorial.Movie { Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Rating = 8.8, Price = 10 },
    new MovieTutorial.Movie { Title = "The Shawshank Redemption", Genre = "Drama", ReleaseYear = 1994, Rating = 9.3, Price = 12 },
    new MovieTutorial.Movie { Title = "The Matrix", Genre = "Sci-Fi", ReleaseYear = 1999, Rating = 8.7, Price = 9 },
    new MovieTutorial.Movie { Title = "Parasite", Genre = "Thriller", ReleaseYear = 2019, Rating = 8.6, Price = 11 },
    new MovieTutorial.Movie { Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Rating = 8.6, Price = 13 }
};

List<string> movieTitle = movies.Select(movie => movie.Title).ToList();

foreach (var movie in movieTitle)
{
    Console.WriteLine(movie);
}

var SciFiMovies = movies.Where(movie => movie.Genre == "Sci-Fi").ToList();
Console.WriteLine("\nSci-Fi Movies:");
foreach (var movie in SciFiMovies)
{
    Console.WriteLine(movie.Title);
}

var latestMovies = movies.Any(movie => movie.ReleaseYear >= 2021);
Console.WriteLine($"Any Latest Movies {latestMovies}");

Console.WriteLine("\nHigh Rated Movies:");


var sortedMoviesByRating = movies.OrderByDescending(movie => movie.Rating).ToList();

foreach (var movie in sortedMoviesByRating)
{
    Console.WriteLine($"{movie.Title} - Rating: {movie.Rating}");
}
Console.WriteLine("\nLow Rated Movies:");

var sortedMoviesByLowRating = movies.OrderBy(movie => movie.Rating).ToList();

foreach (var movie in sortedMoviesByLowRating)
{
    Console.WriteLine($"{movie.Title} - Rating: {movie.Rating}");
}

var avgRating = movies.Average(movie => movie.Rating);
Console.WriteLine($"\nAverage Rating of Movies: {avgRating}");

var maxRating = movies.Max(movies => movies.Rating);
Console.WriteLine($"Max Rating of Movies: {maxRating}");

var bestRatedMovie = movies.First(movie => movie.Rating == maxRating);
Console.WriteLine($"Best Rated Movie: {bestRatedMovie?.Title} - Rating: {bestRatedMovie?.Rating}");

var minRating = movies.Min(movies => movies.Rating);
Console.WriteLine($"Min Rating of Movies: {minRating}");

var worstRatedMovie = movies.FirstOrDefault(movie => movie.Rating == minRating);
Console.WriteLine($"Worst Rated Movie: {worstRatedMovie?.Title} - Rating: {worstRatedMovie?.Rating}");

var groupMoviesByGenre = movies.GroupBy(movie => movie.Genre);
foreach (var group in groupMoviesByGenre)
{
    Console.WriteLine($"\nMovies in Genre: {group.Key}");
    foreach (var movie in group)
    {
        Console.WriteLine($"{movie.Title} - Rating: {movie.Rating}");
    }
}
Console.WriteLine("\nBudget Thriller Movies (Price < $15):");
var budgetThrillerMovies = movies.Where(movie => movie.Genre == "Thriller" && movie.Price < 15).
                            OrderBy(movie => movie.Rating).
                            Select(movie => $"{movie.Title}-{movie.Rating}").ToList();

foreach (var budget in budgetThrillerMovies)
{
    Console.WriteLine(budget);
}

Console.WriteLine("\nPaged Movies (Skip 1, Take 3):");
var pagedMovies = movies.Skip(1).Take(3).ToList();
foreach (var item in pagedMovies)
{
    Console.WriteLine(item.Title);
}

var ThrillerMovies = movies.Where(movie => movie.Genre == "Thriller").ToList();

Console.WriteLine("\nThriller Movies By Query:");

var ThrillerMoviesQuery = from g in  ThrillerMovies
                          where g.Genre == "Thriller"
                          select g;
foreach (var item in ThrillerMoviesQuery)
{
    Console.WriteLine(item.Title);
}

var cheapMovies = movies.OrderBy(movie => movie.Price).First();
Console.WriteLine($"\nCheapest Movie: {cheapMovies.Title}");

Console.WriteLine("\nDistinct Genres:");
var distinctGenres = movies.Select(movie => movie.Genre).Distinct();
foreach (var genre in distinctGenres)
{
    Console.WriteLine(genre);
}
