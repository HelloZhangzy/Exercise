unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ImgList,joffa, Menus, ExtCtrls;

type
  TForm1 = class(TForm)
    Heads: TImageList;
    Legs: TImageList;
    FLegs: TImageList;
    FHeads: TImageList;
    PopupMenu1: TPopupMenu;
    Timer1: TTimer;
    procedure FormCreate(Sender: TObject);
    Procedure FlipBitmap(Var bmp: tbitmap);
    Procedure MakeBMPMask(oldbmp: tbitmap; Var outbmp: tbitmap; maskcolor: tcolor);
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

Const Joffacount    = 1;
Const Gravity       = 0.11;

implementation

{$R *.dfm}

Procedure TForm1.FlipBitmap(Var bmp: tbitmap);
Type pscanline = Array[0..100000000] Of tcolor;
Var xx, yy          : integer;
  oscanl, scanl     : ^pscanline;
  oldbmp            : tbitmap;
Begin
  bmp.pixelformat := pf32bit;
  oldbmp := tbitmap.create;
  oldbmp.pixelformat := pf32bit;
  oldbmp.width := bmp.width;
  oldbmp.height := bmp.height;
  oldbmp.Canvas.Draw(0, 0, bmp);
  For yy := 0 To bmp.Height - 1 Do
  Begin
    scanl := bmp.ScanLine[yy];
    oscanl := oldbmp.scanline[yy];
    For xx := 0 To bmp.width - 1 Do
      scanl[xx] := oscanl[(bmp.width - 1) - xx];
  End;
  oldbmp.free;
End;

Procedure TForm1.MakeBMPMask(oldbmp: tbitmap; Var outbmp: tbitmap; maskcolor: tcolor);
Type pscanline = Array[0..100000000] Of tcolor;
Var xx, yy          : integer;
  oscanl, scanl     : ^pscanline;
Begin
  oldbmp.pixelformat := pf32bit;
  outbmp.pixelformat := pf32bit;
  outbmp.width := oldbmp.width;
  outbmp.height := oldbmp.height;
//outbmp.pixelformat:=pf32bit;
  outbmp.Canvas.Draw(0, 0, oldbmp);
  outbmp.Mask(maskcolor);


{for yy:=0 to oldbmp.Height-1 do
 begin
 scanl:=outbmp.ScanLine[yy];
 oscanl:=oldbmp.scanline[yy];
 for xx:=0 to oldbmp.width-1 do
  if oscanl[xx]=maskcolor then scanl[xx]:=clwhite else scanl[xx]:=clblack;
 end;{}
End;

procedure TForm1.FormCreate(Sender: TObject);
Var i               : integer;
  bmp, mask         : tbitmap;
Begin
  bmp := tbitmap.create;
  mask := tbitmap.create;
  For i := 0 To legs.count - 1 Do
  Begin
    bmp.Canvas.brush.Color := clred;
    bmp.Canvas.FillRect(rect(0, 0, 31, 31));
    legs.getbitmap(i, bmp);
    flipbitmap(bmp);
    MakeBMPMask(bmp, mask, clred);
    flegs.Add(bmp, mask);
  End;

  For i := 0 To heads.count - 1 Do
  Begin
    bmp.Canvas.brush.Color := clred;
    bmp.Canvas.FillRect(rect(0, 0, 31, 31));
    heads.getbitmap(i, bmp);
    flipbitmap(bmp);
    fheads.Add(bmp, Nil);
  End;
  bmp.free;
  mask.free;

//lmdtrayicon1.icon:=application.icon;
  randomize;
  For i := 1 To 1 Do
    With TJoffaForm.Create(Self) Do
    Begin
      x := Mouse.CursorPos.X;
      y := Mouse.CursorPos.Y;
      pic := 0;
      opic := 1;
//  Images.GetBitmap(trunc(pic),Image.Picture.Bitmap);
      Show;
    End;
Application.ProcessMessages;
  For i := 0 To self.componentcount - 1 Do
    If self.components[i] Is TJoffaForm Then
      With TJoffaForm(self.components[i]) Do If visible Then MoveJoffa;

end;

procedure TForm1.Timer1Timer(Sender: TObject);
Var i               : integer ;
begin
 Application.ProcessMessages;
  For i := 0 To self.componentcount - 1 Do
    If self.components[i] Is TJoffaForm Then
      With TJoffaForm(self.components[i]) Do If visible Then MoveJoffa; 
end;

end.
