object Form1: TForm1
  Left = 762
  Top = 197
  Width = 535
  Height = 353
  Caption = #20390#21548
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Bevel1: TBevel
    Left = 0
    Top = 0
    Width = 527
    Height = 319
    Align = alClient
    Shape = bsFrame
  end
  object Bevel2: TBevel
    Left = 0
    Top = 235
    Width = 525
    Height = 81
    Shape = bsTopLine
  end
  object Label1: TLabel
    Left = 176
    Top = 16
    Width = 65
    Height = 16
    AutoSize = False
    Caption = #20390#21548#22320#22336
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 376
    Top = 16
    Width = 65
    Height = 16
    AutoSize = False
    Caption = #20390#21548#31471#21475
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 16
    Top = 248
    Width = 81
    Height = 16
    AutoSize = False
    Caption = #23458#25143#31471#22320#22336#65306
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 288
    Top = 248
    Width = 81
    Height = 16
    AutoSize = False
    Caption = #23458#25143#31471#31471#21475
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 16
    Top = 283
    Width = 33
    Height = 16
    AutoSize = False
    Caption = #25351#20196
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Button1: TButton
    Left = 16
    Top = 12
    Width = 75
    Height = 25
    Caption = #21551#21160#20390#21548
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 96
    Top = 12
    Width = 75
    Height = 25
    Caption = #20572#27490#20390#21548
    Enabled = False
    TabOrder = 1
    OnClick = Button2Click
  end
  object Edit1: TEdit
    Left = 248
    Top = 12
    Width = 121
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Text = '127.0.0.1'
  end
  object Edit2: TEdit
    Left = 448
    Top = 12
    Width = 65
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    Text = '1369'
  end
  object Memo1: TMemo
    Left = 16
    Top = 43
    Width = 497
    Height = 182
    PopupMenu = PopupMenu1
    ReadOnly = True
    ScrollBars = ssBoth
    TabOrder = 4
  end
  object clientIP: TEdit
    Left = 104
    Top = 244
    Width = 121
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    ReadOnly = True
    TabOrder = 5
    Text = '127.0.0.1'
  end
  object clientport: TEdit
    Left = 376
    Top = 244
    Width = 49
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    ReadOnly = True
    TabOrder = 6
    Text = '1369'
  end
  object Button3: TButton
    Left = 440
    Top = 244
    Width = 75
    Height = 25
    Caption = #21457#36865
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 7
    OnClick = Button3Click
  end
  object Edit3: TEdit
    Left = 48
    Top = 280
    Width = 465
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -15
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 8
  end
  object TcpServer1: TTcpServer
    Active = True
    LocalHost = '192.168.1.17'
    LocalPort = '8080'
    OnAccept = TcpServer1Accept
    Left = 8
    Top = 136
  end
  object TcpClient1: TTcpClient
    Left = 96
    Top = 128
  end
  object PopupMenu1: TPopupMenu
    Left = 56
    Top = 48
    object N1: TMenuItem
      Caption = #28165#31354#26174#31034#21306
      OnClick = N1Click
    end
  end
end
