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

        private string DefaultDevice = "{FE5D7FDF-89C0-4D99-9AA3-B5FBD009C9F3}";

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

            foreach (var references in devices.Select(device => layoutField.GetReferences(new DeviceItem(device))))
            {
                components.AddRange((from reference in references
                                     let renderingItem = reference.RenderingItem
                                     let datasource = item.Database.GetItem(reference.Settings.DataSource)
                                     select _iComponentMapper.MapToComponent(reference, datasource)).ToList());
            }

            return components;
        }
    }
}