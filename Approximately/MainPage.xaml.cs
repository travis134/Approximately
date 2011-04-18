using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Advertising.Mobile.UI;

namespace Approximately
{
    public partial class MainPage : PhoneApplicationPage
    {
        Dictionary<MassUnit, double> massUnits;
        Dictionary<MassObject, double> massObjects;

        Dictionary<LengthUnit, double> lengthUnits;
        Dictionary<LengthObject, double> lengthObjects;

        Dictionary<VolumeUnit, double> volumeUnits;
        Dictionary<VolumeObject, double> volumeObjects;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            this.massUnits = new Dictionary<MassUnit, double>();
            this.massUnits.Add(MassUnit.Milligram, 1);
            this.massUnits.Add(MassUnit.Centigram, 10);
            this.massUnits.Add(MassUnit.Decigram, 100);
            this.massUnits.Add(MassUnit.Gram, 1000);
            this.massUnits.Add(MassUnit.Dekagram, 10000);
            this.massUnits.Add(MassUnit.Hectogram, 100000);
            this.massUnits.Add(MassUnit.Kilogram, 1000000);
            this.massUnits.Add(MassUnit.Megagram, 1000000000);
            this.massUnits.Add(MassUnit.Grain, 64.79891);
            this.massUnits.Add(MassUnit.Pennyweight, 1555.17384);
            this.massUnits.Add(MassUnit.Ounce, 28349.5231);
            this.massUnits.Add(MassUnit.Pound, 453592.37);
            this.massUnits.Add(MassUnit.Dram, 1771.8452);
            this.massUnits.Add(MassUnit.Ton, 907184740);
            this.massUnits.Add(MassUnit.LongTon, 1016046910);
            this.massUnits.Add(MassUnit.Carat, 200);

            this.fromListMassPicker.SelectionChanged += new SelectionChangedEventHandler(listMassPicker_SelectionChanged);

            foreach (KeyValuePair<MassUnit, double> mu in this.massUnits)
            {
                this.fromListMassPicker.Items.Add(mu.Key.ToString());
            }

            this.massObjects = new Dictionary<MassObject, double>();
            this.massObjects.Add(MassObject.Paper, 5000);
            this.massObjects.Add(MassObject.Quarter, 5670);
            this.massObjects.Add(MassObject.Pencil, 10000);
            this.massObjects.Add(MassObject.CD, 60951.4747);
            this.massObjects.Add(MassObject.Toothbrush, 90718);
            this.massObjects.Add(MassObject.Soda, 240796);
            this.massObjects.Add(MassObject.Brick, 2721554.22);
            this.massObjects.Add(MassObject.Xbox360, 3492661.25);
            this.massObjects.Add(MassObject.Bicycle, 13607771.1);
            this.massObjects.Add(MassObject.Car, 1814369480);

            this.toListMassPicker.SelectionChanged += new SelectionChangedEventHandler(listMassPicker_SelectionChanged);

            foreach (KeyValuePair<MassObject, double> mo in massObjects)
            {
                toListMassPicker.Items.Add(mo.Key.ToString());
            }

            this.inputMassValue.TextChanged += new TextChangedEventHandler(inputMassText_TextChanged);

            this.lengthUnits = new Dictionary<LengthUnit, double>();
            this.lengthUnits.Add(LengthUnit.Millimeter, 1);
            this.lengthUnits.Add(LengthUnit.Centimeter, 10);
            this.lengthUnits.Add(LengthUnit.Decimeter, 100);
            this.lengthUnits.Add(LengthUnit.Meter, 1000);
            this.lengthUnits.Add(LengthUnit.Dekameter,10000);
            this.lengthUnits.Add(LengthUnit.Hectometer,100000);
            this.lengthUnits.Add(LengthUnit.Kilometer,1000000);
            this.lengthUnits.Add(LengthUnit.Angstrom,.0000001);
            this.lengthUnits.Add(LengthUnit.Inch,25.4);
            this.lengthUnits.Add(LengthUnit.Feet,304.8);
            this.lengthUnits.Add(LengthUnit.Yard,914.4);
            this.lengthUnits.Add(LengthUnit.Rod,5029.2);
            this.lengthUnits.Add(LengthUnit.Chain,20116.8);
            this.lengthUnits.Add(LengthUnit.Furlong,201168);
            this.lengthUnits.Add(LengthUnit.Mile,1609344);
            this.lengthUnits.Add(LengthUnit.Hand,101.6);
            this.lengthUnits.Add(LengthUnit.Fathom,1828.8);
            this.lengthUnits.Add(LengthUnit.NauticalMile, 1852000);
            this.lengthUnits.Add(LengthUnit.League, 5556000);

            this.fromListLengthPicker.SelectionChanged += new SelectionChangedEventHandler(listLengthPicker_SelectionChanged);

            foreach (KeyValuePair<LengthUnit, double> lu in this.lengthUnits)
            {
                this.fromListLengthPicker.Items.Add(lu.Key.ToString());
            }

            this.lengthObjects = new Dictionary<LengthObject, double>();
            this.lengthObjects.Add(LengthObject.Quarter,24.26);
            this.lengthObjects.Add(LengthObject.Dollar,155.95600);
            this.lengthObjects.Add(LengthObject.Pencil,177.8);
            this.lengthObjects.Add(LengthObject.Paper,297);
            this.lengthObjects.Add(LengthObject.Ruler,304.8);
            this.lengthObjects.Add(LengthObject.Door,2032 );
            this.lengthObjects.Add(LengthObject.Bus,14630.4);
            this.lengthObjects.Add(LengthObject.Storey,3657.6 );
            this.lengthObjects.Add(LengthObject.FootballField,91440);

