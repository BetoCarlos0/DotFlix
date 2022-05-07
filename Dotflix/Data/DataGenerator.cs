using Dotflix.Data;
using Dotflix.Models;
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
                    LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                    Name = "Português"
                },
                new Language
                {
                    LanguageId = new Guid("b84c7cce-f651-4a0d-98ab-8dc13a7898a9"),
                    Name = "Inglês"
                });

            context.MovieLanguage.AddRange(
                new MovieLanguage
                {
                    LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                    MovieId = new Guid("d495e18e-3a41-404d-bdb6-d71196699811")
                },
                new MovieLanguage
                {
                    LanguageId = new Guid("b84c7cce-f651-4a0d-98ab-8dc13a7898a9"),
                    MovieId = new Guid("d495e18e-3a41-404d-bdb6-d71196699811")
                },
                new MovieLanguage
                {
                    LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                    MovieId = new Guid("58edeefa-ce6e-4248-90ae-47fcf38313ab")
                }
                );


            context.Movie.AddRange(
                new Movie
                {
                    MovieId = new Guid("d495e18e-3a41-404d-bdb6-d71196699811"),
                    AgeGroup = "18",
                    Image = "img2",
                    ReleaseData = new DateTime(2021, 5, 10),
                    RunTime = new DateTime(1, 1, 1, 2, 15, 20),
                    Sinopse = "uma sinopse",
                    Title = "um filme",
                    Relevance = 45,
                    Cadastro = DateTime.Now
                },
                new Movie
                {
                    MovieId = new Guid("58edeefa-ce6e-4248-90ae-47fcf38313ab"),
                    AgeGroup = "10",
                    Image = "img1",
                    ReleaseData = new DateTime(2021, 5, 10),
                    RunTime = new DateTime(1, 1, 1, 2, 20, 20),
                    Sinopse = "outra sinopse",
                    Title = "outro filme",
                    Relevance = 15,
                    Cadastro = DateTime.Now
                }
            );
            context.SaveChangesAsync();
        }
    }
}
