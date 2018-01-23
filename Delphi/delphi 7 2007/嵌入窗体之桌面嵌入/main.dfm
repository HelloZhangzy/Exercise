object FrmMain: TFrmMain
  Left = 324
  Top = 132
  Width = 170
  Height = 250
  Caption = #23884#20837#26700#38754
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 11
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 105
    Height = 11
    AutoSize = False
    Caption = #31532#19968#23618':'
  end
  object Label2: TLabel
    Left = 8
    Top = 56
    Width = 105
    Height = 11
    AutoSize = False
    Caption = #31532#20108#23618':'
  end
  object Label3: TLabel
    Left = 8
    Top = 104
    Width = 105
    Height = 11
    AutoSize = False
    Caption = #31532#19977#23618':'
  end
  object Btn1: TButton
    Left = 96
    Top = 24
    Width = 57
    Height = 25
    Caption = #23884#20837
    TabOrder = 0
    OnClick = Btn1Click
  end
  object Edt1: TEdit
    Left = 8
    Top = 24
    Width = 81
    Height = 19
    TabOrder = 1
    Text = 'http://tresss.com'
  end
  object BtnOwner: TButton
    Left = 8
    Top = 184
    Width = 145
    Height = 25
    Caption = #21462#28040#23884#20837
    TabOrder = 2
    OnClick = BtnOwnerClick
  end
  object Btn2: TButton
    Left = 96
    Top = 72
    Width = 57
    Height = 25
    Caption = #23884#20837
    TabOrder = 3
    OnClick = Btn2Click
  end
  object Edt2: TEdit
    Left = 8
    Top = 72
    Width = 81
    Height = 19
    TabOrder = 4
    Text = 'http://tresss.com'
  end
  object Btn3: TButton
    Left = 96
    Top = 120
    Width = 57
    Height = 25
    Caption = #23884#20837
    TabOrder = 5
    OnClick = Btn3Click
  end
  object Edt3: TEdit
    Left = 8
    Top = 120
    Width = 81
    Height = 19
    TabOrder = 6
    Text = 'http://tresss.com'
  end
  object BtnRnd: TButton
    Left = 8
    Top = 152
    Width = 145
    Height = 25
    Caption = #23884#20837#24182#38480#21046#26700#38754#22823#23567
    TabOrder = 7
    OnClick = BtnRndClick
  end
  object Timer1: TTimer
    Interval = 20000
    OnTimer = Timer1Timer
    Left = 56
    Top = 96
  end
end
