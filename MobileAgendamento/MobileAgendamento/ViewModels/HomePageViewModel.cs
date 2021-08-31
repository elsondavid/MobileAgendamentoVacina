using MobileAgendamento.Api;
using MobileAgendamento.Views;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Threading.Tasks;

namespace MobileAgendamento.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly IApi _api;
        public HomePageViewModel(IApi api, INavigationService navigationService) : base(navigationService)
        {
            RegisterPatient = new ReactiveCommand();
            RegisterPatient.Subscribe(x => OnSendCommandRegisterPatient()).AddTo(Disposables);

            RegisterVaccine = new ReactiveCommand();
            RegisterVaccine.Subscribe(x => OnSendCommandRegisterVaccine()).AddTo(Disposables);

            ScheduleVaccine = new ReactiveCommand();
            ScheduleVaccine.Subscribe(x => OnSendCommandScheduleVaccine()).AddTo(Disposables);

            RegisterVaccine = new ReactiveCommand();
            RegisterVaccine.Subscribe(x => OnSendCommandRegisterVaccine()).AddTo(Disposables);


            _api = api;
        }

        public ReactiveCommand RegisterVaccine { get; }
        public ReactiveCommand RegisterPatient { get; }
        public ReactiveCommand RegisterVaccineType { get; }

        public ReactiveCommand ScheduleVaccine { get; }
        
        public void OnSendCommandRegisterPatient()
        {
            NavigationService.NavigateAsync(nameof(PatientPage))
                       .ToObservable()
                       .Subscribe()
                       .AddTo(Disposables);
        }

        public void OnSendCommandRegisterVaccineType()
        {
                NavigationService.NavigateAsync(nameof(VaccineTypePage))
                       .ToObservable()
                       .Subscribe()
                       .AddTo(Disposables);
        }

        public void OnSendCommandRegisterVaccine()
        {
            NavigationService.NavigateAsync(nameof(VaccinePage))
                       .ToObservable()
                       .Subscribe()
                       .AddTo(Disposables);
        }

        public void OnSendCommandScheduleVaccine()
        {
                NavigationService.NavigateAsync(nameof(PickUpPatientToScheduleTheVaccinePage))
                       .ToObservable()
                       .Subscribe()
                       .AddTo(Disposables);
        }
    }
}

