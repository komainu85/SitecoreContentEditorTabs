using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Layouts;

namespace SitecoreContentEditorTabs.Interfaces
{
    public interface IDeviceReader
    {
        List<DeviceDefinition> GetAllDevices(Item item);

        List<Item> GetAllDeviceItems(Item item);
    }
}