object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 254
  ClientWidth = 480
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Memo1: TMemo
    Left = 0
    Top = 39
    Width = 480
    Height = 215
    Align = alBottom
    Lines.Strings = (
      'Memo1')
    TabOrder = 0
  end
  object Button1: TButton
    Left = 8
    Top = 8
    Width = 121
    Height = 25
    Caption = 'Test'
    TabOrder = 1
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 135
    Top = 12
    Width = 98
    Height = 21
    TabOrder = 2
    Text = '3'
  end
end
