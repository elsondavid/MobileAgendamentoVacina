using MobileAgendamento.Api;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace MobileAgendamento.ViewModels
{
    
    public class VaccinePageViewModel : ViewModelBase
    {
        private readonly IApi _api;
        public VaccinePageViewModel(IApi api, INavigationService navigationService) : base(navigationService)
        {
            VaccinesTypes = new ReactiveProperty<string>().AddTo(Disposables);
            //RegisterPatient = new ReactiveCommand();
            //RegisterPatient.Subscribe(x => OnSendCommandRegisterPatient()).AddTo(Disposables);

            //RegisterVaccine = new ReactiveCommand();
            //RegisterVaccine.Subscribe(x => OnSendCommandRegisterVaccine()).AddTo(Disposables);

            //RegisterVaccineType = new ReactiveCommand();
            //RegisterVaccineType.Subscribe(x => OnSendCommandRegisterVaccineType()).AddTo(Disposables);
            _api = api;
        }

        public ReactiveProperty<string> VaccinesTypes { get; }
    }
}
