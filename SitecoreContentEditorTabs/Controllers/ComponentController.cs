using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;
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
            Assert.IsNotNullOrEmpty(itemId, "itemId");

            var database = Sitecore.Data.Database.GetDatabase("master");
            var item = database.GetItem(itemId);
            if (item == null || item.Fields["__renderings"] == null || string.IsNullOrEmpty(item.Fields["__renderings"].Value))
                return null;

            var layoutField = (Sitecore.Data.Fields.LayoutField) item.Fields["__renderings"];

            var references = layoutField.GetReferences(new DeviceItem(null));

            var test = (from reference in references
                let renderingItem = reference.RenderingItem
                let datasource = database.GetItem(renderingItem.DataSource)
                select new Component()
                {
                    Id = "1",
                    ComponentName = reference.RenderingItem.Name,
                    DatasourceId = datasource.ID.ToGuid(),
                    DatasourceLink = datasource.Paths.FullPath,
                    DatasourceName = datasource.Name,
                }).ToList();

            test.Add(new Component() { Id = "3", ComponentName = "News", DatasourceId = new Guid(), DatasourceName = "The article" });

            return test;
        }
    }
}