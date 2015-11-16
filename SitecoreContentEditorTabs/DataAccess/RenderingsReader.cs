using System;
using System.Collections.Generic;
using System.Linq;
using Robbins.SitecoreContentEditorTabs.Contracts;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Component = Robbins.SitecoreContentEditorTabs.Models.Component;

namespace Robbins.SitecoreContentEditorTabs.DataAccess
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

        public IEnumerable<Component> GetComponents(Item item)
        {
            Assert.IsNotNull(item, "item");

            var components = new List<Models.Component>();

            var layoutField = (Sitecore.Data.Fields.LayoutField)item.Fields[Sitecore.FieldIDs.FinalLayoutField];

            var devices = _iDeviceReader.GetAllDeviceItems(item);

            foreach (var device in devices)
            {
                var references = layoutField.GetReferences(new DeviceItem(device));

                components.AddRange((from reference in references
                                     let renderingItem = reference.RenderingItem
                                     let datasource = item.Database.GetItem(reference.Settings.DataSource, item.Language)
                                     select _iComponentMapper.MapToComponent(reference, datasource, device)).OrderBy(x => x.Device).ToList());
            }

            return components;
        }
    }
}