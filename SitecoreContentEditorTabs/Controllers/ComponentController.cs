using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Robbins.SitecoreContentEditorTabs.Contracts;
using Robbins.SitecoreContentEditorTabs.IoC;
using Robbins.SitecoreContentEditorTabs.Models;
using Sitecore.Data.Managers;
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

        public List<Component> GetComponents(string id, string database, string language)
        {
            Contract.Assert(!string.IsNullOrEmpty(id), "id is required");

            var db = Sitecore.Data.Database.GetDatabase(database);

            Contract.Assume(db != null, "Invalid database");

            var languageItem = LanguageManager.GetLanguage(language, db);

            Contract.Assume(languageItem != null, "Invalid language");

            var item = db.GetItem(id, languageItem);

            Contract.Assume(item != null, "Invalid ID, item doesn't exist");

            if (item.Fields[Sitecore.FieldIDs.LayoutField] == null || string.IsNullOrEmpty(item.Fields[Sitecore.FieldIDs.LayoutField].Value))
                return null;

            var renderingsReader = Container.GetInstance<IRenderingsReader>();

            return renderingsReader.GetComponents(item).ToList();
        }
    }
}