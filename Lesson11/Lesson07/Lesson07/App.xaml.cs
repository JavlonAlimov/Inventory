using System.Configuration;
using System.Data;
using System.Windows;

namespace Lesson07
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion
                .Licensing
                .SyncfusionLicenseProvider
                .RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhKYVppR2Nbe054flFGalhVVAciSV9jS3pTdUVhWXdacHBRQmRfWQ==");
        }
    }

}
