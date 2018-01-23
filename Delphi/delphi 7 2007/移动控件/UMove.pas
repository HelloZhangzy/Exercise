unit UMove;

interface
  uses ExtCtrls,Controls ,Classes,Windows,Graphics,Math,StdCtrls,Dialogs,SysUtils;
  type
    TC = class (TControl);

    TComponeMove = class
    protected
       MainControl : TWinControl ;
    private
      Moveed:Boolean;
      aMethods : Array [1..4] of Array of TMethod;
      Con : TControl ;
      zX,zY : Integer;
      select:TControl;
      procedure conMouseDown(Sender: TObject; Button: TMouseButton;
                              Shift: TShiftState; X, Y: Integer);
      procedure ReDragSports;
      procedure ReDragSpot(aLeft,aTop : integer; Loc : String) ;
      procedure CreateDragSpot(Loc : String ; Cur :  TCursor);
      procedure ConMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer);
      procedure ConMouseUp(Sender: TObject; Button: TMouseButton;
                              Shift: TShiftState; X, Y: Integer);
      procedure DSMouseDown(Sender: TObject; Button: TMouseButton;
                             Shift: TShiftState; X, Y: Integer);
      procedure DSMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer);
      procedure DesginModel ;
      procedure NormalModel ;
      function  MoveIf(Compone : TComponent) :Boolean ;
      procedure Click(Sender: TObject);
    public
      procedure setModel ;
      function GetModel: Boolean;
      function Getselect:TControl;
      constructor Create(ContrlPane :TWinControl); virtual;
      destructor Destory;
    end;


implementation

{ TComponeMove }





procedure TComponeMove.conMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  Con := TControl(Sender);
  setCaptureControl(TControl(Sender));
  zX := X;
  zY := Y;
  ReDragSports;
end;

procedure TComponeMove.ConMouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
var
ds : TControl;
begin
  ds := getCaptureControl;
  if ds = nil then exit;
  ds.Left := ds.Left + X - zX;
  ds.Top := ds.Top + Y - zY;
  ReDragSports;
end;

procedure TComponeMove.ConMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  ReleaseCapture;
end;

constructor TComponeMove.Create(ContrlPane: TWinControl );
begin
  Moveed := false ;
  MainControl :=  ContrlPane   ;
end;

procedure TComponeMove.CreateDragSpot(Loc: String; Cur: TCursor);
begin
  with TPanel.Create(MainControl) do
  begin
    Parent:= MainControl;
    Width:=4;
    Height:=4;
    Color:=clBlack;
    BevelOuter := bvNone;
    Cursor := Cur;
    onMouseDown := DSMouseDown;
    onMouseMove := DSMouseMove;
    onMouseUp := conMouseUp;
    Name := 'DragSpot' + Loc;
  end;
end;

procedure TComponeMove.DesginModel;
var
  i:Integer;
  FirstControl :TControl ;
begin
  with  MainControl do
  begin
    for i := 1 to 4 do
      SetLength(aMethods[i],ComponentCount);
    for i := 0 to ComponentCount - 1 do
      if MoveIf(Components[i]) then
      begin               
        aMethods[1,i] := TMethod(TC(Components[i]).onClick);
        aMethods[2,i] := TMethod(TC(Components[i]).onMouseDown);
        aMethods[3,i] := TMethod(TC(Components[i]).onMouseMove);
        aMethods[4,i] := TMethod(TC(Components[i]).onMouseUp);
        TC(Components[i]).OnClick := Click;
        TC(Components[i]).OnMouseDown := conMouseDown;
        TC(Components[i]).OnMouseMove := conMouseMove;
        TC(Components[i]).OnMouseUp := conMouseUp;
        TC(Components[i]).Cursor := crArrow ;
        FirstControl := TC(Components[i]) ;
      end;
    Con := FirstControl;
    ReDragSports;
  end;
end;

destructor TComponeMove.Destory;
begin
  if Moveed then
    NormalModel ;
end;

procedure TComponeMove.DSMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  SetCaptureControl(TControl(Sender));
end;

