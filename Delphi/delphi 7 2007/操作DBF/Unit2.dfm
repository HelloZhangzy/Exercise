object Form2: TForm2
  Left = 0
  Top = 0
  Caption = 'Form2'
  ClientHeight = 433
  ClientWidth = 1059
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object DBGrid1: TDBGrid
    Left = 8
    Top = 0
    Width = 1049
    Height = 369
    DataSource = DataSource1
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object Button1: TButton
    Left = 328
    Top = 392
    Width = 75
    Height = 25
    Caption = #34920'1'#25554#25968#25454
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 424
    Top = 392
    Width = 75
    Height = 25
    Caption = #21019#24314'temp'
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 520
    Top = 392
    Width = 89
    Height = 25
    Caption = #25554#20837#24182#26597#35810'temp'
    TabOrder = 3
    OnClick = Button3Click
  end
  object ADOConnection1: TADOConnection
    LoginPrompt = False
    Provider = 'SQLOLEDB'
    Left = 64
    Top = 224
  end
  object ADOTable1: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    LockType = ltReadOnly
    TableName = 'sample18'
    Left = 48
    Top = 320
  end
  object DataSource1: TDataSource
    DataSet = ADOTable1
    Left = 96
    Top = 280
  end
  object ADOQuery1: TADOQuery
    Connection = ADOConnection1
    Parameters = <>
    Left = 128
    Top = 304
  end
end
