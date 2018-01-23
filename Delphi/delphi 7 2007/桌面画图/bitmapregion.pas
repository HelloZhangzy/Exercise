Unit bitmapregion;

Interface
Uses math, windows;

Function BitmapToRegion(hBmp: HBITMAP; cTransparentColor: COLORREF = 0;
  cTolerance: COLORREF = $101010): HRGN;

Implementation

Function BitmapToRegion(hBmp: HBITMAP; cTransparentColor: COLORREF = 0;
  cTolerance: COLORREF = $101010): HRGN;
Const
  AllocUnit         = 100;
  MaxRects          : DWORD = AllocUnit;
Type
  TRectArray = Array[0..0] Of TRect;
  LONG = LongInt;
  PLONG = ^LONG;
Var
  h, Rgn            : HRGN;
  hMemDC, h_DC      : HDC;
  hBmp32, HoldBmp   : HBITMAP;
  bm, bm32          : BITMAP;
  RGB32BITSBITMAPINFO: BITMAPINFOHEADER;
  BITMAP_INFO       : ^BITMAPINFO;
  pbBits32          : pointer;
  hData             : THandle;
  pData             : PRgnData;
  lr, lg, lb, hr, hg, hb: Byte;
  b                 : Byte;
  p32               : PByte;
  p                 : PLONG;
  x, y, x0          : Integer;
  pr                : ^TRectArray;
