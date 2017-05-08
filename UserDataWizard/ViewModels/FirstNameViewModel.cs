using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class FirstNameViewModel : BaseViewModel
    {
        public override int Id
        {
            get { return 1; }
        }

        public override string PageTitle
        {
            get { return "Imię"; }
        }

        private string firstName;

        public string FirstName
        {
            get
            {
                firstName = UserDataService.GetFirstName();
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
                UserDataService.ChangeFirstName(firstName);
            }
        }

        public override string Validate()
        {
            var validationMessage = "";

            if (string.IsNullOrEmpty(firstName))
            {
                validationMessage = "Imię jest wymagane!\n";
            }
            else if (!ValidationMethods.StartWithCapitalLetters(firstName))
            {
                validationMessage = "Imię musi zaczynać się od wielkiej litery!\n";
            }
            else if (ValidationMethods.ContainsNumber(firstName))
            {
                validationMessage = "Imię nie może zawierać cyfr!\n";
            }
            else if (ValidationMethods.ContainsSpecialCharacters(firstName))
            {
                validationMessage = "Imię nie może zawierać znaków specjalnych!\n";
            }
            else if (firstName.Length < 3 || firstName.Length > 20)
            {
                validationMessage = "Imię musi zawierać od 3 do 20 znaków!\n";
            }

            return validationMessage;
        }
    }
}
