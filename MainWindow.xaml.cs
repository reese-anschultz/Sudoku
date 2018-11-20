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

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SudokuElementSet<uint> Es;

        public static readonly DependencyProperty NProperty =
             DependencyProperty.Register("N", typeof(string),
             typeof(MainWindow));
        public static readonly DependencyProperty EProperty =
             DependencyProperty.Register("E", typeof(SudokuElementSet<uint>.SudokuElementValue),
             typeof(MainWindow));
        public string N
        {
            get { return (string)GetValue(NProperty); }
            set { SetValue(NProperty, value); }
        }
        public SudokuElementSet<uint>.SudokuElementValue E
        {
            get { return (SudokuElementSet<uint>.SudokuElementValue)GetValue(EProperty); }
            set { SetValue(EProperty, value); }
        }

        public MainWindow()
        {
            const uint width = 3;
            const uint height = 2;
            if (width * height > 9)
                throw new Exception("Combination of width and height are too large");

            var l = new List<SudokuElement<uint>>();
            for (uint ui = 0; ui < width * height; ++ui)
            {
                l.Add(new SudokuElement<uint>(ui/*.ToString()*/));
            }
            Es = new SudokuElementSet<uint>(l);
            E = Es.MakeElementValue(Es.Value);  // All values
            N = "InitializedInMainWindow";
            InitializeComponent();
        }

        static int n = 0;
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
            switch (n++)
            {
                case 0:
                    E = Es.MakeElementValue(new SudokuElement<uint>[] { Es.Value.First() });    // First value
                    break;
                case 1:
                    E = Es.MakeElementValue(new SudokuElement<uint>[] { Es.Value[1], Es.Value[2] }); // Second and third values
                    break;
                case 2:
                    E = Es.MakeElementValue(new SudokuElement<uint>[] { }); // No values
                    break;
                case 3:
                    E = Es.MakeElementValue(Es.Value);  // All values
                    break;
            }
        }
    }
}
