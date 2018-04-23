using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;
using DevExpress.Xpf.Printing;

namespace E3916 {
    public partial class MainPage : UserControl {
        readonly string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

        public MainPage() {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e) {
            SimpleLink link = new SimpleLink();
            link.ExportServiceUri = "../DemoExportService.svc";
            link.ReportHeaderTemplate = GetTemplate("reportHeader");
            link.ReportHeaderData = "Month names";
            link.DetailTemplate = GetTemplate("detail");
            link.DetailCount = monthNames.Length;
            link.CreateDetail += link_CreateDetail;
            link.ReportFooterTemplate = GetTemplate("reportFooter");
            link.ReportFooterData = GetImageData("logo.png");

            preview.Model = new LinkPreviewModel(link);
            link.CreateDocument(true);
        }

        void link_CreateDetail(object sender, CreateAreaEventArgs e) {
            e.Data = monthNames[e.DetailIndex];
        }

        byte[] GetImageData(string imageName) {
            Uri resourceUri = new Uri("/E3916;component/Images/" + imageName, UriKind.RelativeOrAbsolute);
            StreamResourceInfo resourceInfo = Application.GetResourceStream(resourceUri);
            using(resourceInfo.Stream)
            using(MemoryStream imageStream = new MemoryStream()) {
                resourceInfo.Stream.CopyTo(imageStream);
                return imageStream.ToArray();
            }
        }

        DataTemplate GetTemplate(string templateName) {
            return (DataTemplate)Resources[templateName];
        }
    }
}
