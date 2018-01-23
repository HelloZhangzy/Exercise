  //ÊÕ²Ø¼Ð²Ëµ¥¿Ø¼þ    
    
unit FavoritesMenu;

interface

uses

Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,

Menus;

type

TUrlNotifyEvent = procedure(Sender: TObject; Url: string) of object;

TFavoritesMenu = class(TComponent)

private

{ Private declarations }

FMenuItem: TMenuItem;

FMaxLength: integer;

FOnUrlClick: TUrlNotifyEvent;

FImageFolder: integer;

FImageUrl: integer;

FSorted: boolean;

procedure FillFavorites(Directory: string; AMenuItem: TMenuItem);

function CreateMenuOption(AFileName: string; AMenuItem: TMenuItem):

TMenuItem;

function CreateMenuOptionDir(AFileName: string;

AMenuItem: TMenuItem): TMenuItem;

procedure DoClickUrl(Sender: TObject);

function ReadUrl(AFileName: string): string;

protected

{ Protected declarations }

procedure Notification(AComponent: TComponent; Operation: TOperation);

override;

public

{ Public declarations }

constructor Create(AOwner: TComponent); override;

procedure Refresh;

published

{ Published declarations }

property MenuItem: TMenuItem read FMenuItem write FMenuItem;

property MaxLength: integer read FMaxLength write FMaxLength default 30;

property ImageFolder: integer read FImageFolder write FImageFolder default 0;

property ImageUrl: integer read FImageUrl write FImageUrl default 1;

property OnUrlClick: TUrlNotifyEvent read FOnUrlClick write FOnUrlClick;

property Sorted: boolean read FSorted write FSorted default True;

end;

implementation

uses Registry, Inifiles;

{ TFavoritesMenu }

constructor TFavoritesMenu.Create(AOwner: TComponent);

begin

inherited;

FMaxLength := 30;

FImageFolder := 0;

FImageUrl := 1;

FSorted := True;

end;

procedure TFavoritesMenu.DoClickUrl(Sender: TObject);

begin

if Assigned(FOnUrlClick) then FOnUrlClick(Sender, TMenuItem(Sender).Hint);

end;

function TFavoritesMenu.ReadUrl(AFileName: string): string;

var

Reg: TIniFile;

begin

Reg := TIniFile.Create(AFileName);

result := Reg.ReadString('InternetShortcut', 'URL', 'non url');

Reg.Free;

end;

function TFavoritesMenu.CreateMenuOption(AFileName: string; AMenuItem:

TMenuItem): TMenuItem;

var

Item: TMenuItem;

Cap: string;

Url: string;

begin

Item := TMenuItem.Create(AMenuItem);

Cap := Copy(ExtractFileName(AFileName), 1,

Length(ExtractFileName(AFileName)) - 4);

if Length(Cap) > FMaxLength then

Cap := Copy(Cap, 1, FMaxLength) + '..';

Item.ImageIndex := FImageUrl;

Item.Caption := Cap;

Item.Hint := ReadUrl(AFileName);

Item.OnClick := DoClickUrl;

AMenuItem.Add(Item);

result := Item;

end;

function PosRight(sub: char; s: string): integer;

var

i: integer;

begin

result := -1;

for i := Length(s) downto 1 do

if s[i] = sub then

begin

result := i;

break;

end;

end;

function TFavoritesMenu.CreateMenuOptionDir(AFileName: string; AMenuItem:

TMenuItem): TMenuItem;

var

Item: TMenuItem;

p: integer;

begin

Item := TMenuItem.Create(AMenuItem);

p := PosRight('\', AFileName);

Item.Caption := Copy(AFileName, p + 1, Length(AfileName));

Item.ImageIndex := FImageFolder;

if FSorted then

AMenuItem.Insert(0, Item)

else

AMenuItem.Add(Item);

result := Item;

end;

procedure TFavoritesMenu.FillFavorites(Directory: string; AMenuItem: TMenuItem);

var

search: TSearchRec;

Item: TMenuItem;

begin

if Directory[length(Directory)] <> '\' then Directory := Directory + '\';

if FindFirst(Directory + '*.*', faArchive + fadirectory, search) = 0 then

begin

repeat

if ((search.Attr and fadirectory) = fadirectory) and (search.name[1] <>

'.') then

begin

Item := CreateMenuOptionDir(Directory + search.Name, AMenuItem);

FillFavorites(Directory + search.Name, Item);

end

else if ((search.Attr and faArchive) = faArchive) then

CreateMenuOption(Directory + search.Name, AMenuItem);

until FindNext(search) <> 0;

FindClose(search);

end;

end;

procedure TFavoritesMenu.Refresh;

var

Reg: TRegistry;

InitDir: string;

begin

Reg := TRegistry.Create;

Reg.OpenKey('Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders', false);

InitDir := Reg.ReadString('Favorites');

Reg.Free;

FillFavorites(InitDir, FMenuItem);

end;

procedure TFavoritesMenu.Notification(AComponent: TComponent;

Operation: TOperation);

begin

inherited;

if (Operation = opRemove) and (AComponent = FMenuItem) then FMenuItem := nil;

end;

end.
 
   

