using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotNetCoreClock.Controls
{
    /// <summary>
    /// Interaction logic for ControlableClock.xaml
    /// </summary>
    public partial class ControlableClock : UserControl
    {


        public Clock Clock
        {
            get { return (Clock)GetValue(ClockProperty); }
            set { SetValue(ClockProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clock.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClockProperty =
            DependencyProperty.Register("Clock", typeof(Clock), typeof(ControlableClock), new PropertyMetadata(null));




        public ControlableClock()
        {
            InitializeComponent();
        }

        private void ClockType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbClockType.SelectedValue.ToString())
            {
                case "Analog":
                    Clock = new AnalogClock();
                    break;
                case "Digital":
                    Clock = new DigitalClock()
                    {
                        FontSize = 36
                    };
                    break;
            }
        }
    }
}

