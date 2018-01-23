object Form1: TForm1
  Left = 360
  Top = 260
  Width = 1086
  Height = 595
  AlphaBlend = True
  Caption = 'Form1'
  Color = clSilver
  TransparentColorValue = clSilver
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 335
    Top = 191
    Width = 221
    Height = 191
    Caption = 'Panel1'
    TabOrder = 0
    OnMouseDown = Panel1MouseDown
    OnMouseMove = Panel1MouseMove
  end
  object Panel2: TPanel
    Left = 197
    Top = 36
    Width = 227
    Height = 168
    Caption = 'Panel2'
    TabOrder = 1
  end
  object Button1: TButton
    Left = 608
    Top = 120
    Width = 75
    Height = 25
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
end
