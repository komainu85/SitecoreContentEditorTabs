using Sitecore.Services.Core;
using SitecoreContentEditorTabs.DataAccess;
using SitecoreContentEditorTabs.Mappers;
using SitecoreContentEditorTabs.Models;

namespace SitecoreContentEditorTabs.IoC
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