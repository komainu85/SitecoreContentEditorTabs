using System;
using System.Linq;
using SitecoreContentEditorTabs.Models;

namespace SitecoreContentEditorTabs.Repositories
{
    public class ComponentRespository : Sitecore.Services.Core.IRepository<Component>
    {
        public IQueryable<Component> GetAll()
        {
            throw new NotImplementedException();
        }

        public Component FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Component component)
        {
            throw new NotImplementedException();
        }

        public void Update(Component component)
        {
            throw new NotImplementedException();
        }

        public void Delete(Component component)
        {
            throw new NotImplementedException();
        }
    }
}