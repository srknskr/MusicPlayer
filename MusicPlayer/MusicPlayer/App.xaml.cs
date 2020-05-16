using MusicPlayer.Views;
using Xamarin.Forms;
using System.Reflection;
using Xamarin.Forms;
using Autofac;
using MusicPlayer.Services;

namespace MusicPlayer
{
    public partial class App : Application
    {
        public static IContainer _container;
        public App()
        {
            InitializeComponent();
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Namespace.Contains("ViewModels"));

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AssignableTo<IServiceBase>()
                   .AsImplementedInterfaces()
                   .SingleInstance();

            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();

            //MainPage = new deneme();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
