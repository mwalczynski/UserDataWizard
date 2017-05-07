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
    }
}
