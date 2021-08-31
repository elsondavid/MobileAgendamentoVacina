using MobileAgendamento.Models;
using Refit;
using System;
using System.Threading.Tasks;

namespace MobileAgendamento.Api
{
    public interface IApi
    {
        [Post("/Patient/SavePatient")]
        Task<bool> SavePatient([Body] Patient patient);

        [Get("/Patient/GetPatient")]
        IObservable<Patient> GetPatient([Body] Patient patient);

        [Put("/Patient/UpdatePatient")]
        Task<bool> UpdatePatient([Body] Patient paciente);

        [Post("/VaccineType/SaveVaccineType")]
        Task<VaccineType> SaveVaccineType([Body] VaccineType vaccineType);

        [Get("/VaccineType/GetPatient")]
        IObservable<VaccineType> GetPatient([Body] VaccineType vaccineType);
    }

}
