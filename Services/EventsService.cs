using Microsoft.Extensions.Options;
using SNMedicTreatment.Models.Config;
using SNMedicTreatment.Models.Events;
using SNMedicTreatment.Models.Medications;
using SNMedicTreatment.Repositories;
using System;
using System.Collections.Generic;

namespace SNMedicTreatment.Services
{
    public class EventsService
    {
        private readonly EventsRepository _repository;
        private readonly AppConfig _appConfig;

        public EventsService(EventsRepository repository, IOptions<AppConfig> appConfig)
        {
            _repository = repository;
            _appConfig = appConfig.Value;
        }

        public Event Find(int id)
        {
            return _repository.Find(id);
        }

        public List<Event> FindByUserId(int IdUser)
        {
            return _repository.FindByUserId(IdUser);
        }

        public List<Event> FindByPatientId(int IdPatient)
        {
            return _repository.FindByPatientId(IdPatient);
        }

        public List<Event> FindByTreatmentId(int id)
        {
            return _repository.FindByTreatmentId(id);
        }

        public List<Event> FindByMedicationId(int id)
        {
            return _repository.FindByMedicationId(id);
        }

        public List<Event> CreateAll(Medication medication)
        {
            var frequency = (int)Math.Round(Convert.ToDouble(24) / Convert.ToDouble(medication.Frequency));
            var repetitions = medication.Frequency * medication.Days;
            List<Event> events = new List<Event>();
            for (int i = 0; i < repetitions; i++)
            {
                var addHour = frequency * i;
                var _event = new Event()
                {
                    IdUser = medication.IdUser,
                    IdPatient = medication.IdPatient,
                    IdTreatment = medication.IdTreatment,
                    IdMedication = medication.Id,
                    DosageNumber = i,
                    NotificationDate = medication.StartDate.AddHours(addHour),
                };
                events.Add(_event);
            }

            events.ForEach(e => _repository.Create(e));
            return events;
        }

        public Event Create(Event _event)
        {
            _repository.Create(_event);
            return _event;
        }

        public void Delete(Event _event)
        {
            _repository.Delete(_event);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteAll(int idMedication)
        {
            _repository.DeleteAll(idMedication);
        }

        public Event Update(Event _event)
        {
            var _medication = _repository.Find(_event.Id);
            if (_medication == null)
            {
                _medication.IdTreatment = _event.IdTreatment;
                _medication.IdMedication = _event.IdMedication;
                _medication.NotificationDate = _event.NotificationDate;
                _medication.DosageNumber = _event.DosageNumber;
            }
            _repository.Update(_medication);
            return _medication;
        }

        public List<Event> UpdateAll(Medication medication)
        {
            DeleteAll(medication.Id);
            var newEvents = CreateAll(medication);
            return newEvents;
        }

    }
}
