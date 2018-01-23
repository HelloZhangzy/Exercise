object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 247
  ClientWidth = 480
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 405
    Top = 0
    Width = 75
    Height = 247
    Align = alRight
    Caption = 'Button1'
    TabOrder = 0
    OnClick = Button1Click
    ExplicitLeft = 328
    ExplicitTop = 88
    ExplicitHeight = 25
  end
  object Memo1: TMemo
    Left = 0
    Top = 0
    Width = 405
    Height = 247
    Align = alClient
    ImeName = #20013#25991' - QQ'#20116#31508#36755#20837#27861
    Lines.Strings = (
      'Memo1')
    TabOrder = 1
    ExplicitLeft = 40
    ExplicitTop = 8
    ExplicitWidth = 185
    ExplicitHeight = 89
  end
  object IdHTTP1: TIdHTTP
    AllowCookies = True
    ProxyParams.BasicAuthentication = False
    ProxyParams.ProxyPort = 0
    Request.ContentLength = -1
    Request.Accept = 'text/html, */*'
    Request.BasicAuthentication = False
    Request.UserAgent = 'Mozilla/3.0 (compatible; Indy Library)'
    HTTPOptions = [hoForceEncodeParams]
    Left = 344
    Top = 144
  end
end
