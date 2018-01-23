object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 566
  ClientWidth = 690
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Memo1: TMemo
    Left = 0
    Top = 73
    Width = 690
    Height = 493
    Align = alClient
    Lines.Strings = (
      'Memo1')
    TabOrder = 0
  end
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 690
    Height = 73
    Align = alTop
    TabOrder = 1
    object edt1: TEdit
      Left = 64
      Top = 27
      Width = 273
      Height = 21
      TabOrder = 0
      Text = '100'
    end
    object btn1: TButton
      Left = 359
      Top = 25
      Width = 106
      Height = 25
      Caption = #21387#32553
      TabOrder = 1
      OnClick = btn1Click
    end
    object Button1: TButton
      Left = 471
      Top = 25
      Width = 106
      Height = 25
      Caption = #35299#21387
      TabOrder = 2
      OnClick = Button1Click
    end
  end
end
