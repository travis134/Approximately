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
using System.Reflection;
using System.IO;
using System.Windows.Markup;

namespace Approximately
{
    public partial class MainPage : PhoneApplicationPage
    {
        List<MeasurementUnit> measurementUnits;
        List<MeasurementObject> measurementObjects;

        public MainPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            StorageHelper<MeasurementUnit> measurementUnitsFile = new StorageHelper<MeasurementUnit>("MeasurementUnits.xml");
            if (!measurementUnitsFile.Exists())
            {
                measurementUnitsFile.Save(
                        new List<MeasurementUnit>()
                        {
                            new MeasurementUnit(MeasurementType.Mass, "Milligram", 1),
                            new MeasurementUnit(MeasurementType.Mass,"Milligram", 1),
                            new MeasurementUnit(MeasurementType.Mass,"Centigram", 10),
                            new MeasurementUnit(MeasurementType.Mass,"Decigram", 100),
                            new MeasurementUnit(MeasurementType.Mass,"Gram", 1000),
                            new MeasurementUnit(MeasurementType.Mass,"Dekagram", 10000),
                            new MeasurementUnit(MeasurementType.Mass,"Hectogram", 100000),
                            new MeasurementUnit(MeasurementType.Mass,"Kilogram", 1000000),
                            new MeasurementUnit(MeasurementType.Mass,"Megagram", 1000000000),
                            new MeasurementUnit(MeasurementType.Mass,"Grain", 64.79891),
                            new MeasurementUnit(MeasurementType.Mass,"Pennyweight", 1555.17384),
                            new MeasurementUnit(MeasurementType.Mass,"Ounce", 28349.5231),
                            new MeasurementUnit(MeasurementType.Mass,"Pound", 453592.37),
                            new MeasurementUnit(MeasurementType.Mass,"Dram", 1771.8452),
                            new MeasurementUnit(MeasurementType.Mass,"Ton", 907184740),
                            new MeasurementUnit(MeasurementType.Mass,"LongTon", 1016046910),
                            new MeasurementUnit(MeasurementType.Mass,"Carat", 200),
                            new MeasurementUnit(MeasurementType.Length,"Millimeter",1),
                            new MeasurementUnit(MeasurementType.Length,"Centimeter",10),
                            new MeasurementUnit(MeasurementType.Length,"Decimeter",100),
                            new MeasurementUnit(MeasurementType.Length,"Meter",1000),
                            new MeasurementUnit(MeasurementType.Length,"Dekameter",10000),
                            new MeasurementUnit(MeasurementType.Length,"Hectometer",100000),
                            new MeasurementUnit(MeasurementType.Length,"Kilometer",1000000),
                            new MeasurementUnit(MeasurementType.Length,"Angstrom",.0000001),
                            new MeasurementUnit(MeasurementType.Length,"Inch",25.4),
                            new MeasurementUnit(MeasurementType.Length,"Feet",304.8),
                            new MeasurementUnit(MeasurementType.Length,"Yard",914.4),
                            new MeasurementUnit(MeasurementType.Length,"Rod",5029.2),
                            new MeasurementUnit(MeasurementType.Length,"Chain",20116.8),
                            new MeasurementUnit(MeasurementType.Length,"Furlong",201168),
                            new MeasurementUnit(MeasurementType.Length,"Mile",1609344),
                            new MeasurementUnit(MeasurementType.Length,"Hand",101.6),
                            new MeasurementUnit(MeasurementType.Length,"Fathom",1828.8),
                            new MeasurementUnit(MeasurementType.Length,"Nautical Mile",1852000),
                            new MeasurementUnit(MeasurementType.Length,"League",5556000),
                            new MeasurementUnit(MeasurementType.Volume,"Milliliter",1),
                            new MeasurementUnit(MeasurementType.Volume,"Cubic Centimeter",1),
                            new MeasurementUnit(MeasurementType.Volume,"Cubic Decimeter",1000),
                            new MeasurementUnit(MeasurementType.Volume,"Cubic Meter",1000000),
                            new MeasurementUnit(MeasurementType.Volume,"Liter",1000),
                            new MeasurementUnit(MeasurementType.Volume,"Deciliter",100),
                            new MeasurementUnit(MeasurementType.Volume,"Centiliter",10),
                            new MeasurementUnit(MeasurementType.Volume,"Cubic Foot",28316.8466),
                            new MeasurementUnit(MeasurementType.Volume,"Cubic Yard",764554.858),
                            new MeasurementUnit(MeasurementType.Volume,"Fluid Ounce",29.5735296),
                            new MeasurementUnit(MeasurementType.Volume,"Pint",473.176473),
                            new MeasurementUnit(MeasurementType.Volume,"Quart",946.352946),
                            new MeasurementUnit(MeasurementType.Volume,"Gallon",3785.41178),
                            new MeasurementUnit(MeasurementType.Volume,"Oil Barrel",158987.295),
                            new MeasurementUnit(MeasurementType.Volume,"Peck",8809.768),
                            new MeasurementUnit(MeasurementType.Volume,"Bushel",35239.072),
                            new MeasurementUnit(MeasurementType.Volume,"Teaspoon",4.92892159),
                            new MeasurementUnit(MeasurementType.Volume,"Tablespoon",14.7867648),
                            new MeasurementUnit(MeasurementType.Volume,"Cup",236.588237)
                        }
                    );
            }
            measurementUnits = measurementUnitsFile.Load();

