using System.Linq;
using System.Windows;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for ElementValueControl.xaml
    /// </summary>
    public partial class ElementValueItemControl
    {
        public static readonly DependencyProperty ElementValueProperty =
             DependencyProperty.Register("ElementValue",
                 typeof(ElementValue<ClosedElement>),
                 typeof(ElementValueItemControl),
                 new FrameworkPropertyMetadata(new ElementValue<ClosedElement>(), FrameworkPropertyMetadataOptions.AffectsRender));
        public ElementValue<ClosedElement> ElementValue
        {
            get => (ElementValue<ClosedElement>)GetValue(ElementValueProperty);
            set => SetValue(ElementValueProperty, value);
        }

        public static readonly DependencyProperty ElementProperty =
             DependencyProperty.Register("Element",
                 typeof(ClosedElement),
                 typeof(ElementValueItemControl),
                 new FrameworkPropertyMetadata(default(ClosedElement), FrameworkPropertyMetadataOptions.AffectsRender));
        public ClosedElement Element
        {
            get => (ClosedElement)GetValue(ElementProperty);
            set => SetValue(ElementProperty, value);
        }

        public ElementValueItemControl()
        {
            InitializeComponent();
            // Make a clone of the default ElementValue so that each control instance does not share the default instance
            ElementValue = new ElementValue<ClosedElement>(ElementValue.ReferenceElementSet, ElementValue.ToArray());
        }
    }
}
