object MainFrom: TMainFrom
  Left = 0
  Top = 0
  Caption = 'MainFrom'
  ClientHeight = 730
  ClientWidth = 1046
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 1046
    Height = 5
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 0
    ExplicitWidth = 947
  end
  object Panel2: TPanel
    Left = 0
    Top = 5
    Width = 1046
    Height = 240
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 1
    ExplicitTop = 9
    ExplicitWidth = 947
    object Panel3: TPanel
      Left = 803
      Top = 0
      Width = 243
      Height = 240
      Align = alRight
      BevelOuter = bvNone
      TabOrder = 0
      object GroupBox2: TGroupBox
        Left = 0
        Top = 0
        Width = 243
        Height = 118
        Align = alTop
        Caption = #26381#21153#22120#35774#32622
        TabOrder = 0
        object Label1: TLabel
          Left = 23
          Top = 23
          Width = 60
          Height = 13
          Caption = #26381#21153#22120#22320#22336
        end
        object Label2: TLabel
          Left = 23
          Top = 50
          Width = 61
          Height = 13
          Caption = #26381#21153#22120#31471#21475
        end
        object Bevel1: TBevel
          Left = 2
          Top = 77
          Width = 239
          Height = 39
          Align = alBottom
          Shape = bsTopLine
          ExplicitTop = 76
        end
        object Button1: TButton
          Left = 80
          Top = 85
          Width = 75
          Height = 25
          Caption = #21551#21160
          TabOrder = 0
        end
        object edtIPAddress: TEdit
          Left = 90
          Top = 20
          Width = 121
          Height = 21
          TabOrder = 1
        end
        object edtServerProt: TEdit
          Left = 90
          Top = 47
          Width = 121
          Height = 21
          TabOrder = 2
        end
      end
      object GroupBox3: TGroupBox
        Left = 0
        Top = 118
        Width = 243
        Height = 122
        Align = alClient
        Caption = #32479#35745#20449#24687
        TabOrder = 1
        ExplicitLeft = 6
        ExplicitTop = 119
        ExplicitWidth = 185
        ExplicitHeight = 105
        object lbGWDCount: TLabel
          Left = 96
          Top = 29
          Width = 11
          Height = 25
          Caption = '0'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -21
          Font.Name = 'Tahoma'
          Font.Style = []
          ParentFont = False
        end
        object lbReDataCount: TLabel
          Left = 96
          Top = 67
          Width = 11
          Height = 25
          Caption = '0'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -21
          Font.Name = 'Tahoma'
          Font.Style = []
          ParentFont = False
        end
        object Label7: TLabel
          Left = 14
          Top = 75
          Width = 72
          Height = 13
          Caption = #25968#25454#25509#25910#26465#25968
        end
        object Label6: TLabel
          Left = 14
          Top = 40
          Width = 72
          Height = 13
          Caption = #37319#38598#22120#36830#25509#25968
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = []
          ParentFont = False
        end
      end
    end
    object Panel4: TPanel
      Left = 0
      Top = 0
      Width = 798
      Height = 240
      Align = alClient
      BevelOuter = bvNone
      TabOrder = 1
      ExplicitWidth = 837
      object GroupBox1: TGroupBox
        Left = 5
        Top = 0
        Width = 793
        Height = 240
        Align = alClient
        Caption = #37319#38598#22120#20449#24687
        TabOrder = 0
        ExplicitLeft = 120
        ExplicitTop = 48
        ExplicitWidth = 185
        ExplicitHeight = 105
        object ListView1: TListView
          Left = 2
          Top = 15
          Width = 789
          Height = 223
          Align = alClient
          Columns = <>
          TabOrder = 0
          ExplicitLeft = 248
          ExplicitTop = 64
          ExplicitWidth = 250
          ExplicitHeight = 150
        end
      end
      object Panel7: TPanel
        Left = 0
        Top = 0
        Width = 5
        Height = 240
        Align = alLeft
        BevelOuter = bvNone
        TabOrder = 1
      end
    end
    object Panel5: TPanel
      Left = 798
      Top = 0
      Width = 5
      Height = 240
      Align = alRight
      BevelOuter = bvNone
      TabOrder = 2
      ExplicitLeft = 722
    end
  end
  object Panel6: TPanel
    Left = 0
    Top = 245
    Width = 1046
    Height = 7
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 2
    ExplicitLeft = -8
    ExplicitTop = 333
    ExplicitWidth = 947
  end
  object Panel8: TPanel
    Left = 0
    Top = 252
    Width = 1046
    Height = 237
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 3
    object Panel9: TPanel
      Left = 804
      Top = 0
      Width = 242
      Height = 237
      Align = alRight
      BevelOuter = bvNone
      TabOrder = 0
      object GroupBox6: TGroupBox
        Left = 0
        Top = 0
        Width = 242
        Height = 237
        Align = alClient
        Caption = #25511#21046#21306
        TabOrder = 0
        ExplicitLeft = -3
        ExplicitTop = 15
        ExplicitWidth = 185
        ExplicitHeight = 105
      end
    end
    object Panel10: TPanel
      Left = 797
      Top = 0
      Width = 7
      Height = 237
      Align = alRight
      BevelOuter = bvNone
      TabOrder = 1
      ExplicitLeft = 728
    end
    object Panel11: TPanel
      Left = 0
      Top = 0
      Width = 797
      Height = 237
      Align = alClient
      BevelOuter = bvNone
      TabOrder = 2
      ExplicitLeft = 1
      ExplicitTop = -1
      object GroupBox4: TGroupBox
        Left = 0
        Top = 0
        Width = 797
        Height = 237
        Align = alClient
        Caption = #25351#20196#32531#23384#20449#24687
        TabOrder = 0
        ExplicitLeft = 120
        ExplicitTop = 48
        ExplicitWidth = 185
        ExplicitHeight = 105
        object ListView2: TListView
          Left = 2
          Top = 15
          Width = 793
          Height = 220
          Align = alClient
          Columns = <>
          TabOrder = 0
        end
      end
    end
  end
  object Panel12: TPanel
    Left = 0
    Top = 489
    Width = 1046
    Height = 4
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 4
  end
  object Panel13: TPanel
    Left = 0
    Top = 493
    Width = 1046
    Height = 237
    Align = alClient
    BevelOuter = bvNone
    TabOrder = 5
    ExplicitLeft = 8
    ExplicitTop = 8
    ExplicitWidth = 798
    ExplicitHeight = 240
    object GroupBox5: TGroupBox
      Left = 5
      Top = 0
      Width = 1041
      Height = 237
      Align = alClient
      Caption = #25968#25454#25509#25910#35760#24405
      TabOrder = 0
      ExplicitWidth = 793
      ExplicitHeight = 240
      object ListView3: TListView
        Left = 2
        Top = 15
        Width = 1037
        Height = 220
        Align = alClient
        Columns = <>
        TabOrder = 0
        ExplicitWidth = 789
        ExplicitHeight = 223
      end
    end
    object Panel14: TPanel
      Left = 0
      Top = 0
      Width = 5
      Height = 237
      Align = alLeft
      BevelOuter = bvNone
      TabOrder = 1
      ExplicitHeight = 240
    end
  end
end
