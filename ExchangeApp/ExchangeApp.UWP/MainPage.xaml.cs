using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Prism;
using Prism.Ioc;

namespace ExchangeApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            CachedImageRenderer.Init();
            var ignore = typeof(SvgCachedImage);

            SvgCachedImage.Init();


            LoadApplication(new ExchangeApp.App(new UwpInitializer()));
        }

        public class UwpInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
            }
        }
    }
}