using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataWizard.Models;

namespace UserDataWizard.Repository
{
    public class UserDataRepository
    {
        private static UserDataModel UserData;

        static UserDataRepository()
        {
            UserData = new UserDataModel();
        }

        public string GetFirstName()
        {
            return UserData.FirstName;
        }

        public string GetSecondName()
        {
            return UserData.SecondName;
        }
        public string GetAddress()
        {
            return UserData.Address;
        }

        public string GetPhoneNumber()
        {
            return UserData.PhoneNumber;
        }

        public void UpdateFirstName(string firstName)
        {
            UserData.FirstName = firstName;
        }

        public void UpdateSecondName(string secondName)
        {
            UserData.SecondName = secondName;
        }

        public void UpdateAddress(string address)
        {
            UserData.Address = address;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            UserData.PhoneNumber = phoneNumber;
        }

        public UserDataModel GetUserData()
        {
            return UserData;
        }

        public void ResetUserDataModel()
        {
            UserData = new UserDataModel();
        }
    }
}
