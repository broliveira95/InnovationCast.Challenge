using InnovationCast.Challenge.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnovationCast.Challenge.Database.Helpers
{
    public static class SeedDataHelper
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InnovationCastContext(
                serviceProvider.GetRequiredService<DbContextOptions<InnovationCastContext>>()))
            {
                // auto migration
                context.Database.Migrate();

                // Seed the database.
                InitializeComments(context);
            }
        }

        public static void InitializeComments(InnovationCastContext context)
        {
            if (context.Comments.Any())
            {
                return;   // DB has been seeded
            }

            var initialLength = 10;
            for (int i = 1; i <= initialLength; i++)
            {
                context.Comments.Add(
                    new Comment
                    {
                        EntityId = GetRandomEntityId(),
                        Description = $"Some random comment {i}",
                        Author = $"Author {i}",
                        PublishDate = DateTime.Now.AddDays(-i * 10)
                    }
                );
            }

            context.SaveChanges();
        }

        private static string GetRandomEntityId()
        {
            var entities = new string[] { "entity_1", "entity_2" };

            int index = new Random().Next(0, entities.Length);
            return entities[index];
        }
    }
}
