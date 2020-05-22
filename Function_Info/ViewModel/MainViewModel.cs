using System;
using System.Collections.Generic;
using System.Text;
using Function_Info.ViewModel.Base;

namespace Function_Info.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        #region Properties

        private string equation;

        public string Equation
        {
            get { return equation; }
            set
            {
                equation = value;
                onPropertyChanged(nameof(Equation));
            }
        }

        private RelayCommand analyze;

        public RelayCommand Analyze
        {
            get { return analyze; }
            set
            {
                analyze = value;
                onPropertyChanged(nameof(Analyze));
            }
        }


        #endregion
    }
}
