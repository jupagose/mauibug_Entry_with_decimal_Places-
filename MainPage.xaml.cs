
namespace MauiTests
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        #region MyDecimalValue
        public decimal MyDecimalValue
        {
            get => (decimal)GetValue(MyDecimalValueProperty);
            set => SetValue(MyDecimalValueProperty, value);
        }
        public static readonly BindableProperty MyDecimalValueProperty =
            BindableProperty.Create(nameof(MyDecimalValue), typeof(decimal), typeof(MainPage), propertyChanged: OnMyDecimalValueChanged);

        private static void OnMyDecimalValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MainPage p)
            {
                p.Copy1 = p.MyDecimalValue;
                p.Copy2 = p.MyDecimalValue;
            }
        }
        #endregion

        #region Copia 1
        public decimal Copy1
        {
            get => (decimal)GetValue(Copy1Property);
            set => SetValue(Copy1Property, value);
        }
        public static readonly BindableProperty Copy1Property =
            BindableProperty.Create(nameof(Copy1), typeof(decimal), typeof(MainPage));
        #endregion

        #region Copia 2
        public decimal Copy2
        {
            get => (decimal)GetValue(Copy2Property);
            set => SetValue(Copy2Property, value);
        }
        public static readonly BindableProperty Copy2Property =
            BindableProperty.Create(nameof(Copy2), typeof(decimal), typeof(MainPage));

        #endregion
       
        public MainPage()
        {
            InitializeComponent();
            MyDecimalValue = 1.0m;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            MyDecimalValue = count * 1.0m;
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}