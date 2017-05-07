using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserDataWizard.Annotations;
using UserDataWizard.Service;

namespace UserDataWizard.ViewModels
{
    public abstract class AbstractWizardViewModel : INotifyPropertyChanged
    {
        public abstract int Id { get; }
        public abstract string PageTitle { get; }

        protected UserDataService UserDataService = new UserDataService();




        bool isCurrentPage;

        public bool IsCurrentPage
        {
            get { return isCurrentPage; }
            set
            {
                if (value == isCurrentPage)
                    return;

                isCurrentPage = value;
                this.OnPropertyChanged(nameof(IsCurrentPage));
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
