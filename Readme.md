<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128595962/13.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3916)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[MainPage.xaml](./CS/E3916/MainPage.xaml) (VB: [MainPage.xaml](./VB/E3916/MainPage.xaml))**
* [MainPage.xaml.cs](./CS/E3916/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/E3916/MainPage.xaml.vb))
<!-- default file list end -->
# How to use an image from application resources in a DXPrinting template
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3916)**
<!-- run online end -->


<p>When using an image from resources inside a DXPrinting template, your first move might be to write something like this:</p><br />
<p><DataTemplate x:Key="reportFooter"></p><p>  <dxe:ImageEdit IsPrintingMode="True" Source="/E3916;component/Images/logo.png" /></p><p></DataTemplate></p><br />
<p>Unfortunately, due to the specific behavior of the Image / BitmapImage controls in Silverlight, this approach might not work. The image is created asynchronously. So, when the DXPrinting engine composes the document, the image is not ready and it is not displayed. The next time you build the document, the image is in the image cache already and is available immediately, so the DXPrinting engine successfully adds it on a document page.</p><p>This sample illustrates how to display an image from resources using the ImageDataConverter.<br />
</p>

<br/>


