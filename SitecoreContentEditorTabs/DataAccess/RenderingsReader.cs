using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Web.UI.HtmlControls;
using SitecoreContentEditorTabs.Interfaces;

namespace SitecoreContentEditorTabs.DataAccess
{
    public class RenderingsReader : IRenderingsReader
    {
        private IComponentMapper _iComponentMapper;
        private IDeviceReader _iDeviceReader;

        public RenderingsReader(IComponentMapper iComponentMapper, IDeviceReader iDeviceReader)
        {
            _iComponentMapper = iComponentMapper;
            _iDeviceReader = iDeviceReader;
        }

        public List<Models.Component> GetComponents(Item item)
        {
            Assert.IsNotNull(item, "item");

            var components = new List<Models.Component>();

            var layoutField = (Sitecore.Data.Fields.LayoutField)item.Fields["__renderings"];

            var devices = _iDeviceReader.GetAllDeviceItems(item);

            foreach (var device in devices)
            {
                var references = layoutField.GetReferences(new DeviceItem(device));

                components.AddRange((from reference in references
                                     let renderingItem = reference.RenderingItem
                                     let datasource = database.GetItem(reference.Settings.DataSource)
                                     select _iComponentMapper.MapToComponent(reference, datasource, device)).OrderBy(x=> x.Device).ToList());
            }

            return components;
        }
    }
}