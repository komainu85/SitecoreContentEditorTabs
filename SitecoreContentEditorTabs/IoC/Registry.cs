using Robbins.SitecoreContentEditorTabs.Contracts;
using Robbins.SitecoreContentEditorTabs.DataAccess;
using Robbins.SitecoreContentEditorTabs.Mappers;

namespace Robbins.SitecoreContentEditorTabs.IoC
{
    public class Registry : StructureMap.Configuration.DSL.Registry
    {
        public Registry()
        {
            For<IComponentMapper>().Use<ComponentMapper>();
            For<IRenderingsReader>().Use<RenderingsReader>();
            For<IDeviceReader>().Use<DeviceReader>();
        }


    }
}