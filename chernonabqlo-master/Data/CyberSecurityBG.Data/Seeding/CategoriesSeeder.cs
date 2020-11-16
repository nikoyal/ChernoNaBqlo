namespace CyberSecurityBG.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberSecurityBG.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<string> { "Политика", "Телевизия", "Всекидневие", "Образование", "Тинейджърски", "Спорт", "Технологии", "Други" };
            var descriptions = new List<string> { "Всичко свързано със политика", "Телевизионни предавания", "Всекидневие", "Образование в България и чужбина", "Тинейджърски", "Спорт и здраве", "Всичко за всички технологий", "Други" };
            for (int i = 0; i < categories.Count; i++)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = categories[i],
                    Title = categories[i],
                    Description = descriptions[i],
                });
            }
        }
    }
}
