using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using SitecoreContentEditorTabs.Models;
using SitecoreContentEditorTabs.Repositories;

namespace SitecoreContentEditorTabs.Controllers
{
    [ServicesController]
    public class EntityController : EntityService<Entity>
    {
        public EntityController(IRepository<Entity> repository)
            : base(repository)
        {
        }

        public EntityController()
            : this(new EntityRespository())
        {
        }
    }
}