            StorageHelper<MeasurementObject> measurementObjectsFile = new StorageHelper<MeasurementObject>("MeasurementObjects.xml");
            if (!measurementObjectsFile.Exists())
            {
                measurementObjectsFile.Save(
                        new List<MeasurementObject>()
                        {
                            new MeasurementObject(MeasurementType.Mass,"Paper", 5000),
                            new MeasurementObject(MeasurementType.Mass,"Quarter", 5670),
                            new MeasurementObject(MeasurementType.Mass,"Pencil", 10000),
                            new MeasurementObject(MeasurementType.Mass,"CD", 60951.4747),
                            new MeasurementObject(MeasurementType.Mass,"Toothbrush", 90718),
                            new MeasurementObject(MeasurementType.Mass,"Soda", 240796),
                            new MeasurementObject(MeasurementType.Mass,"Brick", 2721554.22),
                            new MeasurementObject(MeasurementType.Mass,"Xbox360", 3492661.25),
                            new MeasurementObject(MeasurementType.Mass,"Bicycle", 13607771.1),
                            new MeasurementObject(MeasurementType.Mass,"Car", 1814369480),
                            new MeasurementObject(MeasurementType.Length,"Quarter",24.26),
                            new MeasurementObject(MeasurementType.Length,"Dollar",155.95600),
                            new MeasurementObject(MeasurementType.Length,"Pencil",177.8),
                            new MeasurementObject(MeasurementType.Length,"Paper",297),
                            new MeasurementObject(MeasurementType.Length,"Ruler",304.8),
                            new MeasurementObject(MeasurementType.Length,"Door",2032 ),
                            new MeasurementObject(MeasurementType.Length,"Bus",14630.4),
                            new MeasurementObject(MeasurementType.Length,"Storey",3657.6 ),
                            new MeasurementObject(MeasurementType.Length,"Football Field",91440),
                            new MeasurementObject(MeasurementType.Volume,"Drop",.05),
                            new MeasurementObject(MeasurementType.Volume,"Coffee Mug",177.42),
                            new MeasurementObject(MeasurementType.Volume,"Soda Can",355),
                            new MeasurementObject(MeasurementType.Volume,"Pitcher",1000),
                            new MeasurementObject(MeasurementType.Volume,"Sink",5000),
                            new MeasurementObject(MeasurementType.Volume,"Tub",200000),
                            new MeasurementObject(MeasurementType.Volume,"Pool",83358552.9 ),
                            new MeasurementObject(MeasurementType.Volume,"Lake",483509092000000000)
                        }
                    );
            }
            measurementObjects = measurementObjectsFile.Load();
            
            updateUi();
        }

