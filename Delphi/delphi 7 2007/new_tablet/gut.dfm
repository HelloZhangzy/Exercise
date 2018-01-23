object gut_fr: Tgut_fr
  Left = 837
  Top = 415
  Width = 562
  Height = 264
  AutoSize = True
  Caption = #28155#21152#26631#31614
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWhite
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = True
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 554
    Height = 230
    BevelOuter = bvNone
    Ctl3D = False
    ParentCtl3D = False
    TabOrder = 0
    object Label2: TLabel
      Left = 337
      Top = 38
      Width = 80
      Height = 20
      AutoSize = False
      Caption = #25552#37266#26102#38388
      Font.Charset = DEFAULT_CHARSET
      Font.Color = 7492630
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 337
      Top = 71
      Width = 80
      Height = 20
      AutoSize = False
      Caption = #25552#37266#22825#25968
      Font.Charset = DEFAULT_CHARSET
      Font.Color = 7492630
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 337
      Top = 105
      Width = 80
      Height = 20
      AutoSize = False
      Caption = #26700#38754#26174#31034
      Font.Charset = DEFAULT_CHARSET
      Font.Color = 7492630
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label5: TLabel
      Left = 337
      Top = 138
      Width = 80
      Height = 20
      AutoSize = False
      Caption = #32423'        '#21035
      Font.Charset = DEFAULT_CHARSET
      Font.Color = 7492630
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label6: TLabel
      Left = 513
      Top = 72
      Width = 12
      Height = 13
      Caption = #22825
      Font.Charset = DEFAULT_CHARSET
      Font.Color = 7492630
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Bevel1: TBevel
      Left = 328
      Top = 12
      Width = 227
      Height = 166
      ParentShowHint = False
      Shape = bsFrame
      ShowHint = False
    end
  end
  object ActionList1: TActionList
    Left = 276
    Top = 120
    object add_teblet: TAction
      Caption = #22686#21152
      OnExecute = add_tebletExecute
    end
    object clear: TAction
      Caption = #28165#31354
      OnExecute = clearExecute
    end
    object create: TAction
      Caption = 'create'
    end
    object delete_tablet: TAction
      Caption = 'delete_tablet'
      OnExecute = delete_tabletExecute
    end
    object read_tablet: TAction
      Caption = 'read_tablet'
      OnExecute = read_tabletExecute
    end
    object close: TAction
      Caption = #20851#38381
      OnExecute = closeExecute
    end
    object off: TAction
      OnExecute = offExecute
    end
    object CloseAndOff: TAction
      Caption = 'CloseAndOff'
      OnExecute = CloseAndOffExecute
    end
  end
end
