using Microsoft.Extensions.Options;
using SNMedicTreatment.Models.Config;
using SNMedicTreatment.Models.Medications;
using SNMedicTreatment.Repositories;
using System.Collections.Generic;

namespace SNMedicTreatment.Services
{
    public class MedicationService
    {
        private readonly MedicationRepository _repository;
        private readonly EventsService _eventsService;
        private readonly AppConfig _appConfig;

        public MedicationService(MedicationRepository repository, EventsService eventsService, IOptions<AppConfig> appConfig)
        {
            _repository = repository;
            _eventsService = eventsService;
            _appConfig = appConfig.Value;
        }

        public Medication Find(int id)
        {
            return _repository.Find(id);
        }

        public List<Medication> FindByUserId(int IdUser)
        {
            return _repository.FindByUserId(IdUser);
        }

        public List<Medication> FindByPatientId(int IdPatient)
        {
            return _repository.FindByPatientId(IdPatient);
        }

        public List<Medication> FindByTreatmentId(int id)
        {
            return _repository.FindByTreatmentId(id);
        }

        public Medication Create(Medication medication)
        {
            _repository.Create(medication);
            _eventsService.CreateAll(medication);
            return medication;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteAllFromMedication(int idMedication)
        {
            _eventsService.FindByMedicationId(idMedication).ForEach(events => _eventsService.Delete(events.Id));
            _repository.Delete(idMedication);
        }

        public Medication Update(int userId, Medication medication)
        {
            var _medication = _repository.Find(medication.Id);
            if (_medication == null)
            {
                _medication.IdTreatment = medication.IdTreatment;
                _medication.Status = medication.Status;
                _medication.Days = medication.Days;
                _medication.StartDate = medication.StartDate;
                _medication.Frequency = medication.Frequency;
                _medication.Dosage = medication.Dosage;
                _medication.Description = medication.Description;
            }
            _eventsService.UpdateAll(_medication);
            _repository.Update(_medication);
            return _medication;
        }

    }
}
