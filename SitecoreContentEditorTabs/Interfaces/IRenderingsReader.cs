using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace SitecoreContentEditorTabs.Interfaces
{
    public interface IRenderingsReader
    {
        List<Models.Component> GetComponents(Item item);
    }
}