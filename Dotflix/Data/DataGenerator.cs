using ApiDotflix.Data;
using ApiDotflix.Models;
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
                }
                );


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
            context.SaveChangesAsync();
        }
    }
}
