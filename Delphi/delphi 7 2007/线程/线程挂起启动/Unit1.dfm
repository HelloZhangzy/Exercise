object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 224
  ClientWidth = 254
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnMouseUp = GroupBox1MouseUp
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 8
    Top = 0
    Width = 75
    Height = 25
    Caption = 'Create'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 89
    Top = 0
    Width = 75
    Height = 25
    Caption = 'Resume'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 170
    Top = 0
    Width = 75
    Height = 25
    Caption = 'Suspend'
    TabOrder = 2
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 178
    Top = 200
    Width = 75
    Height = 25
    Caption = 'threadvar'
    TabOrder = 3
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 104
    Top = 200
    Width = 75
    Height = 25
    Caption = 'var'
    TabOrder = 4
    OnClick = Button5Click
  end
  object Timer1: TTimer
    Enabled = False
    OnTimer = Timer1Timer
    Left = 152
    Top = 8
  end
end
