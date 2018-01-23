unit  NewPanel;

interface

uses
    Windows,  Messages,  SysUtils,  Classes,  Controls,  ExtCtrls,Forms,dialogs;

type
    TNewPanel  =  class(TPanel)
    private
        {  Private  declarations  }
    protected
            FOnmouseEnter:TNotifyEvent;
            FOnmouseLeave:TNotifyEvent;
        {  Protected  declarations  }
    public
              procedure  CMMouseLeave(var  msg  :  TMessage);  message  CM_MOUSELEAVE;
              procedure  CMMouseEnter(var  msg  :  TMessage); message  CM_MOUSEENTER;
        {  Public  declarations  }
    published
        Property  OnMouseEnter:TNotifyEvent  read  FOnmouseEnter  Write  FOnmouseEnter;
        Property  OnMouseLeave:TNotifyEvent  read  FOnmouseLeave  Write  FOnmouseLeave;

        {  Published  declarations  }
    end;

procedure  Register;

implementation

procedure  Register;
begin
    RegisterComponents('Samples',  [TNewPanel]);
end;

procedure  TNewPanel.CMMouseLeave(var  msg  :  TMessage);
begin
if  Assigned(FOnmouseLeave)  then  FOnmouseLeave(nil);

inherited;
 showmessage('r');
// caption:='r';
end;


procedure  TNewPanel.CMMouseEnter(var  msg  :  TMessage);
begin
try
if    Assigned(FOnmouseEnter)  then  FOnmouseEnter(nil);
except
end;
inherited;
//showmessage('c');
//caption:='c';
end;


end.

