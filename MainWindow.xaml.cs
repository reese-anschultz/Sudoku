using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public ElementSet<ClosedElement> Es;

        public static readonly DependencyProperty NProperty =
             DependencyProperty.Register("N", typeof(string),
             typeof(MainWindow));
        public static readonly DependencyProperty EProperty =
             DependencyProperty.Register("E", typeof(ElementValue<ClosedElement>),
             typeof(MainWindow));
        public string N
        {
            get => (string)GetValue(NProperty);
            set => SetValue(NProperty, value);
        }
        public ElementValue<ClosedElement> E
        {
            get => (ElementValue<ClosedElement>)GetValue(EProperty);
            set => SetValue(EProperty, value);
        }

        public MainWindow()
        {
            const uint width = 3;
            const uint height = 2;
            var l = new List<ClosedElement>();
            for (uint ui = 0; ui < width * height; ++ui)
            {
                l.Add(new ClosedElement(ui));
            }
            Es = new ElementSet<ClosedElement>(l);
            E = new ElementValue<ClosedElement>(Es, Es.Elements.ToArray());
            N = "0";
            InitializeComponent();
        }

        static int _n;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                N = System.Convert.ToString(System.Convert.ToInt32(N) + 1);
            }
            catch
            {
                N = "0";
            }
            switch (_n++)
            {
                case 0:
                    E = new ElementValue<ClosedElement>(Es, new[] { Es.Elements.First() }); // First value
                    break;
                case 1:
                    E = new ElementValue<ClosedElement>(Es, new[] { Es.Elements[1], Es.Elements[2] }); // Second and third values
                    break;
                case 2:
                    E = new ElementValue<ClosedElement>(Es, new ClosedElement[] { }); // No values
                    break;
                case 3:
                    E = new ElementValue<ClosedElement>(Es, Es.Elements.ToArray()); // All values
                    break;
            }
        }
    }
}
