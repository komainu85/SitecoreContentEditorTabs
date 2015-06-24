using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using SitecoreContentEditorTabs.Interfaces;

namespace SitecoreContentEditorTabs.DataAccess
{
    public class DeviceReader : IDeviceReader
    {
        public List<DeviceDefinition> GetAllDevices(Item item)
        {
            var layout = Sitecore.Layouts.LayoutDefinition.Parse(item[Sitecore.FieldIDs.LayoutField]);

            return layout.Devices.Cast<DeviceDefinition>().ToList();
        }

        public List<Item> GetAllDeviceItems(Item item)
        {
            var devices = GetAllDevices(item);

            return devices.Select(device => item.Database.GetItem(device.ID)).ToList();
        }
    }
}