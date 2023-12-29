<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/E3916/MainPage.xaml) (VB: [MainPage.xaml](./VB/E3916/MainPage.xaml))
* [MainPage.xaml.cs](./CS/E3916/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/E3916/MainPage.xaml.vb))
<!-- default file list end -->
# How to use an image from application resources in a DXPrinting template


<p>When using an image from resources inside a DXPrinting template, your first move might be to write something like this:</p><br />
<p><DataTemplate x:Key="reportFooter"></p><p>  <dxe:ImageEdit IsPrintingMode="True" Source="/E3916;component/Images/logo.png" /></p><p></DataTemplate></p><br />
<p>Unfortunately, due to the specific behavior of the Image / BitmapImage controls in Silverlight, this approach might not work. The image is created asynchronously. So, when the DXPrinting engine composes the document, the image is not ready and it is not displayed. The next time you build the document, the image is in the image cache already and is available immediately, so the DXPrinting engine successfully adds it on a document page.</p><p>This sample illustrates how to display an image from resources using the ImageDataConverter.<br />
</p>

<br/>


