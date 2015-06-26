using System.Collections.Generic;
using Sitecore.Data.Items;
using Sitecore.Layouts;

namespace Robbins.SitecoreContentEditorTabs.Interfaces
{
    public interface IDeviceReader
    {
        List<DeviceDefinition> GetAllDevices(Item item);

        List<Item> GetAllDeviceItems(Item item);
    }
}