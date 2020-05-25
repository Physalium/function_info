using System;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

using Function_Info.Model;
using Function_Info.ViewModel.Base;

namespace Function_Info.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Model

        private PythonFileCaller pythonFileCaller = new PythonFileCaller();

        #endregion Model

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

        private string rightBound = "10";

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
            get
            {
                if (analyze == null)
                {
                    analyze = new RelayCommand(
                        execute =>
                        {
                            pythonFileCaller.CreateGraph(Equation, LeftBound, RightBound);
                            updateGraph();
                        },
                        canExecute =>
                        {
                            string[] inputs = { Equation, LeftBound, RightBound };
                            if (inputs.Any(field => string.IsNullOrEmpty(field))) return false;
                            return true;
                        });
                }
                return analyze;
            }
            set => analyze = value;
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

        #region Internal methods

        private void updateGraph()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
            var outputDir = Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\Model\"));
            var graphFile = Path.Combine(outputDir, "graph.png");
            var bitmap = new BitmapImage();

            using (var stream = new MemoryStream(File.ReadAllBytes(graphFile)))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            bitmap.Freeze(); // optionally make it cross-thread accessible
            Graph = bitmap;
        }

        #endregion Internal methods

        #endregion Properties

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
            graph = bitmap;
        }
    }
}