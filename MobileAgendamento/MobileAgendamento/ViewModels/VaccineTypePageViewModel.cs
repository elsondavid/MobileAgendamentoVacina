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
    public class VaccineTypePageViewModel : ViewModelBase
    {
        private readonly IApi _api;
        private VaccineType _vaccineType = new VaccineType();
        public VaccineTypePageViewModel(IApi api, INavigationService navigationService) : base(navigationService)
        {
            Name = new ReactiveProperty<string>().AddTo(Disposables);
            SendCommand = new ReactiveCommand();
            SendCommand.Subscribe(x => OnSendCommandRegisterVaccine()).AddTo(Disposables);
            _api = api;
        }

        public ReactiveProperty<string> Name { get; }
        public ReactiveCommand SendCommand { get; }

        public void OnSendCommandRegisterVaccine()
        {
            _vaccineType.Name = Name.Value;
            _api.SaveVaccineType(_vaccineType);
        }
    }
}
