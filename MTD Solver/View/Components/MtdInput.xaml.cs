using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
      nameof(Value),
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
      nameof(Title),
      typeof(string),
      typeof(MtdInput),
      new PropertyMetadata("")
      );

    public string Unit
    {
      get { return (string)GetValue(UnitProperty); }
      set { SetValue(UnitProperty, value); }
    }
    public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
      nameof(Unit),
      typeof(string),
      typeof(MtdInput),
      new PropertyMetadata("")
      );

    private readonly char MIN_DECIMAL_DIGIT;
    private readonly char DECIMAL_SEPARATOR;
    private readonly char NEGATIVE_SIGN;

    public MtdInput()
    {
      InitializeComponent();
      NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
      MIN_DECIMAL_DIGIT = numberFormat.NativeDigits[0][0];
      DECIMAL_SEPARATOR = numberFormat.NumberDecimalSeparator[0];
      NEGATIVE_SIGN = numberFormat.NegativeSign[0];
    }

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      TextBox box = sender as TextBox;
      string originalText = box.Text;
      e.Handled = HandleChar(e.Text[0], box);
      PlayWarningSound(e.Handled && originalText == box.Text);
    }

    private bool HandleChar(char inputChar, TextBox box)
    {
      if (inputChar == NEGATIVE_SIGN)
      {
        AddOrRemoveNegativeSign(box);
        return true;
      }

      if (IsPossibleReplaceCharWithSeparator(inputChar, box))
      {
        string ds = DECIMAL_SEPARATOR.ToString();
        SetTextAndMoveCaret(box, box.Text.Insert(box.CaretIndex, ds));
        return true;
      }

      if (IsPossibleInsertSeparator(inputChar, box))
      {
        SetTextAndMoveCaret(box, box.Text + DECIMAL_SEPARATOR);
      }

      return !IsPrintChar(inputChar, box);
    }

    private void AddOrRemoveNegativeSign(TextBox textBox)
    {
      if (textBox.Text.Contains(NEGATIVE_SIGN))
      {
        int caretIndex = textBox.CaretIndex;
        textBox.Text = textBox.Text.Substring(1);
        textBox.CaretIndex = DecreaseIndex(caretIndex);
        return;
      }

      SetTextAndMoveCaret(textBox, NEGATIVE_SIGN + textBox.Text);
    }

    private void SetTextAndMoveCaret(TextBox textBox, string text)
    {
      int caretIndex = textBox.CaretIndex;
      textBox.Text = text;
      textBox.CaretIndex = ++caretIndex;
    }

    private bool IsPossibleReplaceCharWithSeparator(char chr, TextBox textBox)
    {
      bool isValidChar = IsValidCharForPrint(DECIMAL_SEPARATOR, textBox);
      return !char.IsDigit(chr) && chr != NEGATIVE_SIGN && isValidChar;
    }

    private bool IsValidCharForPrint(char chr, TextBox textBox)
    {
      int caretIndex = textBox.CaretIndex;
      string text = textBox.Text;
      bool isInputBeforeNegativeSign = text.IndexOf(NEGATIVE_SIGN) == 0 && caretIndex == 0;
      bool isAllowableInputForDigit = char.IsDigit(chr) && !isInputBeforeNegativeSign;
      bool isAllowedPrintSeparator = chr == DECIMAL_SEPARATOR && !text.Contains(DECIMAL_SEPARATOR)
        && caretIndex != 0 && char.IsDigit(text[DecreaseIndex(caretIndex)]);
      return isAllowableInputForDigit || isAllowedPrintSeparator;
    }

    private bool IsPossibleInsertSeparator(char chr, TextBox textBox)
    {
      int previousIndexChr  = textBox.CaretIndex - 1;
      int allowableLength = 1 + Convert.ToInt32(textBox.Text.Contains(NEGATIVE_SIGN));
      return char.IsDigit(chr) && !textBox.Text.Contains(DECIMAL_SEPARATOR)
        && textBox.Text.Length == allowableLength && previousIndexChr > -1
        && textBox.Text[previousIndexChr] == MIN_DECIMAL_DIGIT;
    }

    private bool IsPossibleToBanInputMinDigit(char chr, TextBox textBox)
    {
      int allowableCaretIndex = Convert.ToInt32(textBox.Text.Contains(NEGATIVE_SIGN));
      return chr == MIN_DECIMAL_DIGIT && textBox.Text.Contains(DECIMAL_SEPARATOR)
        && textBox.CaretIndex == allowableCaretIndex;
    }

    private bool IsPrintChar(char chr, TextBox textBox)
    {
      return !IsPossibleToBanInputMinDigit(chr, textBox) && IsValidCharForPrint(chr, textBox);
    }

    private void PlayWarningSound(bool play)
    {
      if (play)
      {
        System.Media.SystemSounds.Hand.Play();
      }
    }

    private int DecreaseIndex(int index)
    {
      return --index < 0 ? 0 : index;
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
