using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormXamarin
{
    public class DataFormViewModel
    {
        private DataFormModel contactsInfo;

        public DataFormModel ContactsInfo
        {
            get { return contactsInfo; }
            set { contactsInfo = value; }
        }

        public DataFormViewModel()
        {
            contactsInfo = new DataFormModel();
        }
    }
}
