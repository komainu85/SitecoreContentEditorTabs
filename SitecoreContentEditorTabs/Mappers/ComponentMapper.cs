using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using SitecoreContentEditorTabs.Interfaces;
using SitecoreContentEditorTabs.Models;

namespace SitecoreContentEditorTabs.Mappers
{
    public class ComponentMapper : IComponentMapper
    {
        public Component MapToComponent(RenderingReference renderingReference, Item datasource, Item device)
        {
            var component = new Models.Component()
            {
                Id = renderingReference.UniqueId,
                ComponentName = renderingReference.RenderingItem.Name,
                Placeholder = renderingReference.Placeholder,
                IsPersonalised = renderingReference.Settings.Rules.Count> 0,
                Device = device.DisplayName
            };

            if (datasource != null)
            {
                component.DatasourceId = datasource.ID.ToGuid();
                component.DatasourceLink = datasource.Paths.FullPath;
                component.DatasourceName = datasource.Name;
            }

            return component;
        }

    }
}
