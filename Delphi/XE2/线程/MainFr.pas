unit MainFr;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.Grids,
  Vcl.DBGrids, Vcl.ComCtrls;

type
  TMainFrom = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    Panel3: TPanel;
    Panel4: TPanel;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    Panel5: TPanel;
    Panel6: TPanel;
    Panel7: TPanel;
    ListView1: TListView;
    Panel8: TPanel;
    Label1: TLabel;
    Label2: TLabel;
    Button1: TButton;
    edtIPAddress: TEdit;
    edtServerProt: TEdit;
    Bevel1: TBevel;
    lbGWDCount: TLabel;
    lbReDataCount: TLabel;
    Label7: TLabel;
    Label6: TLabel;
    Panel9: TPanel;
    Panel10: TPanel;
    Panel11: TPanel;
    GroupBox4: TGroupBox;
    ListView2: TListView;
    Panel12: TPanel;
    Panel13: TPanel;
    GroupBox5: TGroupBox;
    ListView3: TListView;
    Panel14: TPanel;
    GroupBox6: TGroupBox;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  MainFrom: TMainFrom;

implementation

{$R *.dfm}

end.
