using System.Collections.Generic;
using Robbins.SitecoreContentEditorTabs.Models;
using Sitecore.Data.Items;

namespace Robbins.SitecoreContentEditorTabs.Interfaces
{
    public interface IRenderingsReader
    {
        IEnumerable<Component> GetComponents(Item item);
    }
}