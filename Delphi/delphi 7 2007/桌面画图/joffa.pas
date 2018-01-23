Unit joffa;

Interface

Uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, Math, BitmapRegion;

Type
  TDirection = (dLeft, dRight, dFront);

  TMood = Record
    Sad, Happy, Anger: single;
    hunger: single;
  End;


  TJoffaForm = Class(TForm)
    Image: TImage;
    Procedure FormCreate(Sender: TObject);
    Procedure MoveJoffa;
//    procedure CreateParams(var Params: TCreateParams); override;
    Procedure ImageMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    Procedure ImageMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    Function IsBlocked(x, y: integer): boolean;
    Procedure MoveSingle(dx, dy: single);
    Procedure Move(vx, vy: single);

    Function StepIsBlocked(dx, dy: single): boolean;
    Function FOnGround: boolean;

  Private
    { Private declarations }
    FDirection: tdirection;
    FAlwaysOnTop: boolean;
    hooked: boolean;
    hook, mousepos: tpoint;
    crashx, crashy: boolean;
    blink, stall: integer;
    speed, dizziness, happiness: single; {0 to 1}
  Public
    { Public declarations }
    x, y, vx, vy, ax, ay: single;
    head, pic: single;
    ohead, opic, FramesSinceLastCrashy: integer;
    Property direction: tdirection Read fdirection Write fdirection Default dright;
    Property alwaysontop: boolean Read falwaysontop Write falwaysontop Default true;
    Property OnGround: boolean Read FOnGround;
  End;

Var
  JoffaForm         : TJoffaForm;

Implementation
Uses settings, Unit1;
{$R *.DFM}

Function IsWindowAt(X, Y: integer): boolean;
Var h               : hwnd;
  r                 : trect;
Begin
  If (x < 0) Or (y < 0) Or (x >= screen.width) Or (y >= screen.height) Then
  Begin
    result := true;
  End Else
  Begin
    h := WindowFromPoint(point(x, y));
    If h <> 0 Then
    Begin
      getwindowrect(h, r);
//      if abs(x-r.right)<10 then settingsform.caption:=inttostr(r.right)+'='+inttostr(x);
//      if x+1=r.right then showmessage('hit!');

      If (x = r.Left) Or (x = r.right - 1) Or
        (y = r.Top) Or (y = r.Bottom) Then result := true Else result := false;
    End Else result := false;
  End;
End;


Function TJoffaForm.FOnGround: boolean;
Var i               : integer;
Begin
  result := (FramesSinceLastCrashy < 20);
End;

Function TJoffaForm.StepIsBlocked(dx, dy: single): boolean;
Begin
  result := false;
  If dx > 0 Then
  Begin
    If iswindowat(trunc(x + dx) + width, trunc(y + dy)) Then result := true;
    If iswindowat(trunc(x + dx) + width, trunc(y + dy) + height) Then result := true;
  End;
  If dx < 0 Then
  Begin
    If iswindowat(trunc(x + dx), trunc(y + dy)) Then result := true;
    If iswindowat(trunc(x + dx), trunc(y + dy) + height) Then result := true;
  End;
  If dy > 0 Then
  Begin
    If iswindowat(trunc(x + dx), trunc(y + dy) + height) Then result := true;
    If iswindowat(trunc(x + dx) + width, trunc(y + dy) + height) Then result := true;
  End;

  If hooked Then result := false;
End;

Procedure TJoffaForm.MoveSingle(dx, dy: single);
Begin
  If (Not crashx) And (Not StepIsBlocked(dx, 0)) Then x := x + dx Else crashx := true;
  If (Not crashy) And (Not StepIsBlocked(0, dy)) Then y := y + dy Else crashy := true;
  If (x < screen.desktopleft) Or (x > screen.desktopwidth - width) Then crashx := true;
  If (y < screen.desktoptop) Or (y > screen.desktopheight - height) Then crashy := true;
End;

Procedure TJoffaForm.Move(vx, vy: single);
Var i               : integer;
  dx, dy, l, frac   : single;
Begin
  crashx := false;
  crashy := false;
  If abs(vx) > abs(vy) Then l := abs(vx) Else l := abs(vy);
  If l > 0 Then
  Begin
    dx := vx / l;
    dy := vy / l;
    For i := 1 To trunc(l) Do movesingle(dx, dy);
    frac := l - trunc(l);
    movesingle(dx * frac, dy * frac);
  End;
End;


Function TJoffaForm.IsBlocked(x, y: integer): boolean;
Begin
  result := false;
End;


Procedure TJoffaForm.FormCreate(Sender: TObject);
Begin
  stall := 10;
  width := 32;
  height := 32;
End;

