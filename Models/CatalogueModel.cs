using System.ComponentModel.DataAnnotations;

namespace Catalogues.Models
{
    internal sealed class CatalogueModel
    {
        [Key]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Children { get; set; }

        public CatalogueModel(string name, string children)
        {
            Name = name;
            Children = children;
        }
        
        public List<string> ChildrenToList()
        {
            
                List<string> childrenList = new List<string>();
                childrenList.Add(Name);
                if (Children != null)
                {
                    string[] childrenArray = Children.Split(',');
                    foreach (string child in childrenArray)
                    {
                        childrenList.Add(child);
                    }
                }
                return childrenList;
            
        }

    }
}
