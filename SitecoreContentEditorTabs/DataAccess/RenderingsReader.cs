using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using Sitecore.Web.UI.HtmlControls;
using SitecoreContentEditorTabs.Interfaces;

namespace SitecoreContentEditorTabs.DataAccess
{
    public class RenderingsReader : IRenderingsReader
    {
        private IComponentMapper _iComponentMapper;
        private string DefaultDevice = "{FE5D7FDF-89C0-4D99-9AA3-B5FBD009C9F3}";

        public RenderingsReader(IComponentMapper iComponentMapper)
        {
            _iComponentMapper = iComponentMapper;
        }

        public List<Models.Component> GetComponents(Item item, Database database)
        {
            var layoutField = (Sitecore.Data.Fields.LayoutField)item.Fields["__renderings"];

            var references = layoutField.GetReferences(new DeviceItem(database.GetItem(DefaultDevice)));

            var test = (from reference in references
                        let renderingItem = reference.RenderingItem
                        let datasource = database.GetItem(reference.Settings.DataSource)
                        select _iComponentMapper.MapToComponent(reference, datasource)).ToList();

            return test;
        }
    }
}