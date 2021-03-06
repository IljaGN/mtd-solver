﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MTD_Solver.View.Components
{
  public partial class MtdInput : UserControl
  {
    public string Value
    {
      get { return (string)GetValue(ValueProperty); }
      set { SetValue(ValueProperty, value); }
    }
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
      nameof(Value),
      typeof(string),
      typeof(MtdInput),
      new PropertyMetadata("0", new PropertyChangedCallback(OnValueChanged))
      );

    public bool ReadOnly
    {
      get { return (bool)GetValue(ReadOnlyProperty); }
      set { SetValue(ReadOnlyProperty, value); }
    }

    public static readonly DependencyProperty ReadOnlyProperty = DependencyProperty.Register(
      nameof(ReadOnly),
      typeof(bool),
      typeof(MtdInput),
      new PropertyMetadata(false)
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
      new PropertyMetadata(string.Empty)
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
      new PropertyMetadata(string.Empty)
      );

    private readonly char MIN_DECIMAL_DIGIT;
    private readonly char DECIMAL_SEPARATOR;
    private readonly char NEGATIVE_SIGN;

    public MtdInput()
    {
      InitializeComponent();
      textBox.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPaste));

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
      int previousIndexChr = textBox.CaretIndex - 1;
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
      return IsValidCharForPrint(chr, textBox) && !IsPossibleToBanInputMinDigit(chr, textBox);
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

    public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
        nameof(ValueChanged),
        RoutingStrategy.Bubble,
        typeof(RoutedPropertyChangedEventHandler<string>),
        typeof(MtdInput)
      );

    public event RoutedPropertyChangedEventHandler<string> ValueChanged
    {
      add { AddHandler(ValueChangedEvent, value); }
      remove { RemoveHandler(ValueChangedEvent, value); }
    }

    private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
      MtdInput control = obj as MtdInput;
      control.OnValueChanged(new RoutedPropertyChangedEventArgs<string>(
          (string)args.OldValue,
          (string)args.NewValue,
          ValueChangedEvent
          ));
    }

    protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<string> args)
    {
      RaiseEvent(args);
    }

    private void OnPaste(object sender, ExecutedRoutedEventArgs e)
    {
      if (!Clipboard.ContainsText())
      {
        return;
      }

      string clipboardText = Clipboard.GetText();
      char chr = clipboardText.FirstOrDefault(c => !char.IsDigit(c) && c != NEGATIVE_SIGN);
      string text = chr == '\0' ? clipboardText : clipboardText.Replace(chr, DECIMAL_SEPARATOR);
      try
      {
        double dbl = double.Parse(text);
        textBox.Text = dbl.ToString();
      }
      catch (Exception) { }
    }
  }
}
