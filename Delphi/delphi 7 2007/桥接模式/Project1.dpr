program Project1;

{$APPTYPE CONSOLE}

uses
  SysUtils;

  type
   Matrix=class
   end;

  ImageImp=interface
    procedure doPaint(m:Matrix);
  end;
  
  Image=class
    private
      Fimp:ImageImp;
    public
      procedure setImageImp(imp:ImageImp);
      procedure parseFile(fileName:String);virtual;abstract;
//    property
//      imp:ImageImp  read Fimp write Fimp;
   end;

   WindowsImp=class(TInterfacedObject,ImageImp)
    public
      procedure doPaint(m:Matrix);    
   end;
      
   LinuxImp=class(TInterfacedObject,ImageImp)
    public
      procedure doPaint(m:Matrix);
   end;
   
   UnixImp=class(TInterfacedObject,ImageImp)
    public
      procedure doPaint(m:Matrix);
   end;
   
   JPGImage=class(Image)
     procedure  parseFile( fileName:String);override;     
   end;
   
   PNGImage=class(Image)
     procedure  parseFile( fileName:String);override;     
   end;
   
   BMPImage=class(Image)
     procedure  parseFile( fileName:String);override;     
   end;


  
{ Image }

procedure Image.setImageImp(imp: ImageImp);
begin
  Fimp:=imp;
end;

{ WindowsImp }

procedure WindowsImp.doPaint(m: Matrix);
begin
  Writeln('在Windows操作系统中显示图像：');
end;

{ LinuxImp }

procedure LinuxImp.doPaint(m: Matrix);
begin
  Writeln('在Linux操作系统中显示图像：');
end;

{ UnixImp }

procedure UnixImp.doPaint(m: Matrix);
begin
  Writeln('在Unix操作系统中显示图像：');
end;

{ JPGImage }

procedure JPGImage.parseFile(fileName: String);
var
  m:Matrix;
begin
  m :=  Matrix.Create;
  Fimp.doPaint(m);
  Writeln(fileName + '，格式为JPG。');
end;

{ PNGImage }

procedure PNGImage.parseFile(fileName: String);
var
  m:Matrix;
begin
  m :=  Matrix.Create;
  Fimp.doPaint(m);
  Writeln(fileName + '，格式为PNG。');

end;

{ BMPImage }

procedure BMPImage.parseFile(fileName: String);
var
  m:Matrix;
begin
  m :=  Matrix.Create;
  Fimp.doPaint(m);
  Writeln(fileName + '，格式为BMP。');
end;

var
  ima:Image;
  imp:ImageImp;
begin
  try
    { TODO -oUser -cConsole Main : Insert code here }
    ima :=  JPGImage.Create;
    imp :=  WindowsImp.Create;
    ima.setImageImp(imp);
    ima.parseFile('小龙女');
    readln;
  except
    on E:Exception do
      Writeln(E.Classname, ': ', E.Message);
  end;


  
end.
