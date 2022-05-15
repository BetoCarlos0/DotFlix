using ApiDotflix.Data;
using ApiDotflix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
                    KeywordId = 100,
                    Name = "Ação"
                },
                new Keyword
                {
                    KeywordId = 101,
                    Name = "Aventura"
                },
                new Keyword
                {
                    KeywordId = 102,
                    Name = "Cinema de Arte"
                },
                new Keyword
                {
                    KeywordId = 103,
                    Name = "Comédia"
                },
                new Keyword
                {
                    KeywordId = 104,
                    Name = "Dança"
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
                    MovieId = 100
                },
                new About
                {
                    AboutId = 101,
                    MovieId = 101
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

            context.SaveChangesAsync();
        }
    }
}
