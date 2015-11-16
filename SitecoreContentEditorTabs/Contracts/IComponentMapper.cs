using Robbins.SitecoreContentEditorTabs.Models;

namespace Robbins.SitecoreContentEditorTabs.Contracts
{
    public interface IComponentMapper
    {
        Component MapToComponent(RenderingReference renderingReference, Item datasource, Item device);
      }
}