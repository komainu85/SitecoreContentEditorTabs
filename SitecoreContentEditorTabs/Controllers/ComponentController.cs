using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using SitecoreContentEditorTabs.Models;
using SitecoreContentEditorTabs.Repositories;

namespace SitecoreContentEditorTabs.Controllers
{
    [ServicesController]
    public class ComponentController : EntityService<Component>
    {
        public ComponentController(IRepository<Component> repository)
            : base(repository)
        {
        }

        public ComponentController()
            : this(new ComponentRespository())
        {
        }
    }
}