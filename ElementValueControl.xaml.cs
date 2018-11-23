using System.Linq;
using System.Windows;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for ElementValueControl.xaml
    /// </summary>
    public partial class ElementValueControl //: UserControl
    {
        public static readonly DependencyProperty ElementValueProperty =
             DependencyProperty.Register("ElementValue",
                 typeof(ElementValue<ClosedElement>),
                 typeof(ElementValueControl),
                 new FrameworkPropertyMetadata(new ElementValue<ClosedElement>(), FrameworkPropertyMetadataOptions.AffectsRender));
        public ElementValue<ClosedElement> ElementValue
        {
            get => (ElementValue<ClosedElement>)GetValue(ElementValueProperty);
            set => SetValue(ElementValueProperty, value);
        }

        public ElementValueControl()
        {
            InitializeComponent();
            // Make a clone of the default ElementValue so that each control instance does not share the default instance
            ElementValue = new ElementValue<ClosedElement>(ElementValue.ReferenceElementSet, ElementValue.ToArray());
        }
    }
}
