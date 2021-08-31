using MobileAgendamento.Api;
using MobileAgendamento.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileAgendamento.ViewModels
{
    public class SearchPatientPageViewModel : ViewModelBase
    {
        private readonly IApi _api;
        private Patient _patient = new Patient();
        public SearchPatientPageViewModel(IApi api, INavigationService navigationService) : base(navigationService)
        {
            Name = new ReactiveProperty<string>().AddTo(Disposables);
            Cpf = new ReactiveProperty<string>().AddTo(Disposables);
            CpfSearch = new ReactiveProperty<string>().AddTo(Disposables);
            Password = new ReactiveProperty<string>().AddTo(Disposables);
            Email = new ReactiveProperty<string>().AddTo(Disposables);
            Id = new ReactiveProperty<int>().AddTo(Disposables);

            SendCommand = new ReactiveCommand();
            SendCommand.Subscribe(x => OnSendCommand()).AddTo(Disposables);

            SearchPatient = new ReactiveCommand();
            SearchPatient.Subscribe(x => SearchPatientCommand()).AddTo(Disposables);
            _api = api;
        }

        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<string> Cpf { get; }

        public ReactiveProperty<string> CpfSearch { get; }
        
        public ReactiveProperty<string> Password { get; }
        public ReactiveProperty<string> Email { get; }
        public ReactiveProperty<int> Id { get; }
        public ReactiveCommand SendCommand { get; }
        public ReactiveCommand SearchPatient { get; }

        public void SearchPatientCommand()
        {
            _patient.Cpf = CpfSearch.Value;

            _api.GetPatient(_patient)
                .Subscribe(x => 
                {
                    Name.Value = x.Name;
                    Email.Value = x.Email;
                    Cpf.Value = x.Cpf;
                    Id.Value = x.Id;
                    Password.Value = x.Password;
                   
                })
                .AddTo(Disposables);
        }

        public void OnSendCommand()
        {
            _patient.Name = Name.Value;
            _patient.Id   = Id.Value;
            _patient.Email = Email.Value;
            _patient.Cpf = Cpf.Value;
            _patient.Password = Password.Value;

            _api.UpdatePatient(_patient);
        }
    }
}
