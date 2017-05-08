using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataWizard.Models;
using UserDataWizard.Repository;

namespace UserDataWizard.Service
{
    public class UserDataService
    {
        private readonly UserDataRepository userDataRepository;

        public UserDataService()
        {
            userDataRepository = new UserDataRepository();
        }

        public string GetFirstName()
        {
            return userDataRepository.GetFirstName();
        }

        public string GetSecondName()
        {
            return userDataRepository.GetSecondName();
        }
        public string GetAddress()
        {
            return userDataRepository.GetAddress();
        }

        public string GetPhoneNumber()
        {
            return userDataRepository.GetPhoneNumber();
        }

        public void ChangeFirstName(string firstName)
        {
            userDataRepository.UpdateFirstName(firstName);
        }

        public void ChangeSecondName(string secondName)
        {
            userDataRepository.UpdateSecondName(secondName);
        }

        public void ChangeAddress(string address)
        {
            userDataRepository.UpdateAddress(address);
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            userDataRepository.UpdatePhoneNumber(phoneNumber);
        }

        public UserDataModel GetUserData()
        {
            return userDataRepository.GetUserData();
        }

        public void LoadNewData()
        {
            userDataRepository.ResetUserDataModel();
        }
    }
}
