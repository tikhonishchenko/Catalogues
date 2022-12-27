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

        internal async static Task<string> DBToString()
        {
            string result = "";
            foreach (CatalogueModel catalogue in await GetCataloguesAsync())
            {
                result += catalogue.Name + "→" + catalogue.Children + '\\';
            }
            return result;
        }

        internal async static void ClearDBAndImportFromStringToDB(string data)
        {
            using (AppDBContext db = new AppDBContext())
            {
                db.Database.ExecuteSqlRaw("DELETE FROM Folders");
                db.Database.ExecuteSqlRaw("VACUUM");
                string[] catalogues = data.Split('\\');
                foreach (string catalogue in catalogues)
                {
                    string[] catalogueData = catalogue.Split('→');
                    if (catalogueData.Length == 2)
                    {
                        CatalogueModel newCatalogue = new CatalogueModel(catalogueData[0], catalogueData[1]);
                        db.Folders.Add(newCatalogue);
                    }
                }
                await db.SaveChangesAsync();
            }
        }


    }
}
