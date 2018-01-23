object Form1: TForm1
  Left = 0
  Top = 0
  BorderStyle = bsNone
  Caption = 'Form1'
  ClientHeight = 390
  ClientWidth = 684
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  KeyPreview = True
  OldCreateOrder = False
  Position = poDesigned
  OnKeyDown = FormKeyDown
  PixelsPerInch = 96
  TextHeight = 13
  object SpeedButton1: TSpeedButton
    Left = 40
    Top = 358
    Width = 89
    Height = 24
    Caption = #27169#25311#28857#20987#27979#35797#28857
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    Visible = False
    OnClick = SpeedButton1Click
  end
  object SpeedButton2: TSpeedButton
    Left = 156
    Top = 358
    Width = 93
    Height = 24
    Caption = #27979#35797#28857
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    Visible = False
    OnClick = SpeedButton2Click
  end
  object Label1: TLabel
    Left = 554
    Top = 269
    Width = 24
    Height = 13
    Caption = #22352#26631
  end
  object Label2: TLabel
    Left = 540
    Top = 288
    Width = 18
    Height = 13
    Caption = 'X'#65306
  end
  object Label3: TLabel
    Left = 540
    Top = 309
    Width = 18
    Height = 13
    Caption = 'Y'#65306
  end
  object Label4: TLabel
    Left = 8
    Top = 274
    Width = 48
    Height = 19
    Caption = #22320#22336#65306
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 458
    Top = 333
    Width = 231
    Height = 18
    Caption = #24320#22987#22352#26631#25429#33719#21518#65292#25353'Ctrl'#38190#21462#22352#26631#65281
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label6: TLabel
    Left = 62
    Top = 278
    Width = 84
    Height = 13
    Caption = #19981#25903#25345#28378#21160#26465#65281
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clFuchsia
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Edit1: TEdit
    Left = 8
    Top = 297
    Width = 363
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Text = 'http://baidu.com'
  end
  object Button1: TButton
    Left = 377
    Top = 271
    Width = 75
    Height = 56
    Caption = #25171#24320#32593#39029
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    OnClick = Button1Click
  end
  object Edit2: TEdit
    Left = 554
    Top = 285
    Width = 40
    Height = 21
    TabOrder = 2
    Text = '0'
  end
  object Edit3: TEdit
    Left = 554
    Top = 306
    Width = 40
    Height = 21
    TabOrder = 3
    Text = '0'
  end
  object Button2: TButton
    Left = 600
    Top = 271
    Width = 75
    Height = 56
    Caption = #27979#35797#28857#20987#22352#26631
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 288
    Top = 353
    Width = 75
    Height = 29
    Caption = #20572#27490#22352#26631#25429#33719
    TabOrder = 5
    Visible = False
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 0
    Top = 360
    Width = 684
    Height = 30
    Align = alBottom
    Caption = #20851#38381#31243#24207
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    OnClick = Button4Click
  end
  object WebBrowser1: TWebBrowser
    Left = 0
    Top = 0
    Width = 684
    Height = 265
    Align = alTop
    TabOrder = 7
    OnEnter = WebBrowser1Enter
    OnNewWindow2 = WebBrowser1NewWindow2
    OnDocumentComplete = WebBrowser1DocumentComplete
    ExplicitWidth = 691
    ControlData = {
      4C0000006B470000631B00000000000000000000000000000000000000000000
      000000004C000000000000000000000001000000E0D057007335CF11AE690800
      2B2E126208000000000000004C0000000114020000000000C000000000000046
      8000000000000000000000000000000000000000000000000000000000000000
      00000000000000000100000000000000000000000000000000000000}
  end
  object Button5: TButton
    Left = 458
    Top = 271
    Width = 75
    Height = 56
    Caption = #24320#22987#22352#26631#25429#33719
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 8
    OnClick = Button5Click
  end
  object Timer1: TTimer
    Enabled = False
    OnTimer = Timer1Timer
    Left = 136
    Top = 336
  end
  object Timer2: TTimer
    Enabled = False
    OnTimer = Timer2Timer
    Left = 96
    Top = 336
  end
  object Timer3: TTimer
    Enabled = False
    Interval = 1
    OnTimer = Timer3Timer
    Left = 56
    Top = 336
  end
end
