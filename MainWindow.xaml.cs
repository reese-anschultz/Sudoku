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
        public ClosedSudokuElementSet Es;

        public static readonly DependencyProperty NProperty =
             DependencyProperty.Register("N", typeof(string),
             typeof(MainWindow));
        public static readonly DependencyProperty EProperty =
             DependencyProperty.Register("E", typeof(ClosedSudokuElementSet.SudokuElementValue),
             typeof(MainWindow));
        public string N
        {
            get => (string)GetValue(NProperty);
            set => SetValue(NProperty, value);
        }
        public ClosedSudokuElementSet.SudokuElementValue E
        {
            get => (ClosedSudokuElementSet.SudokuElementValue)GetValue(EProperty);
            set => SetValue(EProperty, value);
        }

        public MainWindow()
        {
            const uint width = 3;
            const uint height = 2;
            var l = new List<ClosedSudokuElement>();
            for (uint ui = 0; ui < width * height; ++ui)
            {
                l.Add(new ClosedSudokuElement(ui));
            }
            Es = new ClosedSudokuElementSet(l);
            E = Es.MakeElementValue(Es.Value);  // All values
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
                    E = Es.MakeElementValue(new[] { Es.Value.First() });    // First value
                    break;
                case 1:
                    E = Es.MakeElementValue(new[] { Es.Value[1], Es.Value[2] }); // Second and third values
                    break;
                case 2:
                    E = Es.MakeElementValue(new ClosedSudokuElement[] { }); // No values
                    break;
                case 3:
                    E = Es.MakeElementValue(Es.Value);  // All values
                    break;
            }
        }
    }
}
