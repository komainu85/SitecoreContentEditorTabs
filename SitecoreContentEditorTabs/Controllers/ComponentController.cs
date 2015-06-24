using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using Sitecore.Services.Infrastructure.Web.Http;
using SitecoreContentEditorTabs.DataAccess;
using SitecoreContentEditorTabs.Interfaces;
using SitecoreContentEditorTabs.IoC;
using SitecoreContentEditorTabs.Mappers;
using SitecoreContentEditorTabs.Models;
using StructureMap;

namespace SitecoreContentEditorTabs.Controllers
{
    [ServicesController]
    public class ComponentController : ServicesApiController
    {
        public static Container Container
        {
            get
            {
                return new Container(new Registry());
            }
        }

        public List<Component> GetComponents(string id, string database)
        {
            Assert.IsNotNullOrEmpty(id, "itemId");

            var db = Sitecore.Data.Database.GetDatabase(database);
            var item = db.GetItem(id);
            if (item == null || item.Fields["__renderings"] == null || string.IsNullOrEmpty(item.Fields["__renderings"].Value))
                return null;

            var renderingsReader = Container.GetInstance<IRenderingsReader>();

            return renderingsReader.GetComponents(item);
        }
    }
}