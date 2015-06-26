using Robbins.SitecoreContentEditorTabs.DataAccess;
using Robbins.SitecoreContentEditorTabs.Mappers;

namespace Robbins.SitecoreContentEditorTabs.IoC
{
    public class Registry : StructureMap.Configuration.DSL.Registry
    {
        public Registry()
        {
            For<Interfaces.IComponentMapper>().Use<ComponentMapper>();
            For<Interfaces.IRenderingsReader>().Use<RenderingsReader>();
            For<Interfaces.IDeviceReader>().Use<DeviceReader>();
        }


    }
}