            this.toListLengthPicker.SelectionChanged += new SelectionChangedEventHandler(listLengthPicker_SelectionChanged);

            foreach (KeyValuePair<LengthObject, double> lo in lengthObjects)
            {
                toListLengthPicker.Items.Add(lo.Key.ToString());
            }

            this.inputLengthValue.TextChanged += new TextChangedEventHandler(inputLengthText_TextChanged);

            //

            this.volumeUnits = new Dictionary<VolumeUnit, double>();
            this.volumeUnits.Add(VolumeUnit.Milliliter,1);
            this.volumeUnits.Add(VolumeUnit.CubicCentimeter,1);
            this.volumeUnits.Add(VolumeUnit.CubicDecimeter,1000);
            this.volumeUnits.Add(VolumeUnit.CubicMeter,1000000);
            this.volumeUnits.Add(VolumeUnit.Liter,1000);
            this.volumeUnits.Add(VolumeUnit.Deciliter,100);
            this.volumeUnits.Add(VolumeUnit.Centiliter,10);
            this.volumeUnits.Add(VolumeUnit.CubicFoot,28316.8466);
            this.volumeUnits.Add(VolumeUnit.CubicYard,764554.858);
            this.volumeUnits.Add(VolumeUnit.FluidOunce,29.5735296);
            this.volumeUnits.Add(VolumeUnit.Pint,473.176473);
            this.volumeUnits.Add(VolumeUnit.Quart,946.352946);
            this.volumeUnits.Add(VolumeUnit.Gallon,3785.41178);
            this.volumeUnits.Add(VolumeUnit.OilBarrel,158987.295);
            this.volumeUnits.Add(VolumeUnit.Peck,8809.768);
            this.volumeUnits.Add(VolumeUnit.Bushel,35239.072);
            this.volumeUnits.Add(VolumeUnit.Teaspoon,4.92892159);
            this.volumeUnits.Add(VolumeUnit.Tablespoon,14.7867648);
            this.volumeUnits.Add(VolumeUnit.Cup,236.588237);

            this.fromListVolumePicker.SelectionChanged += new SelectionChangedEventHandler(listVolumePicker_SelectionChanged);

            foreach (KeyValuePair<VolumeUnit, double> vu in this.volumeUnits)
            {
                this.fromListVolumePicker.Items.Add(vu.Key.ToString());
            }

            this.volumeObjects = new Dictionary<VolumeObject, double>();
            this.volumeObjects.Add(VolumeObject.Drop,.05);
            this.volumeObjects.Add(VolumeObject.CoffeeMug,177.42);
            this.volumeObjects.Add(VolumeObject.SodaCan,355);
            this.volumeObjects.Add(VolumeObject.Pitcher,1000);
            this.volumeObjects.Add(VolumeObject.Sink,5000);
            this.volumeObjects.Add(VolumeObject.Tub,200000);
            this.volumeObjects.Add(VolumeObject.Pool,83358552.9 );
            this.volumeObjects.Add(VolumeObject.Lake,483509092000000000);

            this.toListVolumePicker.SelectionChanged += new SelectionChangedEventHandler(listVolumePicker_SelectionChanged);

            foreach (KeyValuePair<VolumeObject, double> vo in volumeObjects)
            {
                toListVolumePicker.Items.Add(vo.Key.ToString());
            }

            this.inputVolumeValue.TextChanged += new TextChangedEventHandler(inputVolumeText_TextChanged);
        }

        void inputMassText_TextChanged(object sender, TextChangedEventArgs e)
        {
            computeMass();
        }

        void listMassPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            computeMass();
        }

        void computeMass()
        {
            double inputMass;
            if (double.TryParse(inputMassValue.Text, out inputMass))
            {
                    answerMassLabel.Text = String.Format("{0:0.##}", (inputMass * massUnits[(MassUnit)fromListMassPicker.SelectedIndex]) / massObjects[(MassObject)toListMassPicker.SelectedIndex]);
                    answerUnitMassLabel.Text = ((MassObject)toListMassPicker.SelectedIndex).ToString() + "'s";
                
            }
        }

        void inputLengthText_TextChanged(object sender, TextChangedEventArgs e)
        {
            computeLength();
        }

        void listLengthPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            computeLength();
        }

        void computeLength()
        {
            double inputLength;
            if (double.TryParse(inputLengthValue.Text, out inputLength))
            {
                answerLengthLabel.Text = String.Format("{0:0.##}", (inputLength * lengthUnits[(LengthUnit)fromListLengthPicker.SelectedIndex]) / lengthObjects[(LengthObject)toListLengthPicker.SelectedIndex]);
                answerUnitLengthLabel.Text = ((LengthObject)toListLengthPicker.SelectedIndex).ToString() + "'s";

            }
        }

        void inputVolumeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            computeVolume();
        }

        void listVolumePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            computeVolume();
        }

        void computeVolume()
        {
            double inputVolume;
            if (double.TryParse(inputVolumeValue.Text, out inputVolume))
            {
                answerVolumeLabel.Text = String.Format("{0:0.##}", (inputVolume * volumeUnits[(VolumeUnit)fromListVolumePicker.SelectedIndex]) / volumeObjects[(VolumeObject)toListVolumePicker.SelectedIndex]);
                answerUnitVolumeLabel.Text = ((VolumeObject)toListVolumePicker.SelectedIndex).ToString() + "'s";

            }
        }

    }
}