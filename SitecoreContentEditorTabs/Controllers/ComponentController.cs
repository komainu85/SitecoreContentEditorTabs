using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Robbins.SitecoreContentEditorTabs.Interfaces;
using Robbins.SitecoreContentEditorTabs.IoC;
using Robbins.SitecoreContentEditorTabs.Models;
using Sitecore.Diagnostics;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Web.Http;
using StructureMap;

namespace Robbins.SitecoreContentEditorTabs.Controllers
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
            Contract.Assert(!string.IsNullOrEmpty(id), "id is required");

            var db = Sitecore.Data.Database.GetDatabase(database);

            Contract.Assume(db != null, "Invalid database");

            var item = db.GetItem(id);

            Contract.Assume(item!=null, "Invalid ID, item doesn't exist");

            if (item.Fields[Sitecore.FieldIDs.LayoutField] == null || string.IsNullOrEmpty(item.Fields[Sitecore.FieldIDs.LayoutField].Value))
                return null;

            var renderingsReader = Container.GetInstance<IRenderingsReader>();

            return renderingsReader.GetComponents(item).ToList();
        }
    }
}