using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace WpfSnake
{
    /// <summary>
    /// Interaction logic for CustomButton.xaml
    /// </summary>
    public partial class CustomButton : UserControl
    {
        public CustomButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #region Private Variables
        private Brush _TextBrush;
        #endregion

        #region Text Property
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CustomButton), null);
        #endregion

        #region Mouse Events
        // NOTE: You must use the FindResource() method and not the Resources[] collection
        // because we are using Dynamic styles that may be set at the application level
        private void CustomButtonBorderStyle_MouseEnter(object sender, MouseEventArgs e)
        {
            CustomButtonBorderStyle.Background = (Brush)this.FindResource("CustomButtonOverStyle");
        }

        private void CustomButtonBorderStyle_MouseLeave(object sender, MouseEventArgs e)
        {
            CustomButtonBorderStyle.Background = (Brush)this.FindResource("CustomButtonNormalStyle");
        }

        private void CustomButtonBorderStyle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Save old Foreground Brush
            _TextBrush = tbText.Foreground;

            CustomButtonBorderStyle.Background = (Brush)this.FindResource("CustomButtonPressedStyle");
            tbText.Foreground = (SolidColorBrush)this.FindResource("CustomButtonTextBlockStylePressed");
        }

        private void CustomButtonBorderStyle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RestoreNormal();
        }

        private void RestoreNormal()
        {
            CustomButtonBorderStyle.Background = (Brush)FindResource("CustomButtonNormalStyle");

            tbText.Foreground = _TextBrush;
        }
        #endregion

        #region Click Event Procedure
        private void CustomButtonBorderStyle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseClick(e);
        }

        public delegate void ClickEventHandler(object sender, RoutedEventArgs e);
        public event ClickEventHandler Click;

        protected void RaiseClick(RoutedEventArgs e)
        {
            if (null != Click)
                Click(this, e);

            RestoreNormal();
        }
    }
    #endregion
}
