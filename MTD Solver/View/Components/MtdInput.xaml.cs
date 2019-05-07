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

namespace MTD_Solver.View.Components
{
  public partial class MtdInput : UserControl
  {
    public double Value
    {
      get { return (double)GetValue(ValueProperty); }
      set { SetValue(ValueProperty, value); }
    }
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
      "Value",
      typeof(double),
      typeof(MtdInput),
      new FrameworkPropertyMetadata(0D) //new PropertyChangedCallback(OnValueChanged)
      );

    public string Title
    {
      get { return (string)GetValue(TitleProperty); }
      set { SetValue(TitleProperty, value); }
    }
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
      "Title",
      typeof(string),
      typeof(MtdInput),
      new PropertyMetadata("")
      );

    public MtdInput()
    {
      InitializeComponent();
    }
    //public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
    //    "ValueChanged",
    //    RoutingStrategy.Bubble,
    //    typeof(RoutedPropertyChangedEventHandler<double>),
    //    typeof(MtdInput_2)
    //  );

    //public event RoutedPropertyChangedEventHandler<double> ValueChanged
    //{
    //  add { AddHandler(ValueChangedEvent, value); }
    //  remove { RemoveHandler(ValueChangedEvent, value); }
    //}

    //private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    //{
    //  //MtdInput_2 control = (MtdInput_2)obj;

    //  //RoutedPropertyChangedEventArgs<double> e = new RoutedPropertyChangedEventArgs<double>(
    //  //    (double)args.OldValue, (double)args.NewValue, ValueChangedEvent);
    //  //control.OnValueChanged(e);
    //}

    //protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<double> args)
    //{
    //  RaiseEvent(args);
    //}
  }
}
