using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ApiDotflix.Data
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new DotflixDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DotflixDbContext>>());

            if (context.Movie.Any())
            {
                return;
            }

            context.Language.AddRange(
                new Language
                {
                    LanguageId = 100,
                    Name = "Portugês"
                },
                new Language
                {
                    LanguageId = 101,
                    Name = "Inglês"
                },
                new Language
                {
                    LanguageId = 102,
                    Name = "Chinês"
                },
                new Language
                {
                    LanguageId = 103,
                    Name = "Espanhol"
                },
                new Language
                {
                    LanguageId = 104,
                    Name = "Árabe"
                },
                new Language
                {
                    LanguageId = 105,
                    Name = "Russo"
                },
                new Language
                {
                    LanguageId = 106,
                    Name = "Urdu"
                },
                new Language
                {
                    LanguageId = 107,
                    Name = "Coreano"
                },
                new Language
                {
                    LanguageId = 108,
                    Name = "Alemão"
                },
                new Language
                {
                    LanguageId = 109,
                    Name = "Frabcês"
                });

            context.Keyword.AddRange(
                new Keyword
                {
                    Id = 100,
                    Name = "Fascinante"
                },
                new Keyword
                {
                    Id = 101,
                    Name = "Provocante"
                },
                new Keyword
                {
                    Id = 102,
                    Name = "Crime Verídico"
                },
                new Keyword
                {
                    Id = 103,
                    Name = "Mistério"
                },
                new Keyword
                {
                    Id = 104,
                    Name = "Realistas"
                });

            context.Movie.AddRange(
                new Movie
                {
                    MovieId = 100,
                    AgeGroup = "18",
                    Image = "img2",
                    ReleaseData = new DateTime(2021, 5, 10).ToString("dd/MM/yyyy"),
                    RunTime = new DateTime(1, 1, 1, 2, 15, 20).ToString("H:mm:ss"),
                    Sinopse = "uma sinopse",
                    Title = "um filme",
                    Relevance = 45,
                    Register = DateTime.Now.Date.ToString("dd/MM/yyyy")
                },
                new Movie
                {
                    MovieId = 101,
                    AgeGroup = "10",
                    Image = "img1",
                    ReleaseData = new DateTime(2021, 5, 10).ToString("dd/MM/yyyy"),
                    RunTime = new DateTime(1, 1, 1, 2, 20, 20).ToString("H:mm:ss"),
                    Sinopse = "outra sinopse",
                    Title = "outro filme",
                    Relevance = 15,
                    Register = DateTime.Now.ToString("dd/MM/yyyy")
                }
            );

            context.About.AddRange(
                new About
                {
                    AboutId = 100,
                    MovieId = 100,
                    DirectorId = 100
                },
                new About
                {
                    AboutId = 101,
                    MovieId = 101,
                    DirectorId = 101
                });

            context.AboutKeyword.AddRange(
                new AboutKeyword
                {
                    AboutId = 100,
                    KeywordId = 100
                },
                new AboutKeyword
                {
                    AboutId = 101,
                    KeywordId = 100
                },
                new AboutKeyword
                {
                    AboutId = 101,
                    KeywordId = 101
                });

            context.AboutLanguage.AddRange(
                new AboutLanguage
                {
                    AboutId = 100,
                    LanguageId = 100
                },
                new AboutLanguage
                {
                    AboutId = 101,
                    LanguageId = 100
                },
                new AboutLanguage
                {
                    AboutId = 101,
                    LanguageId = 101
                });

            context.Genre.AddRange(
                new Genre
                {
                    Id = 100,
                    Name = "Ação"
                },
                new Genre
                {
                    Id = 101,
                    Name = "Aventura"
                },
                new Genre
                {
                    Id = 102,
                    Name = "Cinema de Arte"
                },
                new Genre
                {
                    Id = 103,
                    Name = "Comédia"
                },
                new Genre
                {
                    Id = 104,
                    Name = "Dança"
                });

            context.AboutGenre.AddRange(
                new AboutGenre
                {
                    AboutId = 100,
                    GenreId = 100
                },
                new AboutGenre
                {
                    AboutId = 101,
                    GenreId = 100
                },
                new AboutGenre
                {
                    AboutId = 101,
                    GenreId = 101
                });

            context.Director.AddRange(
                new Director
                {
                    Id = 100,
                    Name = "João M Dias"
                },
                new Director
                {
                    Id = 101,
                    Name = "Carlos D Sousa"
                },
                new Director
                {
                    Id = 102,
                    Name = "Diego F Brito"
                });

            context.SaveChangesAsync();
        }
    }
}
