Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Resources
Imports DevExpress.Xpf.Printing

Namespace E3916
	Partial Public Class MainPage
		Inherits UserControl
		Private ReadOnly monthNames() As String = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames

		Public Sub New()
			InitializeComponent()
			AddHandler Loaded, AddressOf MainPage_Loaded
		End Sub

		Private Sub MainPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim link As New SimpleLink()
			link.ExportServiceUri = "../DemoExportService.svc"
			link.ReportHeaderTemplate = GetTemplate("reportHeader")
			link.ReportHeaderData = "Month names"
			link.DetailTemplate = GetTemplate("detail")
			link.DetailCount = monthNames.Length
			AddHandler link.CreateDetail, AddressOf link_CreateDetail
			link.ReportFooterTemplate = GetTemplate("reportFooter")
			link.ReportFooterData = GetImageData("logo.png")

			preview.Model = New LinkPreviewModel(link)
			link.CreateDocument(True)
		End Sub

		Private Sub link_CreateDetail(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Data = monthNames(e.DetailIndex)
		End Sub

		Private Function GetImageData(ByVal imageName As String) As Byte()
			Dim resourceUri As New Uri("/E3916;component/Images/" & imageName, UriKind.RelativeOrAbsolute)
			Dim resourceInfo As StreamResourceInfo = Application.GetResourceStream(resourceUri)
			Using resourceInfo.Stream
			Using imageStream As New MemoryStream()
				resourceInfo.Stream.CopyTo(imageStream)
				Return imageStream.ToArray()
			End Using
			End Using
		End Function

		Private Function GetTemplate(ByVal templateName As String) As DataTemplate
			Return CType(Resources(templateName), DataTemplate)
		End Function
	End Class
End Namespace
