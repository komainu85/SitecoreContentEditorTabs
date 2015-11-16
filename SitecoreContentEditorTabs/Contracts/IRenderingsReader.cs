using System.Collections.Generic;
using Robbins.SitecoreContentEditorTabs.Models;

namespace Robbins.SitecoreContentEditorTabs.Contracts
{
    public interface IRenderingsReader
    {
        IEnumerable<Component> GetComponents(Item item);
    }
}