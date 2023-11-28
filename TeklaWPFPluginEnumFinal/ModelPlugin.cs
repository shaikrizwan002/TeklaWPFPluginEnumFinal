using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;

namespace TeklaWPFPluginEnumFinal
{
    public class PluginData
    {
        #region Fields
        //
        // Define the fields specified on the Form.
        //

        [StructuresField("SelectedOptions")]
        public int SelectedOptions;
        #endregion
    }

    [Plugin("TeklaWPFPluginEnumFinal")]
    [PluginUserInterface("TeklaWPFPluginEnumFinal.MainWindow")]
    public class TeklaWPFPluginEnumFinal : PluginBase
    {
        #region Fields
        private Model _Model;
        private PluginData _Data;
        //
        // Define variables for the field values.
        //
        private int _SelectedOptions = 0;
        private PluginOptions _SelectedOption;
        #endregion

        #region Properties
        private Model Model
        {
            get { return this._Model; }
            set { this._Model = value; }
        }

        private PluginData Data
        {
            get { return this._Data; }
            set { this._Data = value; }
        }
        #endregion

        #region Constructor
        public TeklaWPFPluginEnumFinal(PluginData data)
        {
            Model = new Model();
            Data = data;
        }
        #endregion

        #region Overrides
        public override List<InputDefinition> DefineInput()
        {
            //
            // This is an example for selecting two points; change this to suit your needs.
            //
            List<InputDefinition> PointList = new List<InputDefinition>();
            Picker Picker = new Picker();
            ArrayList PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);

            PointList.Add(new InputDefinition(PickedPoints));

            return PointList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                GetValuesFromDialog();

                PluginOptions translatedOption = (PluginOptions)_SelectedOptions;
                switch (translatedOption)
                {
                    case PluginOptions.OptionA:
                        _SelectedOption = PluginOptions.OptionA;
                        break;
                    case PluginOptions.OptionB:
                        _SelectedOption = PluginOptions.OptionB;
                        break;
                        // Add more cases as needed
                }

                ArrayList Points = (ArrayList)Input[0].GetInput();
                Point StartPoint = Points[0] as Point;
                Point EndPoint = Points[1] as Point;

                Point LengthVector = new Point(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y, EndPoint.Z - StartPoint.Z);


            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }

            return true;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void GetValuesFromDialog()
        {

            _SelectedOptions = Data.SelectedOptions;
            
            if (IsDefaultValue(_SelectedOptions))
                _SelectedOptions = 0;
            
        }

        // Write your private methods here.

        #endregion
    }
}
