using Sitecore.Data.Items;
using Sitecore.Layouts;
using SitecoreContentEditorTabs.Models;

namespace SitecoreContentEditorTabs.Interfaces
{
    public interface IComponentMapper
    {
        Component MapToComponent(RenderingReference renderingReference, Item datasource, Item device);
        Component MapToComponent(RenderingReference renderingReference, Item datasource, bool? standardValueRendering, Item device);
    }
}