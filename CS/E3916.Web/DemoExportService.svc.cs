using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using DevExpress.Data.Utils.ServiceModel;

namespace E3916.Web {
    [SilverlightFaultBehavior]
    public class DemoExportService : DevExpress.Xpf.Printing.Service.ExportService {
    }
}
