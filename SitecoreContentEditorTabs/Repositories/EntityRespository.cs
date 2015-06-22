using System;
using System.Linq;
using SitecoreContentEditorTabs.Models;

namespace SitecoreContentEditorTabs.Repositories
{
    public class EntityRespository : Sitecore.Services.Core.IRepository<Entity>
    {
        public IQueryable<Entity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entity FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(Entity entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}