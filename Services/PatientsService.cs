using Microsoft.Extensions.Options;
using SNMedicTreatment.Models.Config;
using SNMedicTreatment.Models.Patients;
using SNMedicTreatment.Repositories;
using System.Collections.Generic;

namespace SNMedicTreatment.Services
{
    public class PatientsService
    {
        private readonly PatientsRepository _repository;
        private readonly TreatmentService _treatmentService;
        private readonly MedicationService _medicationService;
        private readonly EventsService _eventsService;
        private readonly AppConfig _appConfig;
        public PatientsService(PatientsRepository repository, 
            MedicationService medicationService, 
            EventsService eventsService, 
            TreatmentService treatmentService,
            IOptions<AppConfig> appConfig)
        {
            _repository = repository;
            _treatmentService = treatmentService;
            _medicationService = medicationService;
            _eventsService = eventsService;
            _appConfig = appConfig.Value;
        }

        public Patient Find(int id)
        {
            return _repository.Find(id);
        }

        public List<Patient> FindByUserId(int IdUser)
        {
            return _repository.FindByUserId(IdUser);
        }

        public Patient Create(Patient patient)
        {
            _repository.Create(patient);
            return patient;
        }

        public void Delete(int patientId)
        {
            _repository.Delete(patientId);
        }

        public void DeleteAllFromPatients(int patientId)
        {
            _eventsService.FindByPatientId(patientId).ForEach(events => _eventsService.Delete(events.Id));
            _medicationService.FindByPatientId(patientId).ForEach(medication => _medicationService.Delete(medication.Id));
            _treatmentService.FindByPatientId(patientId).ForEach(treatment => _treatmentService.Delete(treatment.Id));
            _repository.Delete(patientId);
        }

        public Patient Update(Patient patient)
        {
            var _patient = _repository.Find(patient.Id);
            if (_patient == null)
            {
                _patient.Name = patient.Name;
                _patient.Breed = patient.Breed;
                _patient.Birthdate = patient.Birthdate;
                _patient.Allergy = patient.Allergy;
                _patient.Image = patient.Image;
                _patient.Weigth = patient.Weigth;
            }
            _repository.Update(_patient);
            return _patient;
        }

    }
}
