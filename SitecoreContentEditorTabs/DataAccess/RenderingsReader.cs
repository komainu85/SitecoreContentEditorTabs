using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Web.UI.HtmlControls;
using SitecoreContentEditorTabs.Interfaces;
using Component = SitecoreContentEditorTabs.Models.Component;

namespace SitecoreContentEditorTabs.DataAccess
{
    public class RenderingsReader : IRenderingsReader
    {
        private IComponentMapper _iComponentMapper;
        private IDeviceReader _iDeviceReader;

        public RenderingsReader(IComponentMapper iComponentMapper, IDeviceReader iDeviceReader)
        {
            _iComponentMapper = iComponentMapper;
            _iDeviceReader = iDeviceReader;
        }

        public IEnumerable<Component> GetStandardValueComponents(Item item)
        {
            Assert.IsNotNull(item, "item");

            IEnumerable<Component> standardValueComponents = new List<Component>();

            var itemStandardValues = item.Template.StandardValues;

            if (itemStandardValues != null && !String.Equals(Sitecore.Configuration.Settings.DefaultBaseTemplate.Trim().ToLower(),
                    item.TemplateID.ToString().ToLower().Trim(), StringComparison.InvariantCultureIgnoreCase))
                standardValueComponents = GetComponents(itemStandardValues);

            return standardValueComponents;
        }

        public IEnumerable<Models.Component> GetComponents(Item item)
        {
            Assert.IsNotNull(item, "item");

            var components = new List<Models.Component>();

            var layoutField = (Sitecore.Data.Fields.LayoutField)item.Fields[Enums.FieldNames.Renderings];

            var devices = _iDeviceReader.GetAllDeviceItems(item);

            var standardValueComponents = GetStandardValueComponents(item);

            foreach (var device in devices)
            {
                var references = layoutField.GetReferences(new DeviceItem(device));

                components.AddRange((from reference in references
                                     let datasource = item.Database.GetItem(reference.Settings.DataSource)
                                     let standardRendering = standardValueComponents
                                                            .FirstOrDefault(c => 
                                                                String.Equals(c.Device.Trim().ToLower(), device.DisplayName.Trim().ToLower(), StringComparison.InvariantCultureIgnoreCase)
                                                                && String.Equals(c.Id.Trim().ToLower(), reference.UniqueId.Trim().ToLower(), StringComparison.InvariantCultureIgnoreCase))
                                     let standardDatasource = (standardRendering != null && standardRendering.DatasourceId == datasource.ID.ToGuid()) ? true : false
                                     select _iComponentMapper.MapToComponent(reference, datasource, standardRendering != null, standardDatasource, device)).OrderBy(x => x.Device).ToList());
            }

            return components;
        }
    }
}