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
                    Id = 100,
                    Name = "Portugês"
                },
                new Language
                {
                    Id = 101,
                    Name = "Inglês"
                },
                new Language
                {
                    Id = 102,
                    Name = "Chinês"
                },
                new Language
                {
                    Id = 103,
                    Name = "Espanhol"
                },
                new Language
                {
                    Id = 104,
                    Name = "Árabe"
                },
                new Language
                {
                    Id = 105,
                    Name = "Russo"
                },
                new Language
                {
                    Id = 106,
                    Name = "Urdu"
                },
                new Language
                {
                    Id = 107,
                    Name = "Coreano"
                },
                new Language
                {
                    Id = 108,
                    Name = "Alemão"
                },
                new Language
                {
                    Id = 109,
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
                    AgeGroupId = "14",
                    AgeGroup = new AgeGroup("14", "Não recomendado para menores de 14 anos",
                            "Conteúdos mais violentos e/ou de linguagem sexual mais acentuada"),
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
                    AgeGroupId = "10",
                    AgeGroup = new AgeGroup("10", "Não recomendado para menores de 10 anos",
                            "Conteúdo violento ou linguagem inapropírada para crianças"),
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

            context.AboutCast.AddRange(
                new AboutCast
                {
                    AboutId = 100,
                    CastId = 100
                },
                new AboutCast
                {
                    AboutId = 101,
                    CastId = 100
                },
                new AboutCast
                {
                    AboutId = 101,
                    CastId = 101
                });

            context.Cast.AddRange(
                new Cast
                {
                    Id = 100,
                    Name = "Jack Chan"
                },
                new Cast
                {
                    Id = 101,
                    Name = "Will Smitch"
                },
                new Cast
                {
                    Id = 102,
                    Name = "Julius"
                });
            
            context.AboutRoadMap.AddRange(
                new AboutRoadMap
                {
                    AboutId = 100,
                    RoadMapId = 100
                },
                new AboutRoadMap
                {
                    AboutId = 101,
                    RoadMapId = 100
                },
                new AboutRoadMap
                {
                    AboutId = 101,
                    RoadMapId = 101
                });

            context.RoadMap.AddRange(
                new RoadMap
                {
                    Id = 100,
                    Name = "Chris"
                },
                new RoadMap
                {
                    Id = 101,
                    Name = "Brown"
                },
                new RoadMap
                {
                    Id = 102,
                    Name = "Carlos"
                });

            context.SaveChangesAsync();
        }
    }
}