procedure TComponeMove.DSMouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
var ds : TControl;
begin
  ds := getCaptureControl;
  if ds = nil then exit;
  if ds.Name[9] = 'T' then
  begin
    con.Height := Max(0,Con.Height + Con.Top - (y + ds.Top));
    con.Top := y + ds.Top;
  end
  else if ds.Name[9] = 'B' then
    con.Height := Max(0,y + ds.Top - Con.Top);
  if ds.Name[10] = 'L' then
  begin
    con.Width := Max(0,Con.Width + Con.Left - (x + ds.Left));
    con.Left := x + ds.Left;
  end
  else if ds.Name[10] = 'R' then
    con.Width := Max(0,x + ds.Left - Con.Left);
  ReDragSports;
end;

function TComponeMove.GetModel: Boolean;
begin
  result:= Moveed ;
end;



function TComponeMove.MoveIf(Compone : TComponent): Boolean;
begin
  result := (Compone is TPanel) ;
end;

procedure TComponeMove.NormalModel;
var i : integer;
begin
  with MainControl do
  begin
    for i := ComponentCount -1 downto 0 do
      if (Copy(Components[i].Name,1,8) = 'DragSpot') then
          Components[i].Free;
    for i := 0 to ComponentCount - 1 do
      if  MoveIf(Components[i]) then
      begin
        TC(Components[i]).OnClick := Click;
        TC(Components[i]).OnMouseDown := conMouseDown;
        TC(Components[i]).OnMouseMove := conMouseMove;
        TC(Components[i]).OnMouseUp := conMouseUp;
        TC(Components[i]).Cursor := crDefault ;
      end;
    end;
end;

procedure TComponeMove.ReDragSports;
begin
  ReDragSpot(Con.Left-2,Con.Top-2,'TL');
  ReDragSpot(Con.Left-2,Con.Top+Round(Con.Height / 2 ),'CL');
  ReDragSpot(Con.Left-2,Con.Top+Con.Height - 2,'BL');
  ReDragSpot(Con.Left+Round(Con.Width / 2 ),Con.Top-2,'TC');
  ReDragSpot(Con.Left+Round(Con.Width / 2 ),Con.Top+Con.Height-2,'BC');
  ReDragSpot(Con.Left+Con.Width-2,Con.Top-2,'TR');
  ReDragSpot(Con.Left+Con.Width-2,Con.Top+Round(Con.Height / 2),'CR');
  ReDragSpot(Con.Left+Con.Width-2,Con.Top+Con.Height-2,'BR');
end;

procedure TComponeMove.ReDragSpot(aLeft,aTop : integer; Loc : String);
var Pn : TPanel;
begin
  Pn := TPanel(MainControl.FindComponent('DragSpot' + Loc));
  if Pn = nil then exit;
  with Pn do
  begin
    Left := aLeft;
    Top := aTop;
    Parent := Con.Parent;
  end;
end;

procedure TComponeMove.setmodel;
begin

  if(MainControl=nil)  then
      exit;


  Moveed := not (Moveed) ;
  if Moveed then
  begin
     DesginModel ;
  end
  else
    NormalModel ;
end;
procedure TComponeMove.Click(Sender: TObject);
var E:Tedit;
    C: TComboBox;
   begin
      select:=nil;
      if(Sender is TPanel ) then
        begin
            select:=(Sender as TPanel);

            if(MainControl.FindComponent('ex')is Tedit)then
              begin
                 E:=(MainControl.FindComponent('ex')as Tedit);
                 E.Text:= intTOStr(select.Top);
              end;

            if(MainControl.FindComponent('ey')is Tedit)then
              begin
                 E:=(MainControl.FindComponent('ey')as Tedit);
                 E.Text:= intTOStr(select.Left);
              end;

            
            if(MainControl.FindComponent('edit3')is Tedit)then
              begin
                 E:=(MainControl.FindComponent('edit3')as Tedit);
                 E.Text:=(Sender as TPanel).Caption;
              end;

            if(MainControl.FindComponent('ComboBox1')is TComboBox)then
              begin
                 C:=(MainControl.FindComponent('ComboBox1')as TComboBox);
                 C.Text:=intToStr((Sender as TPanel).Font.Size);
              end;



        end;


   end;
 function TComponeMove.Getselect:TControl;
 begin
    result:=select;
 end;

end.
