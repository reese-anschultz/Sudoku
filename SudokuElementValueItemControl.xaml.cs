using System.Windows;
using System.Windows.Controls;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for SudokuElementValueControl.xaml
    /// </summary>
    public partial class SudokuElementValueItemControl : UserControl
    {
        public static readonly DependencyProperty ElementValueProperty =
             DependencyProperty.Register("ElementValue",
                 typeof(SudokuElementSet<uint>.SudokuElementValue),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(new SudokuElementSet<uint>.SudokuElementValue(),FrameworkPropertyMetadataOptions.AffectsRender));
        public SudokuElementSet<uint>.SudokuElementValue ElementValue
        {
            get { return (SudokuElementSet<uint>.SudokuElementValue)GetValue(ElementValueProperty); }
            set { SetValue(ElementValueProperty, value); }
        }

        public static readonly DependencyProperty IndexXProperty =
             DependencyProperty.Register("IndexX",
                 typeof(int),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(default(int), FrameworkPropertyMetadataOptions.AffectsRender));
        public int IndexX
        {
            get { return (int)GetValue(IndexXProperty); }
            set { SetValue(IndexXProperty, value); }
        }

        public SudokuElementValueItemControl()
        {
            InitializeComponent();
            ElementValue = new SudokuElementSet<uint>.SudokuElementValue(ElementValue.ElementSet, ElementValue);
        }
    }
}
