using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryServices
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                Name = model.Name,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Category.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CategoryListItem> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Category
                    .Select
                    (
                        e => new CategoryListItem
                        {
                            CategoryId = e.CategoryId,
                            Name = e.Name,
                            CreatedUtc = e.CreatedUtc
                        }

                        ) ;
                return query.ToArray();
            }

        }

        public CategoryDetails GetCategoryById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Category
                    .Single(e => e.CategoryId == id);
                return
                    new CategoryDetails
                    {
                        CategoryId = entity.CategoryId,
                        Name = entity.Name,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };

            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Category
                    .Single(e => e.CategoryId == model.CategoryId);
                entity.Name = model.Name;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
                    
                    
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Category
                    .Single(e => e.CategoryId == categoryId);

                ctx.Category.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }

}
