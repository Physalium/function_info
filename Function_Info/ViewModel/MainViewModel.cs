using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Function_Info.ViewModel.Base;

namespace Function_Info.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        #region Properties

        private string equation = "x**2";

        public string Equation
        {
            get { return equation; }
            set
            {
                equation = value;
                onPropertyChanged(nameof(Equation));
            }
        }
        private string leftBound = "-10";

        public string LeftBound
        {
            get { return leftBound; }
            set
            {
                leftBound = value;
                onPropertyChanged(nameof(LeftBound));
            }
        }

        string rightBound = "10";

        public string RightBound
        {
            get { return rightBound; }
            set
            {
                rightBound = value;
                onPropertyChanged(nameof(RightBound));
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

        private BitmapImage graph;

        public BitmapImage Graph
        {
            get { return graph; }
            set
            {
                graph = value;
                onPropertyChanged(nameof(Graph));
            }
        }



        #endregion
        public MainViewModel()
        {
            var bitmap = new BitmapImage();

            using (var stream = new MemoryStream(Properties.Resources.DefaultGraph))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            bitmap.Freeze(); // optionally make it cross-thread accessible
            graph=bitmap;
        }
    }
}
