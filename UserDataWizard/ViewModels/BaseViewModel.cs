using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserDataWizard.Annotations;
using UserDataWizard.Service;

namespace UserDataWizard.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public abstract int Id { get; }
        public abstract string PageTitle { get; }

        private string error;
        private bool isCurrentPage;

        protected UserDataService UserDataService = new UserDataService();

        public string Error
        {
            get { throw new NotImplementedException(); }
            set { error = value; }
        }

        public bool IsCurrentPage
        {
            get { return isCurrentPage; }
            set
            {
                if (value == isCurrentPage)
                {
                    return;
                }

                isCurrentPage = value;
                OnPropertyChanged(nameof(IsCurrentPage));
            }
        }

        public abstract bool IsTextBoxFilledCorrectly();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get { return Validate(columnName); }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "FirstName":
                    // TODO: Check validiation condition
                    validationMessage = "Imię";
                    break;
                case "SecondName":
                    // TODO: Check validiation condition
                    validationMessage = "Nazwisko";
                    break;
                case "Address":
                    // TODO: Check validiation condition
                    validationMessage = "Adres";
                    break;
                case "PhoneNumber":
                    // TODO: Check validiation condition
                    validationMessage = "Numer telefonu";
                    break;
            }

            return validationMessage;
        }
    }
}
