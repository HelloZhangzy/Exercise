  unit HardWare;

  interface

  uses
    Windows, Messages, SysUtils, Variants, Classes, Controls, Forms,
    Dialogs, ComCtrls,ExtCtrls, StdCtrls, Mask,StrUtils,inifiles,ShellAPI;



    // AT88SC102 操作函数
    function swr_102(icdev: longint;zone: smallint;offset: smallint;len: smallint;data1: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'swr_102'; //向指定地址写数据
    function srd_102(icdev: longint;zone: smallint;offset: smallint;len: smallint;data1: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'srd_102'; //从指定地址读数据
    function ser_102(icdev: longint;zone: smallint;offset: smallint;len: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'ser_102'; //擦除数据
    function chk_102(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'chk_102'; //检查卡型是否正确

    function csc_102(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'csc_102'; //核对卡密码
    function wsc_102(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'wsc_102'; //改定卡密码
    function rsc_102(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'rsc_102'; //读出卡密码
    function rsct_102(icdev: longint;counter: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'rsct_102'; //读出密码错误计数器的值
    function cesc_102(icdev: longint;zone: smallint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'cesc_102'; //核对卡擦除密码
    function wesc_102(icdev: longint;zone: smallint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'wesc_102'; //改写卡擦除密码
    function resc_102(icdev: longint;zone: smallint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'resc_102'; //读出卡擦除密码
    function resct_102(icdev: longint;zone: smallint;counter: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'resct_102'; //读出擦除密码错误计数器值
    function fakefus_102(icdev: longint;mode: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'fakefus_102'; //模拟个人化操作
    function clrpr_102(icdev: longint;zone: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'clrpr_102'; //写保护位清0
    function clrrd_102(icdev: longint;zone: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'clrrd_102'; //读保护位清0
    function psnl_102(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'psnl_102'; //个人化操作

    //IC卡通用函数
    function ic_init(port: Integer;baud: Integer): longint; stdcall;
    far;external 'Mwic_32.dll' name 'ic_init'; //初始化通讯接口
    function auto_init(port: longint;baud: longint): longint; stdcall;
    far;external 'Mwic_32.dll' name 'auto_init'; //自适应式初始化函数
    function ic_exit(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'ic_exit'; //关闭通讯口
    function get_status(icdev: longint;status: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'get_status'; //返回设备当前状态
    function chk_band(port: longint):longint;stdcall;
    far;external 'Mwic_32.dll' name 'chk_band'; //自动检测通讯方式
    function chk_card(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'chk_card'; //测卡类型

    function cmp_dvsc(icdev:longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'cmp_dvsc'; //比较设备密码
    function setsc_md(icdev: longint;mode: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'setsc_md'; //设置设备密码模式
    function srd_dvsc(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'srd_dvsc'; //读出设备密码
    function swr_dvsc(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'swr_dvsc'; //改写设备密码

    function turn_off(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'turn_off'; //对卡下电
    function turn_on(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'turn_on'; //对卡上电
    function srd_ver(icdev: longint;len: smallint;version: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'srd_ver'; //读取设备版本号
    function dv_beep(icdev: longint;time: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'dv_beep'; //读写器蜂鸣
    function set_band(icdev: longint;band: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'set_band'; //设置串口方式下的波特率或并口的通讯方式

    function asc_hex(password: pchar;password1: pchar;lengths: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'asc_hex'; //将ASCII码转换为十六进制数据
    function hex_asc(password1: pchar;password: pchar;lengths: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'hex_asc'; //将十六进制数据转换为ASCII码

    function ic_encrypt(key: pchar;ptrsource: pchar;msglen: smallint;ptrdest: pchar):smallint;
    stdcall;far;external 'Mwic_32.dll'name 'ic_encrypt'; //DES算法加密函数
    function ic_decrypt(key: pchar;ptrdest: pchar;msglen: smallint;ptrsource: pchar):smallint;
    stdcall;far;external 'Mwic_32.dll'name 'ic_decrypt'; //DES算法解密函数

  
  //-----------------------------------------------


  // SLE4442 操作函数
  function chk_4442(icdev: longint):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'chk_4442'; //检查卡型是否正确
  function swr_4442(icdev: longint;offset:smallint;length:smallint;data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'swr_4442'; //向指定地址写数据
  function srd_4442(icdev: longint;offset:smallint;length:smallint; data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'srd_4442'; //从指定地址读数据
  function prd_4442(icdev: longint;length:smallint;data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'prd_4442'; //读保护位
  function pwr_4442(icdev: longint;offset:smallint;length:smallint;data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'pwr_4442'; //保护指定地址的数据

  function csc_4442(icdev: longint;length:smallint;password:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'csc_4442'; //核对卡密码
  function wsc_4442(icdev: longint;length:smallint; password:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'wsc_4442'; //改写卡密码
  function rsc_4442(icdev: longint;length:smallint; password:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'rsc_4442'; //读出卡密码
  function rsct_4442(icdev: longint;counter:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'rsct_4442'; //读出密码错误计数器值



implementation     



  end.

