object Form1: TForm1
  Left = 196
  Top = 192
  Caption = 'RSA Sample'
  ClientHeight = 430
  ClientWidth = 612
  Color = clBtnFace
  DefaultMonitor = dmDesktop
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 480
    Top = 0
    Width = 132
    Height = 430
    Align = alRight
    BevelOuter = bvNone
    TabOrder = 0
    object Button1: TButton
      Left = 8
      Top = 8
      Width = 121
      Height = 25
      Caption = 'Public Crypting'
      TabOrder = 0
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 8
      Top = 40
      Width = 121
      Height = 25
      Caption = 'Private Decrypting'
      TabOrder = 1
      OnClick = Button2Click
    end
    object Button3: TButton
      Left = 8
      Top = 96
      Width = 121
      Height = 25
      Caption = 'Private Crypting'
      TabOrder = 2
      OnClick = Button3Click
    end
    object Button4: TButton
      Left = 8
      Top = 128
      Width = 121
      Height = 25
      Caption = 'Public Decrypting'
      TabOrder = 3
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 8
      Top = 192
      Width = 121
      Height = 25
      Caption = 'SHA1'
      TabOrder = 4
      OnClick = Button5Click
    end
    object Button6: TButton
      Left = 8
      Top = 232
      Width = 121
      Height = 25
      Caption = 'SHA256'
      TabOrder = 5
      OnClick = Button6Click
    end
    object Button7: TButton
      Left = 8
      Top = 272
      Width = 121
      Height = 25
      Caption = 'SHA512'
      TabOrder = 6
      OnClick = Button7Click
    end
    object Button8: TButton
      Left = 6
      Top = 328
      Width = 75
      Height = 25
      Caption = 'start'
      TabOrder = 7
      OnClick = Button8Click
    end
    object Button9: TButton
      Left = 6
      Top = 368
      Width = 75
      Height = 25
      Caption = 'stop'
      TabOrder = 8
      OnClick = Button9Click
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 0
    Width = 480
    Height = 430
    Align = alClient
    BevelOuter = bvNone
    TabOrder = 1
    object GroupBox1: TGroupBox
      Left = 0
      Top = 0
      Width = 480
      Height = 89
      Align = alTop
      Caption = 'Data to Crypt'
      TabOrder = 0
      object Memo1: TMemo
        Left = 2
        Top = 15
        Width = 476
        Height = 72
        Align = alClient
        Lines.Strings = (
          'Some text for RSA Crypt, for 1024 bit key only 117 byte')
        MaxLength = 128
        ScrollBars = ssVertical
        TabOrder = 0
      end
    end
    object GroupBox2: TGroupBox
      Left = 0
      Top = 89
      Width = 480
      Height = 105
      Align = alTop
      Caption = 'Crypted Data'
      TabOrder = 1
      object Memo2: TMemo
        Left = 2
        Top = 15
        Width = 476
        Height = 88
        Align = alClient
        ScrollBars = ssVertical
        TabOrder = 0
      end
    end
    object GroupBox3: TGroupBox
      Left = 0
      Top = 194
      Width = 480
      Height = 105
      Align = alTop
      Caption = 'Decrypted Data'
      TabOrder = 2
      object Memo3: TMemo
        Left = 2
        Top = 15
        Width = 476
        Height = 88
        Align = alClient
        ScrollBars = ssVertical
        TabOrder = 0
      end
    end
    object GroupBox4: TGroupBox
      Left = 0
      Top = 299
      Width = 480
      Height = 131
      Align = alClient
      Caption = 'RSA Log'
      TabOrder = 3
      object Memo4: TMemo
        Left = 2
        Top = 15
        Width = 476
        Height = 114
        Align = alClient
        ScrollBars = ssVertical
        TabOrder = 0
      end
    end
  end
end
