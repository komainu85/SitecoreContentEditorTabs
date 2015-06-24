using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using SitecoreContentEditorTabs.Models;

namespace SitecoreContentEditorTabs.Interfaces
{
    public interface IRenderingsReader
    {
        IEnumerable<Component> GetComponents(Item item);
        IEnumerable<Component> GetStandardValueComponents(Item item);
    }
}