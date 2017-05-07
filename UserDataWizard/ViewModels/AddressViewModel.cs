﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public override int Id
        {
            get { return 3; }
        }

        public override string PageTitle
        {
            get { return "Adres"; }
        }

        private string address;

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
                UserDataService.ChangeAddress(address);
            }
        }
        public override bool IsTextBoxFilledCorrectly()
        {
            if (string.IsNullOrEmpty(address))
            {
                Error = "Adres jest wymagany!";
                return false;
            }

            return true;
        }
    }
}
