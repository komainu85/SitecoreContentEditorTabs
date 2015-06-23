using SitecoreContentEditorTabs.Mappers;

namespace SitecoreContentEditorTabs.IoC
{
    public class Registry : StructureMap.Configuration.DSL.Registry
    {
        public Registry()
        {
            For<Interfaces.IComponentMapper>().Use<ComponentMapper>();
        }


    }
}