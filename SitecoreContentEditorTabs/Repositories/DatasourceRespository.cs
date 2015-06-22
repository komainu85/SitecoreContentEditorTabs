using System;
using System.Linq;
using SitecoreContentEditorTabs.Models;

namespace SitecoreContentEditorTabs.Repositories
{
    public class DatasourceRespository : Sitecore.Services.Core.IRepository<Datasource>
    {
        public IQueryable<Datasource> GetAll()
        {
            throw new NotImplementedException();
        }

        public Datasource FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(Datasource datasource)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Datasource datasource)
        {
            throw new NotImplementedException();
        }

        public void Update(Datasource datasource)
        {
            throw new NotImplementedException();
        }

        public void Delete(Datasource datasource)
        {
            throw new NotImplementedException();
        }
    }
}