using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DotNetCoreClock.Controls
{
    public delegate void TimeChangedEventHandler(object sender, TimeChangedEventArgs args);

    public class AnalogClock : Clock
    {
        private Line hourHand;
        private Line minuteHand;
        private Line secondHand;

        static AnalogClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
        }

        public override void OnApplyTemplate()
        {
            hourHand = Template.FindName("PART_HourHand", this) as Line;
            minuteHand = Template.FindName("PART_MinuteHand", this) as Line;
            secondHand = Template.FindName("PART_SecondHand", this) as Line;


            //ovako se radi binding u kodu:
            //Binding showSecondHandBinding = new Binding
            //{
            //    Path = new PropertyPath(nameof(ShowSeconds)),
            //    Source = this,
            //    Converter = new BooleanToVisibilityConverter()
            //};

            //secondHand.SetBinding(VisibilityProperty, showSecondHandBinding);

            base.OnApplyTemplate();
        }

        protected override void OnTimeChanged(DateTime time)
        {
            UpdateHandAngles(time);
            base.OnTimeChanged(time);
        }
        //private bool flag;
        //private void UpdateTimeState(DateTime time)
        //{
        //    //if (flag)
        //    if (time.Hour > 6 && time.Hour < 18)
        //    {
        //        VisualStateManager.GoToState(this, "Day", false);
        //    }
        //    else
        //    {
        //        VisualStateManager.GoToState(this, "Night", false);
        //    }
        //    flag = !flag;
        //}

        private void UpdateHandAngles(DateTime time)
        {
            hourHand.RenderTransform = new RotateTransform((time.Hour / 12.0) * 360, 0.5, 0.5);
            minuteHand.RenderTransform = new RotateTransform((time.Minute / 60.0) * 360, 0.5, 0.5);
            secondHand.RenderTransform = new RotateTransform((time.Second / 60.0) * 360, 0.5, 0.5);
        }
    }
}