        public void updateUi()
        {
            foreach (string name in EnumHelper.GetEnumStrings<MeasurementType>())
            {
                PanoramaItem mainPanoramaPage = new PanoramaItem() { Name = "mainPanoramaPage" + name, Header = name, Foreground = new SolidColorBrush(Colors.Black) };

                ScrollViewer scrollViewer = new ScrollViewer() { Name = "scrollViewer" + name, VerticalScrollBarVisibility = ScrollBarVisibility.Hidden};

                StackPanel innerStackPanel = new StackPanel() { Name = "innerStackPanel" + name };

                TextBlock fromTextBlock = new TextBlock() { Name = "fromTextBlock" + name, Text = "from" };

                TextBox inputTextBox = new TextBox() { Name = "inputTextBox" + name };
                inputTextBox.TextChanged += new TextChangedEventHandler(textChangedHandler);
                InputScopeNameValue numbersOnly = InputScopeNameValue.TelephoneNumber;
                inputTextBox.InputScope = new InputScope()
                {
                    Names = { new InputScopeName() { NameValue = numbersOnly } }
                };

                DataTemplate fromFullModeItemTemplate = (DataTemplate)XamlReader.Load("<DataTemplate xmlns='http://schemas.microsoft.com/client/2007'><TextBlock Text=\"{Binding Name}\" FontSize=\"64\"/></DataTemplate>");
                DataTemplate fromItemTemplate = (DataTemplate)XamlReader.Load("<DataTemplate xmlns='http://schemas.microsoft.com/client/2007'><TextBlock Text=\"{Binding Name}\"/></DataTemplate>");
                
                ListPicker fromListPicker = new ListPicker { Name = "fromListPicker" + name, FullModeItemTemplate = fromFullModeItemTemplate, ItemTemplate = fromItemTemplate };
                foreach (MeasurementUnit measurementUnit in measurementUnits)
                {
                    if (measurementUnit.Type.ToString().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        fromListPicker.Items.Add(measurementUnit);
                    }
                }
                fromListPicker.SelectionChanged += new SelectionChangedEventHandler(selectionChangedHandler);

                TextBlock toTextBlock = new TextBlock() { Name = "toTextBlock" + name, Text = "to" };

                DataTemplate toFullModeItemTemplate = (DataTemplate)XamlReader.Load("<DataTemplate xmlns='http://schemas.microsoft.com/client/2007'><TextBlock Text=\"{Binding Name}\" FontSize=\"64\"/></DataTemplate>");
                DataTemplate toItemTemplate = (DataTemplate)XamlReader.Load("<DataTemplate xmlns='http://schemas.microsoft.com/client/2007'><TextBlock Text=\"{Binding Name}\"/></DataTemplate>");

                ListPicker toListPicker = new ListPicker { Name = "toListPicker" + name, FullModeItemTemplate = toFullModeItemTemplate, ItemTemplate = toItemTemplate };
                foreach (MeasurementObject measurementObject in measurementObjects)
                {
                    if (measurementObject.Type.ToString().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        toListPicker.Items.Add(measurementObject);
                    }
                }
                toListPicker.SelectionChanged += new SelectionChangedEventHandler(selectionChangedHandler);

                TextBlock isAboutTextBlock = new TextBlock() { Name = "isAboutTextBlock" + name, Text = "is about", Visibility = System.Windows.Visibility.Collapsed };

                TextBlock resultTextBlock = new TextBlock() { Name = "resultTextBlock" + name, FontSize = 64, TextAlignment = System.Windows.TextAlignment.Center, Visibility = System.Windows.Visibility.Collapsed, TextWrapping = TextWrapping.Wrap };

                AdControl ad = new AdControl() { ApplicationId = "bb68fbc1-ad47-45b2-b045-0d5699d83b6b", AdUnitId = "10016008", Width = 300, Height = 50, Margin = new Thickness(20) };

                innerStackPanel.Children.Add(fromTextBlock);
                innerStackPanel.Children.Add(inputTextBox);
                innerStackPanel.Children.Add(fromListPicker);
                innerStackPanel.Children.Add(toTextBlock);
                innerStackPanel.Children.Add(toListPicker);
                innerStackPanel.Children.Add(isAboutTextBlock);
                innerStackPanel.Children.Add(resultTextBlock);
                innerStackPanel.Children.Add(ad);

                scrollViewer.Content = innerStackPanel;

                mainPanoramaPage.Content = scrollViewer;

                mainView.Items.Add(mainPanoramaPage);
            }
        }

        private void textChangedHandler(Object sender, TextChangedEventArgs e)
        {
            calculate(((TextBox)sender).Name.Replace("inputTextBox", ""));
        }

        private void selectionChangedHandler(Object sender, SelectionChangedEventArgs e)
        {
            calculate(((ListPicker)sender).Name.Replace("fromListPicker", "").Replace("toListPicker", ""));
        }

        private void calculate(String fromName)
        {
            foreach (string name in EnumHelper.GetEnumStrings<MeasurementType>())
            {
                if (fromName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    TextBox inputTextBox = (TextBox)this.FindName("inputTextBox" + fromName);
                    double input;
                    if (double.TryParse(inputTextBox.Text, out input))
                    {
                        TextBlock isAboutTextBlock = (TextBlock)this.FindName("isAboutTextBlock" + fromName);
                        isAboutTextBlock.Visibility = System.Windows.Visibility.Visible;

                        ListPicker fromListPicker = (ListPicker)this.FindName("fromListPicker" + fromName);
                        ListPicker toListPicker = (ListPicker)this.FindName("toListPicker" + fromName);

                        TextBlock resultTextBlock = (TextBlock)this.FindName("resultTextBlock" + fromName);
                        resultTextBlock.Text = String.Format("{0:0.##}", (input * ((MeasurementUnit)fromListPicker.SelectedItem).Value) / ((MeasurementObject)toListPicker.SelectedItem).Value) + " " + ((MeasurementObject)toListPicker.SelectedItem).Name + "(s)";
                        resultTextBlock.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        TextBlock isAboutTextBlock = (TextBlock)this.FindName("isAboutTextBlock" + fromName);
                        isAboutTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                        TextBlock resultTextBlock = (TextBlock)this.FindName("resultTextBlock" + fromName);
                        resultTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    break;
                }
            }
        }
    }
}