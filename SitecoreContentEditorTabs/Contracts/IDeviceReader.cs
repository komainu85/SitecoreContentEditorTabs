using System.Collections.Generic;

namespace Robbins.SitecoreContentEditorTabs.Contracts
{
    public interface IDeviceReader
    {
        List<DeviceDefinition> GetAllDevices(Item item);

        List<Item> GetAllDeviceItems(Item item);
    }
}