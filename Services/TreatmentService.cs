using Microsoft.Extensions.Options;
using SNMedicTreatment.Models.Config;
using SNMedicTreatment.Models.Treatments;
using SNMedicTreatment.Repositories;
using System.Collections.Generic;

namespace SNMedicTreatment.Services
{
    public class TreatmentService
    {
        private readonly TreatmentRepository _repository;
        private readonly MedicationService _medicationService;
        private readonly EventsService _eventsService;
        private readonly AppConfig _appConfig;
        public TreatmentService(TreatmentRepository repository, 
            EventsService eventsService, 
            MedicationService medicationService, 
            IOptions<AppConfig> appConfig)
        {
            _repository = repository;
            _medicationService = medicationService;
            _eventsService = eventsService;
            _appConfig = appConfig.Value;
        }

        public Treatment Find(int id)
        {
            return _repository.Find(id);
        }

        public List<Treatment> FindByUserId(int IdUser)
        {
            return _repository.FindByUserId(IdUser);
        }

        public List<Treatment> FindByPatientId(int IdPatient)
        {
            return _repository.FindByPatientId(IdPatient);
        }

        public Treatment Create(Treatment treatment)
        {
            _repository.Create(treatment);
            return treatment;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteAllFromTreatment(int idTreatment)
        {
            _eventsService.FindByTreatmentId(idTreatment).ForEach(events => _eventsService.Delete(events.Id));
            _medicationService.FindByTreatmentId(idTreatment).ForEach(medication => _medicationService.Delete(medication.Id));
            _repository.Delete(idTreatment);
        }

        public Treatment Update(Treatment treatment)
        {
            var _treatment = _repository.Find(treatment.Id);
            if (_treatment == null)
            {
                _treatment.IdPatient = treatment.IdPatient;
                _treatment.Name = treatment.Name;
                _treatment.DiagnosisDate = treatment.DiagnosisDate;
                _treatment.Complement = treatment.Complement;
            }
            _repository.Update(_treatment);
            return _treatment;
        }

    }
}
