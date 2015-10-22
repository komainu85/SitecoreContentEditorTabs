(function(Speak) {
    Speak.pageCode({        initialized: function () {
            parent.scContent.onEditorTabClick(this, null, "Content");
            this.GetComponents();
        },

        GetComponents: function () {
            var datasource = this.DataSource;

            $.ajax({
                url: "/sitecore/api/ssc/Robbins-SitecoreContentEditorTabs-Controllers/Component/" + this.GetQueryStringParameter("id") + "/GetComponents?database=" + this.GetQueryStringParameter("database") + "&language=" + this.GetQueryStringParameter("language"),
                type: "GET",
                contentType: 'application/json',
                context: this,
                success: function (data) {
                    datasource.Items = data;
                }
            });
        },

        GetQueryStringParameter: function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }    });
})(Sitecore.Speak);