object RWCard_fr: TRWCard_fr
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = 'RWCard_fr'
  ClientHeight = 664
  ClientWidth = 526
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 8
    Top = 0
    Width = 225
    Height = 73
    Caption = 'ComPram'
    TabOrder = 0
    object Label1: TLabel
      Left = 11
      Top = 19
      Width = 21
      Height = 13
      Caption = 'Com'
    end
    object Label2: TLabel
      Left = 116
      Top = 19
      Width = 30
      Height = 13
      Caption = 'Bound'
    end
    object edCom: TEdit
      Left = 50
      Top = 16
      Width = 49
      Height = 21
      ImeName = #20013#25991' - QQ'#20116#31508#36755#20837#27861
      TabOrder = 0
      Text = '0'
    end
    object edBound: TEdit
      Left = 164
      Top = 16
      Width = 49
      Height = 21
      ImeName = #20013#25991' - QQ'#20116#31508#36755#20837#27861
      TabOrder = 1
      Text = '9600'
    end
    object btnOpen: TButton
      Left = 76
      Top = 43
      Width = 75
      Height = 25
      Caption = 'OpenCom'
      TabOrder = 2
      OnClick = btnOpenClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 325
    Top = 0
    Width = 194
    Height = 73
    Caption = 'CardPassword'
    TabOrder = 1
    object Label3: TLabel
      Left = 20
      Top = 19
      Width = 47
      Height = 13
      Caption = 'PAssword'
    end
    object Edit1: TEdit
      Left = 78
      Top = 16
      Width = 99
      Height = 21
      ImeName = #20013#25991' - QQ'#20116#31508#36755#20837#27861
      TabOrder = 0
    end
    object Button1: TButton
      Left = 48
      Top = 43
      Width = 75
      Height = 25
      Caption = 'CheckPass'
      TabOrder = 1
    end
  end
  object GroupBox3: TGroupBox
    Left = 0
    Top = 74
    Width = 526
    Height = 590
    Align = alBottom
    Caption = 'CardData'
    TabOrder = 2
    object mmCardData: TMemo
      Left = 32
      Top = 39
      Width = 492
      Height = 549
      Align = alClient
      Color = clMoneyGreen
      Font.Charset = DEFAULT_CHARSET
      Font.Color = -1
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = []
      ImeName = #20013#25991' - QQ'#20116#31508#36755#20837#27861
      ParentFont = False
      TabOrder = 0
    end
    object Panel2: TPanel
      Left = 2
      Top = 39
      Width = 30
      Height = 549
      Align = alLeft
      BevelOuter = bvNone
      Ctl3D = False
      ParentCtl3D = False
      TabOrder = 1
      object Memo2: TMemo
        Left = 6
        Top = 0
        Width = 30
        Height = 549
        BorderStyle = bsNone
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'Tahoma'
        Font.Style = []
        ImeName = #20013#25991' - QQ'#20116#31508#36755#20837#27861
        ParentFont = False
        TabOrder = 0
      end
    end
    object Panel1: TPanel
      Left = 2
      Top = 15
      Width = 522
      Height = 24
      Align = alTop
      BevelOuter = bvNone
      Ctl3D = False
      ParentCtl3D = False
      TabOrder = 2
      object Memo1: TMemo
        Left = 30
        Top = 4
        Width = 492
        Height = 59
        BorderStyle = bsNone
        Color = clMenuBar
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'Tahoma'
        Font.Style = []
        ImeName = #20013#25991' - QQ'#20116#31508#36755#20837#27861
        Lines.Strings = (
          
            '00    01    02    03    04    05    06    07    08    09    0A  ' +
            '  0B    0C    0D   0E     0F')
        ParentFont = False
        TabOrder = 0
      end
    end
  end
  object Button2: TButton
    Left = 248
    Top = 12
    Width = 58
    Height = 56
    Caption = 'Read'
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 532
    Top = 43
    Width = 21
    Height = 25
    Caption = 'Write'
    TabOrder = 4
  end
end
