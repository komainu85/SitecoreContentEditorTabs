using System;
using System.Collections.Generic;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using SitecoreContentEditorTabs.Models;
using SitecoreContentEditorTabs.Repositories;

namespace SitecoreContentEditorTabs.Controllers
{
    [ServicesController]
    public class ComponentController : EntityService<Component>
    {
        public ComponentController(IRepository<Component> repository)
            : base(repository)
        {
        }

        public ComponentController()
            : this(new ComponentRespository())
        {
        }

        public List<Component> GetComponents(string itemId)
        {
            var test = new List<Component>();

            test.Add(new Component() {Id = "3", ComponentName = "News", DatasourceId = new Guid(), DatasourceName = "The article"});

            return test;
        }
    }
}