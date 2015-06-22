using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using SitecoreContentEditorTabs.Models;
using SitecoreContentEditorTabs.Repositories;

namespace SitecoreContentEditorTabs.Controllers
{
    [ServicesController]
    public class DatasourceController : EntityService<Datasource>
    {
        public DatasourceController(IRepository<Datasource> repository)
            : base(repository)
        {
        }

        public DatasourceController()
            : this(new DatasourceRespository())
        {
        }
    }
}