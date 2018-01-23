object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 247
  ClientWidth = 338
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 143
    Top = 8
    Width = 75
    Height = 25
    Caption = #21516#27493
    TabOrder = 0
    OnClick = Button1Click
  end
  object ListBox1: TListBox
    Left = 0
    Top = 0
    Width = 121
    Height = 247
    Align = alLeft
    ItemHeight = 13
    TabOrder = 1
    ExplicitLeft = 128
    ExplicitTop = 56
    ExplicitHeight = 97
  end
  object Button2: TButton
    Left = 143
    Top = 39
    Width = 75
    Height = 25
    Caption = #30417#25511#36827#31243#29366#24577
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 143
    Top = 70
    Width = 75
    Height = 25
    Caption = #20114#26021
    TabOrder = 3
    OnClick = Button3Click
  end
  object Memo1: TMemo
    Left = 231
    Top = 0
    Width = 105
    Height = 247
    Color = clWhite
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    Lines.Strings = (
      #21516#27493#65306#23601#20687#20196#29260
      #31995#32479#19968#26679#12290#24403#32447
      #31243#25345#26377#20196#29260#25165#21487
      #20197#25191#34892#65292#20854#20182#27809
      #26377#21017#38656#35201#31561#24453#12290
      #21482#26159#20196#29260#30340#20132#25509
      #38656#35201#25345#20196#29260#32447#31243
      #25191#34892#23436#25104#21518#25165#20250
      #20132#20184#20986#21435#12290
      #20114#26021#65306#23601#20687#24490#29615
      #20196#29260#19968#26679#65292#22312#26576
      #19968#26102#21051#26576#19968#29366#24577
      #26102#21482#33021#26377#19968#20010#32447
      #31243#25345#26377#20196#29260#65292#24403
      #24403#21069#29366#24577#21457#29983#25913
      #21464#26102#23601#38656#35201#23558#20196
      #29260#20132#20184#32473#19979#19968#20010
      #32447#31243#12290)
    ParentFont = False
    ReadOnly = True
    TabOrder = 4
  end
end
