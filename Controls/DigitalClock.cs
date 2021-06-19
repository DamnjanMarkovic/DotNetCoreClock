using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DotNetCoreClock.Controls
{
    public class DigitalClock : Clock
    {
        private UIElement colon;

        static DigitalClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalClock),
                new FrameworkPropertyMetadata(typeof(DigitalClock)));
        }

        public bool ColonBlink
        {
            get { return (bool)GetValue(ColonBlinkProperty); }
            set { SetValue(ColonBlinkProperty, value); }
        }
        public static readonly DependencyProperty ColonBlinkProperty =
            DependencyProperty.Register("ColonBlink", typeof(bool), typeof(DigitalClock), new PropertyMetadata(true));

        public override void OnApplyTemplate()
        {
            colon = Template.FindName("PART_Colon", this) as UIElement;

            base.OnApplyTemplate();
        }

        protected override void OnTimeChanged(DateTime newTime)
        {
            if (colon != null)
            {
                if (ColonBlink && !ShowSeconds)
                {
                    colon.Visibility = colon.IsVisible ? Visibility.Hidden : Visibility.Visible;
                }
                else
                {
                    colon.Visibility = Visibility.Visible;
                }
            }
            base.OnTimeChanged(newTime);
        }

    }
}