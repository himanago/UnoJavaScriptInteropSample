using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#if __WASM__
using Uno.Foundation;
using Uno.Extensions;
#endif

namespace UnoJavaScriptInteropSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

#if __WASM__
        protected override void OnLoaded()
        {
            WebAssemblyRuntime.InvokeJS($"toReadonly({textBox.HtmlId});");

            WebAssemblyRuntime.InvokeJS($"addDblclickEventListener({textBox.HtmlId});");
            textBox.RegisterHtmlCustomEventHandler("dblclickEvent", OnDblclickEvent, isDetailJson: false);
        }

        private async void OnDblclickEvent(object sender, HtmlCustomEventArgs e)
        {
            await new MessageDialog(e.Detail).ShowAsync();
        }
#endif

        private async void callJsButton_Click(object sender, RoutedEventArgs e)
        {
#if __WASM__
            WebAssemblyRuntime.InvokeJS("sayHello();");
            
#else
            await new MessageDialog("Hello from MessageDialog").ShowAsync();
#endif
        }
    }
}