Procedure TJoffaForm.MoveJoffa;
Begin
  If hooked Then
  Begin
    //ax := (mouse.cursorpos.x - (left + hook.x))* 0.02;
   // ay := (mouse.cursorpos.y - (top + hook.y))* 0.02;
   // ax := (mouse.cursorpos.x- (left + hook.x));
    //ay := (mouse.cursorpos.y- (top + hook.y));
    //ax := mouse.cursorpos.x;
   // ay := mouse.cursorpos.y;
    MousePos := point(Mouse.CursorPos.x, Mouse.CursorPos.y);
  End Else
  Begin
    ay := gravity;
  End;


 // vx := vx * 0.98 + ax;
  //vy := vy * 0.98 + ay;
  vx := vx + ax;
  vy := vy + ay;
  move(vx, vy);

 { If (crashx) Then
  Begin
    ax := -ax;
    vx := -vx;
    If speed > 10 Then hooked := false;
    If (vx > 0) Then direction := dright;
    If (vx < 0) Then direction := dleft;
  End;   }

 { If (crashy) Then
  Begin
    ay := -ay;
    vy := -vy;
    If speed > 10 Then hooked := false;
  End;  }

  {If Crashy Then FramesSinceLastCrashy := 0 Else inc(FramesSinceLastCrashy);

  ax := 0;
  If onground Then
  Begin
    Case Direction Of
      dright: ax := 0.01;
      dleft: ax := -0.01;
      Dfront: ax := 0;
    End;
  End;    }

  {If crashy Then
  Begin
    If random(40) * random(10) = 1 Then vy := -4 - random(10);
  End; }
  {If hooked Then stall := 10;
  If (crashx) And (crashy) Then If stall > 0 Then dec(stall) Else If stall < 10 Then inc(stall);  }

  {If (stall = 0) And Not hooked Then
  Begin
    hooked := true;
    move(vx, vy + 1);
    hooked := false;
  End;
           }
 // speed := sqrt(sqr(vx) + sqr(vy));


 { If crashy Then
    If Not isWindowAt(trunc(x + vx + 16), trunc(y) + 33) Then
    Begin
      vx := -vx;
      If (vx > 0) Then direction := dright;
      If (vx < 0) Then direction := dleft;
    End;


  If (x < 0) Then x := 0;
  If (y < 0) Then y := 0;
  If (x > screen.width - width) Then x := screen.width - width;
  If (y > screen.height - height) Then y := screen.height - height; {}

 If (trunc(x) <> left) Or (trunc(y) <> top) Then
 Begin
    left := trunc(x);
    top := trunc(y);
  End;
//if alwaysontop then
//BringToFront;

//if alwaysontop then self.SetZOrder(True);

//if not onground then pic:=7;
  {If speed > 5 Then head := 1 Else head := 0;
  If (vy > 2) Then pic := 6;
  If (vy < -2) Then pic := 7; }

  {If head = 0 Then head := 6;
  If head = 0 Then
  Begin
    //If blink > 0 Then dec(blink) Else blink := 200 + random(10) * 40;
    If (blink >= 10) And (blink < 15) Then head := 2;
    If (blink >= 5) And (blink < 10) Then head := 3;
    If (blink >= 0) And (blink < 5) Then head := 2;
  End;  }

  //If GetTopWindow(0) <> handle Then
  //  SetWindowPos(handle, HWND_TOPMOST, left, top, width, height, swp_nomove Or swp_nosize Or swp_showwindow);

//  if vx>0 then direction:=dright else direction:=dleft;
  If (opic <> trunc(pic)) Or (ohead <> trunc(head)) Then
  Begin
// image.picture.Bitmap.Canvas.fil
    If direction = dright Then
    Begin
      Form1.Heads.GetBitmap(trunc(head), Image.Picture.Bitmap);
      Form1.Legs.GetBitmap(trunc(pic), Image.Picture.Bitmap);
    End Else
    Begin
      Form1.FHeads.GetBitmap(trunc(head), Image.Picture.Bitmap);
      Form1.FLegs.GetBitmap(trunc(pic), Image.Picture.Bitmap);
    End;
    SetWindowRgn(Self.Handle, BitmapToRegion(Image.Picture.Bitmap.Handle, rgb(0, 0, 255)), True);
    opic := trunc(pic);
    ohead := trunc(head);
    Invalidate;
  End;
  pic := pic + 0.1;
  If pic >= 6 Then pic := 1;
End;

Procedure TJoffaForm.ImageMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
  var
    i:Integer;
Begin
  Form1.Timer1.Enabled:=true;
  If button = mbright Then
  Begin
    Form1.PopupMenu1.Popup(left + x, top + y);
  End Else
  Begin
    Hooked := True;
    Hook := point(mouse.cursorpos.x - left, mouse.cursorpos.y - top);
    MousePos := Point(Mouse.CursorPos.X, Mouse.CursorPos.Y);
  End;
 
End;

Procedure TJoffaForm.ImageMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
Begin
 Form1.Timer1.Enabled:=False;
  Hooked := False;
  Ax := 0;
  Ay := 0;
End;

End.

