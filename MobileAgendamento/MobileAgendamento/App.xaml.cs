using MobileAgendamento.Api;
using MobileAgendamento.ViewModels;
using MobileAgendamento.Views;
using Prism;
using Prism.Ioc;
using Refit;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MobileAgendamento
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)

        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            containerRegistry
                .RegisterSingleton<IApi>(() => RestService.For<IApi>("http://192.168.1.31:5000", refitSettings));
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PatientPage, PatientPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<SearchPatientPage, SearchPatientPageViewModel>();
            containerRegistry.RegisterForNavigation<VaccineTypePage, VaccineTypePageViewModel>();
            containerRegistry.RegisterForNavigation<VaccinePage, VaccinePageViewModel>();
            containerRegistry.RegisterForNavigation<PickUpPatientToScheduleTheVaccinePage, PickUpPatientToScheduleTheVaccinePageViewModel>();
        }
    }
}

