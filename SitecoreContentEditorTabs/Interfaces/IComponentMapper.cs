using Robbins.SitecoreContentEditorTabs.Models;
using Sitecore.Data.Items;
using Sitecore.Layouts;

namespace Robbins.SitecoreContentEditorTabs.Interfaces
{
    public interface IComponentMapper
    {
        Component MapToComponent(RenderingReference renderingReference, Item datasource, Item device);
      }
}