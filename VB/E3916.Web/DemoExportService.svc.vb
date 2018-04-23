Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports DevExpress.Data.Utils.ServiceModel

Namespace E3916.Web
	<SilverlightFaultBehavior> _
	Public Class DemoExportService
		Inherits DevExpress.Xpf.Printing.Service.ExportService
	End Class
End Namespace
