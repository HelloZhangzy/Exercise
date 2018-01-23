object teblet_fr: Tteblet_fr
  Left = 721
  Top = 270
  Width = 559
  Height = 556
  Hint = #26631#31614#31995#32479
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = #26631#31614#31995#32479
  Color = clBtnFace
  TransparentColor = True
  TransparentColorValue = clWindow
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 551
    Height = 225
    Align = alTop
    Caption = 'Panel1'
    Ctl3D = False
    Locked = True
    ParentCtl3D = False
    TabOrder = 0
  end
  object PopupMenu1: TPopupMenu
    Left = 69
    Top = 312
    object N1: TMenuItem
      Action = del_tablet
    end
  end
  object ActionList1: TActionList
    Left = 147
    Top = 125
    object del_tablet: TAction
      Caption = #21024#38500#26631#31614
      OnExecute = del_tabletExecute
    end
    object add_tablet: TAction
      Caption = #28155#21152#26631#31614
      OnExecute = add_tabletExecute
    end
    object back: TAction
      Caption = #25968#25454#31649#29702
      OnExecute = backExecute
    end
  end
  object ApplicationEvents1: TApplicationEvents
    OnMinimize = ApplicationEvents1Minimize
    Left = 8
    Top = 66
  end
  object PopupMenu2: TPopupMenu
    Left = 160
    Top = 215
    object N2: TMenuItem
      Caption = #26174#31034#20027#31383#21475
      OnClick = N2Click
    end
    object N3: TMenuItem
      Caption = #36864#20986#31243#24207
      OnClick = N3Click
    end
  end
end
