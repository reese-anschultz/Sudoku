using System;
using System.Windows;
using System.Windows.Data;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for ElementValueItemsControl.xaml
    /// </summary>
    public partial class ElementValueItemsControl //: UserControl
    {
        public static readonly DependencyProperty ElementValueProperty =
            DependencyProperty.Register("ElementValue",
                typeof(ElementValue<ClosedElement>),
                typeof(ElementValueItemsControl),
                new FrameworkPropertyMetadata(new ElementValue<ClosedElement>(), FrameworkPropertyMetadataOptions.AffectsRender, OnValueChanged));
        public ElementValue<ClosedElement> ElementValue
        {
            get => (ElementValue<ClosedElement>)GetValue(ElementValueProperty);
            set => SetValue(ElementValueProperty, value);
        }
        public ElementValueItemsControl()
        {
            InitializeComponent();
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            int LargestShortSide(int n)
            {
                var n1 = (int)Math.Sqrt(n);
                while (n % n1 != 0)
                    --n1;

                return n1;

            }
            var thisElementValueItemsControl = (ElementValueItemsControl)obj;
            var uniformGrid = thisElementValueItemsControl.Grid;
            uniformGrid.Children.Clear();
            var size = thisElementValueItemsControl.ElementValue.ReferenceElementSet.Elements.Count;
            uniformGrid.Rows = LargestShortSide(size);
            uniformGrid.Columns = size / uniformGrid.Rows;
            // Add an ElementValueItemControl for each possible choice in the reference set
            foreach (var element in thisElementValueItemsControl.ElementValue.ReferenceElementSet.Elements)
            {
                var binding = new Binding
                {
                    Source = thisElementValueItemsControl,
                    Path = new PropertyPath("ElementValue"),
                };
                var valueItem = new ElementValueItemControl
                {
                    Element = element,
                };
                valueItem.SetBinding(ElementValueItemControl.ElementValueProperty, binding);
                uniformGrid.Children.Add(valueItem);
            }
        }
    }
}
