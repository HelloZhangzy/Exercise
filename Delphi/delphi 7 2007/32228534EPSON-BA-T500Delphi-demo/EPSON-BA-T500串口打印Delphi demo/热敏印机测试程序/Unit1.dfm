object Form1: TForm1
  Left = 240
  Top = 134
  BorderStyle = bsDialog
  Caption = #28909#25935#25171#21360#26426#27979#35797#31243#24207
  ClientHeight = 212
  ClientWidth = 258
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 112
    Top = 472
    Width = 60
    Height = 13
    BiDiMode = bdLeftToRight
    Caption = #25171#21360#26426#29366#24577
    ParentBiDiMode = False
    Layout = tlCenter
  end
  object Label2: TLabel
    Left = 112
    Top = 568
    Width = 48
    Height = 13
    Caption = #25509#25910#25968#25454
  end
  object Label3: TLabel
    Left = 120
    Top = 800
    Width = 48
    Height = 13
    Caption = #21457#36865#25968#25454
  end
  object Button1: TButton
    Left = 8
    Top = 16
    Width = 75
    Height = 25
    Caption = #25171#24320#20018#21475
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 96
    Top = 16
    Width = 75
    Height = 25
    Caption = #20851#38381#20018#21475
    Enabled = False
    TabOrder = 1
    OnClick = Button2Click
  end
  object Memo1: TMemo
    Left = 112
    Top = 592
    Width = 505
    Height = 161
    TabOrder = 2
  end
  object Edit1: TEdit
    Left = 232
    Top = 472
    Width = 121
    Height = 21
    ReadOnly = True
    TabOrder = 3
  end
  object Memo2: TMemo
    Left = 112
    Top = 824
    Width = 505
    Height = 161
    Lines.Strings = (
      '')
    TabOrder = 4
  end
  object Button3: TButton
    Left = 536
    Top = 992
    Width = 75
    Height = 25
    Caption = #21457#36865
    TabOrder = 5
    OnClick = Button3Click
  end
  object CheckBox1: TCheckBox
    Left = 112
    Top = 992
    Width = 113
    Height = 17
    Caption = #21313#20845#36827#21046#21457#36865
    TabOrder = 6
  end
  object Button4: TButton
    Left = 536
    Top = 760
    Width = 75
    Height = 25
    Caption = #28165#31354
    TabOrder = 7
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 32
    Top = 72
    Width = 75
    Height = 25
    Caption = #21021#22987#21270
    TabOrder = 8
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 32
    Top = 120
    Width = 75
    Height = 25
    Caption = #25442#34892
    TabOrder = 9
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 32
    Top = 160
    Width = 75
    Height = 25
    Caption = #20999#32440
    TabOrder = 10
    OnClick = Button7Click
  end
  object CheckBox2: TCheckBox
    Left = 112
    Top = 760
    Width = 113
    Height = 17
    Caption = #21313#20845#36827#21046#25509#25910
    TabOrder = 11
  end
  object Button8: TButton
    Left = 560
    Top = 472
    Width = 105
    Height = 25
    Caption = #32467#26463#31243#24207
    TabOrder = 12
    OnClick = Button8Click
  end
  object Button9: TButton
    Left = 368
    Top = 472
    Width = 145
    Height = 25
    Caption = #33719#24471#25171#21360#26426#29366#24577
    TabOrder = 13
    OnClick = Button9Click
  end
  object Button10: TButton
    Left = 136
    Top = 104
    Width = 105
    Height = 25
    Caption = #23383#20307#27979#35797#39029
    TabOrder = 14
    OnClick = Button10Click
  end
  object Button11: TButton
    Left = 136
    Top = 136
    Width = 105
    Height = 25
    Caption = #25171#21360#23567#31080
    TabOrder = 15
    OnClick = Button11Click
  end
  object Button12: TButton
    Left = 136
    Top = 72
    Width = 105
    Height = 25
    Caption = #25171#21360#26426#27979#35797#39029
    TabOrder = 16
    OnClick = Button12Click
  end
  object Button13: TButton
    Left = 136
    Top = 168
    Width = 105
    Height = 25
    Caption = #20572#27490#25171#21360
    TabOrder = 17
    OnClick = Button13Click
  end
  object Timer1: TTimer
    Enabled = False
    OnTimer = Timer1Timer
    Left = 320
    Top = 48
  end
  object Comm1: TComm
    CommName = 'COM2'
    BaudRate = 38400
    ParityCheck = False
    Outx_CtsFlow = False
    Outx_DsrFlow = False
    DtrControl = DtrEnable
    DsrSensitivity = False
    TxContinueOnXoff = True
    Outx_XonXoffFlow = True
    Inx_XonXoffFlow = True
    ReplaceWhenParityError = False
    IgnoreNullChar = False
    RtsControl = RtsEnable
    XonLimit = 500
    XoffLimit = 500
    ByteSize = _8
    Parity = None
    StopBits = _1
    XonChar = #17
    XoffChar = #19
    ReplacedChar = #0
    ReadIntervalTimeout = 100
    ReadTotalTimeoutMultiplier = 0
    ReadTotalTimeoutConstant = 0
    WriteTotalTimeoutMultiplier = 0
    WriteTotalTimeoutConstant = 0
    Left = 280
    Top = 48
  end
end