Begin
  Rgn := 0;

  { Create a memory DC inside which we will scan the bitmap content }
  hMemDC := CreateCompatibleDC(0);
  If hMemDC > 0 Then
  Begin
    { get Bitmap size }
    GetObject(hBmp, SizeOf(bm), @bm);

    { Create a 32-bit depth bitmap and select it into the memory DC }
    With RGB32BITSBITMAPINFO Do
    Begin
      biSize := sizeof(BITMAPINFOHEADER); // biSize
      biWidth := bm.bmWidth;            // biWidth;
      biHeight := bm.bmHeight;          // biHeight;
      biPlanes := 1;                    // biPlanes;
      biBitCount := 32;                 // biBitCount
      biCompression := BI_RGB;          // biCompression;
      biSizeImage := 0;                 // biSizeImage;
      biXPelsPerMeter := 0;             // biXPelsPerMeter;
      biYPelsPerMeter := 0;             // biYPelsPerMeter;
      biClrUsed := 0;                   // biClrUsed;
      biClrImportant := 0;              // biClrImportant;
    End;
    BITMAP_INFO := @RGB32BITSBITMAPINFO; // points to the previous structure

    hBmp32 := CreateDIBSection(hMemDC, BITMAP_INFO^, DIB_RGB_COLORS,
      pbBits32, 0, 0);
    If hBmp32 > 0 Then
    Begin
      HoldBmp := SelectObject(hMemDC, hBmp32);

      { Create DC just to copy bitmap into the memory DC }
      h_DC := CreateCompatibleDC(hMemDC);
      If h_DC > 0 Then
      Begin
        { Get how many bytes per row we have for the bitmap bits (rounded up
        to 32 bits) }
        GetObject(hBmp32, SizeOf(bm32), @bm32);
        While (bm32.bmWidthBytes Mod 4 <> 0) Do
          Inc(bm32.bmWidthBytes);

        { Copy the bitmap into the memory DC }
        HoldBmp := SelectObject(h_DC, hBmp);
        BitBlt(hMemDC, 0, 0, bm.bmWidth, bm.bmHeight, h_DC, 0, 0, SRCCOPY);

        { For better performance, we will use the ExtCreateRegion() function
        to create the region. This function take a RGNDATA structure on
        entry. We will add rectangles by amount of ALLOC_UNIT number in this
        structure. }
       // MaxRects := AllocUnit;
        hData := GlobalAlloc(GMEM_MOVEABLE, SizeOf(RGNDATAHEADER) +
          (SizeOf(TRect) * maxRects));
        pData := GlobalLock(hData);
        With pData^.rdh Do
        Begin
          dwSize := SizeOf(RGNDATAHEADER);
          iType := RDH_RECTANGLES;
          nCount := 0;
          nRgnSize := 0;
          SetRect(rcBound, MAXLONG, MAXLONG, 0, 0);
        End;

        { Keep on hand highest and lowest values for the "transparent"
        pixels }
        lr := GetRValue(cTransparentColor);
        lg := GetGValue(cTransparentColor);
        lb := GetBValue(cTransparentColor);
        hr := Min($FF, lr + GetRValue(cTolerance));
        hg := Min($FF, lg + GetGValue(cTolerance));
        hb := Min($FF, lb + GetBValue(cTolerance));

        { Scan each bitmap row from bottom to top (the bitmap is inverted
        vertically) }
        p32 := PByte(Integer(bm32.bmBits) + (bm32.bmHeight - 1) *
          bm32.bmWidthBytes);
        For y := 0 To bm.bmHeight - 1 Do
        Begin
          { Scan each bitmap pixel from left to right }
          // for x := 0 to bm.bmWidth - 1 do
          x := 0;
          While x < bm.bmWidth Do
          Begin
            { Search for a continuos range of "non transparent pixels" }
            x0 := x;
            p := PLONG(Integer(p32) + x * SizeOf(LONG));
            While x < bm.bmWidth Do
            Begin
              b := GetRValue(p^);
              If (b >= lr) And (b <= hr) Then
              Begin
                b := GetGValue(p^);
                If (b >= lg) And (b <= hg) Then
                Begin
                  b := GetBValue(p^);
                  If (b >= lb) And (b <= hb) Then
                  Begin
                    Break;              // this pixel is transparent
                  End;
                End;
              End;
              inc(p);
              inc(x);
            End;                        // while x < bm.bmWidth

            If x > x0 Then
            Begin
              { Add the pixels (x0, y) to (x, y+1) as a new rectangle in
              the region }
              If pData^.rdh.nCount >= maxRects Then
              Begin
                GlobalUnlock(hData);
               // Inc(maxRects, AllocUnit);
                hData := GlobalReAlloc(hData, SizeOf(RGNDATAHEADER) +
                  (SizeOf(TRect) * MaxRects), GMEM_MOVEABLE);
                pData := GlobalLock(hData);
              End;

              pr := @pData^.Buffer;
              SetRect(pr^[pData^.rdh.nCount], x0, y, x, y + 1);
              With pData^.rdh Do
              Begin
                If x0 < rcBound.Left Then rcBound.Left := x0;
                If y < rcBound.Top Then rcBound.Top := y;
                If x > rcBound.Right Then rcBound.Right := x;
                If y + 1 > rcBound.Bottom Then rcBound.Bottom := y + 1;
                Inc(nCount);
              End;
            End;

            { On Windows98, ExtCreateRegion() may fail if the number of
            rectangles is too large (ie: > 4000). Therefore, we have to
            create the region by multiple steps. }
            If pData^.rdh.nCount = 2000 Then
            Begin
              h := ExtCreateRegion(Nil, SizeOf(RGNDATAHEADER) +
                (SizeOf(TRect) * maxRects), pData^);
              If Rgn > 0 Then
              Begin
                CombineRgn(Rgn, Rgn, h, RGN_OR);
                DeleteObject(h);
              End
              Else
                Rgn := h;
              pData^.rdh.nCount := 0;
              SetRect(pData^.rdh.rcBound, MAXLONG, MAXLONG, 0, 0);
            End;

            Inc(x);
          End; { for x := 0 to bm.Width - 1 (used a While loop to be able
          to make Inc(x);) }
          { Go to next row (remember, the bitmap is inverted vertically) }
          Dec(p32, bm32.bmWidthBytes);
        End;                            // for y := 0 to bm.Height - 1

        { Create or extend the region with the remaining rectangles }
        h := ExtCreateRegion(Nil, SizeOf(RGNDATAHEADER) + (SizeOf(TRect) *
          MaxRects), pData^);
        If Rgn > 0 Then
        Begin
          CombineRgn(Rgn, Rgn, h, RGN_OR);
          DeleteObject(h);
        End
        Else
          Rgn := h;

        GlobalFree(hData);
        SelectObject(h_DC, holdBmp);
        DeleteDC(h_DC);
      End;                              // if h_DC > 0
      DeleteObject(SelectObject(hMemDC, holdBmp));
    End;                                // if hBmp32 > 0
    DeleteObject(hMemDC);
  End;                                  // if hMemDC > 0
  Result := Rgn;
End;

End.

 