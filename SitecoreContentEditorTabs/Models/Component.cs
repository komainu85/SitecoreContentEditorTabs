using System;

namespace SitecoreContentEditorTabs.Models
{
    public class Component : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId
        {
            get { return Id; }
        }

        public string ComponentName { get; set; }
        public string DatasourceName { get; set; }
        public Guid DatasourceId { get; set; }
        public string DatasourceLink { get; set; }

        public string Placeholder { get; set; }

    }
}