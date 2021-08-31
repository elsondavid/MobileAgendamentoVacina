using MobileAgendamento.Api;
using MobileAgendamento.Models;
using MobileAgendamento.Views;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Threading.Tasks;

namespace MobileAgendamento.ViewModels
{
    public class PatientPageViewModel : ViewModelBase
    {
        private readonly IApi _api;
        private Patient _patient = new Patient();
        public PatientPageViewModel(IApi api, INavigationService navigationService) : base(navigationService)
        {
            Name = new ReactiveProperty<string>().AddTo(Disposables);
            Cpf = new ReactiveProperty<string>().AddTo(Disposables);
            Password = new ReactiveProperty<string>().AddTo(Disposables);
            Email = new ReactiveProperty<string>().AddTo(Disposables);
            
            SearchPatient = new ReactiveCommand();
            SendCommand = new ReactiveCommand();
            
            SendCommand.Subscribe(x => OnSendCommand()).AddTo(Disposables);
            SearchPatient.Subscribe(x => SearchPatientCommand()).AddTo(Disposables);
            _api = api;
        }

        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<string> Cpf { get; }
        public ReactiveProperty<string> Password { get; }
        public ReactiveProperty<string> Email { get; }
        public ReactiveCommand SendCommand { get; }
        public ReactiveCommand SearchPatient { get; }

        public void OnSendCommand()
        {
            _patient.Name = Name.Value;
            _patient.Cpf = Cpf.Value;
            _patient.Password = Password.Value;
            _patient.Email = Email.Value;

            _api.SavePatient(_patient);
        }

        public void SearchPatientCommand()
        {
            NavigationService.NavigateAsync(nameof(SearchPatientPage))
                       .ToObservable()
                       .Subscribe()
                       .AddTo(Disposables);
        }
    }
}

