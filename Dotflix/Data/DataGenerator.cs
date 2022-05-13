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
                },
                new Language
                {
                    LanguageId = new Guid("600fb988-27f1-4dea-8c30-fd79db1bc56a"),
                    Name = "Espanhol"
                },
                new Language
                {
                    LanguageId = new Guid("322bbc02-2a62-400d-aaae-ba338c86ce92"),
                    Name = "Japonês"
                },
                new Language
                {
                    LanguageId = new Guid("6d94dcae-1134-4322-a9f1-c9a6fe77d205"),
                    Name = "Chinês"
                },
                new Language
                {
                    LanguageId = new Guid("a84c7145-63f4-4346-88a0-8e82e395efd1"),
                    Name = "Latim"
                },
                new Language
                {
                    LanguageId = new Guid("faaedcb0-a8e5-4770-ae4e-bb6401f7ac26"),
                    Name = "Russo"
                },
                new Language
                {
                    LanguageId = new Guid("840efc0a-41ee-4ccb-be9b-141107734408"),
                    Name = "Urdu"
                },
                new Language
                {
                    LanguageId = new Guid("24e67585-c03e-4259-8e45-04e905c9a3f4"),
                    Name = "Basco"
                },
                new Language
                {
                    LanguageId = new Guid("406339d5-d917-43cc-b9d2-3b284c05d157"),
                    Name = "Galês"
                },
                new Language
                {
                    LanguageId = new Guid("1c5c79bf-3e34-4b52-8842-9057029d6f82"),
                    Name = "Zulu"
                },
                new Language
                {
                    LanguageId = new Guid("7f479fca-9bd8-4abb-a2c6-66bdca7e7a0f"),
                    Name = "Luganda"
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
