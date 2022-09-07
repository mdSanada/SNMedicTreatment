using Microsoft.Extensions.Options;
using SNMedicTreatment.Helper;
using SNMedicTreatment.Models.Config;
using SNMedicTreatment.Models.Users;
using SNMedicTreatment.Repositories;

namespace SNMedicTreatment.Services
{
    public class LoginService
    {
        private readonly LoginRepository _repository;
        private readonly PatientsService _patientsService;
        private readonly TreatmentService _treatmentService;
        private readonly MedicationService _medicationService;
        private readonly EventsService _eventsService;
        private readonly AppConfig _appConfig;

        public LoginService(LoginRepository repository,
            PatientsService patientsService,
            TreatmentService treatmentService,
            MedicationService medicationService,
            EventsService eventsService,
            IOptions<AppConfig> appConfig)
        {
            _repository = repository;
            _patientsService = patientsService;
            _treatmentService = treatmentService;
            _medicationService = medicationService;
            _eventsService = eventsService;
            _appConfig = appConfig.Value;
        }

        public User Find(string email)
        {
            return _repository.Find(email);
        }

        public UserResponse Login(User user)
        {
            var refreshToken = JwtHelper.GenerateRefreshToken(user);
            var userResponse = new UserResponse() { Id = user.Id, Token = JwtHelper.GenerateToken(user, _appConfig), RefreshToken = refreshToken.Token };
            user.RefreshTokens.Add(refreshToken);

            _repository.Update(user);

            return userResponse;
        }

        public void Delete(int id)
        {
            _eventsService.FindByUserId(id).ForEach(events => _eventsService.Delete(events.Id));
            _medicationService.FindByUserId(id).ForEach(medication => _medicationService.Delete(medication.Id));
            _treatmentService.FindByUserId(id).ForEach(treatment => _treatmentService.Delete(treatment.Id));
            _patientsService.FindByUserId(id).ForEach (patient => _patientsService.Delete(patient.Id));
            _repository.Delete(id);
        }

        public User Update(User user)
        {
            var _user = _repository.Find(user.Id);
            if (user == null)
            {
                _user.DeviceId = user.DeviceId;
                _user.Email = user.Email;
                _user.Password = user.Password;
            }
            _repository.Update(user);
            return _user;
        }

        public UserResponse Create(User user)
        {
            _repository.Create(user);
            var refreshToken = JwtHelper.GenerateRefreshToken(user);
            var userResponse = new UserResponse() { Id = user.Id, Token = JwtHelper.GenerateToken(user, _appConfig), RefreshToken = refreshToken.Token };
            user.RefreshTokens.Add(refreshToken);

            return userResponse;
        }
    }
}
