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

        private bool isCurrentPage;

        protected UserDataService UserDataService = new UserDataService();

        public string Error
        {
            get { throw new NotImplementedException(); }
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get { return Validate(); }
        }
        public abstract string Validate();

        public bool IsValid()
        {
            return Validate() == "";
        }
    }
}
