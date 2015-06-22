require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService"], function (Sitecore, $, _, entityService) {
    var SitecoreContentEditorTabs = Sitecore.Definitions.App.extend({



        initialized: function () {
            this.GetComponents();
        },

        EntityServiceConfig: function () {
            var componentService = new entityService({
                url: "/sitecore/api/ssc/MikeRobbins-Seshat-Controllers/Brochure"
            });

            return componentService;
        },

        GetComponents: function () {
            var datasource = this.DataSource;

            $.ajax({
                url: "/sitecore/api/ssc/SitecoreContentEditorTabs-Controllers/Component/3/GetComponents",
                type: "GET",
                contentType: 'application/json',
                context: this,
                success: function (data) {
                    datasource.viewModel.items(data);
                }
            });
        },
    });

    return SitecoreContentEditorTabs;
});