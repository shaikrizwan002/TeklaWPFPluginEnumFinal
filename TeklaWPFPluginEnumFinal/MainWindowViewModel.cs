using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace TeklaWPFPluginEnumFinal
{
    /// <summary>
    /// Data logic for MainWindow
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() 
        {
            SelectedOptionValues = Enum.GetValues(typeof(PluginOptions)).Cast<PluginOptions>().ToArray();
        }


        #region Fields
        private int selectedOptions;
        public PluginOptions[] SelectedOptionValues { get; set; }

        #endregion

        #region Properties
        [StructuresDialog(nameof(SelectedOptions), typeof(TD.Integer))]
        public int SelectedOptions
        {
            get { return selectedOptions; }
            set { selectedOptions = value; OnPropertyChanged("SelectedOptions"); }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
