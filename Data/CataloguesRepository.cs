using Catalogues.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogues.Data
{
    public class CataloguesRepository
    {
        internal async static Task<List<CatalogueModel>> GetCataloguesAsync()
        {
            List<CatalogueModel> catalogues = new List<CatalogueModel>();
            using (AppDBContext db = new AppDBContext())
            {
                catalogues = await db.Folders.ToListAsync();
            }
            return catalogues;
        }

        internal async static Task<List<string>> GetCatalogueAsync(string name)
        {
            CatalogueModel catalogue;
            using (AppDBContext db = new AppDBContext())
            {
                catalogue = await db.Folders.FirstOrDefaultAsync(f => f.Name == name);
            }
            return catalogue.ChildrenToList();
        }
    }
}
