  unit HardWare;

  interface

  uses
    Windows, Messages, SysUtils, Variants, Classes, Controls, Forms,
    Dialogs, ComCtrls,ExtCtrls, StdCtrls, Mask,StrUtils,inifiles,ShellAPI;



    // AT88SC102 ��������
    function swr_102(icdev: longint;zone: smallint;offset: smallint;len: smallint;data1: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'swr_102'; //��ָ����ַд����
    function srd_102(icdev: longint;zone: smallint;offset: smallint;len: smallint;data1: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'srd_102'; //��ָ����ַ������
    function ser_102(icdev: longint;zone: smallint;offset: smallint;len: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'ser_102'; //��������
    function chk_102(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'chk_102'; //��鿨���Ƿ���ȷ

    function csc_102(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'csc_102'; //�˶Կ�����
    function wsc_102(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'wsc_102'; //�Ķ�������
    function rsc_102(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'rsc_102'; //����������
    function rsct_102(icdev: longint;counter: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'rsct_102'; //������������������ֵ
    function cesc_102(icdev: longint;zone: smallint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'cesc_102'; //�˶Կ���������
    function wesc_102(icdev: longint;zone: smallint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'wesc_102'; //��д����������
    function resc_102(icdev: longint;zone: smallint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'resc_102'; //��������������
    function resct_102(icdev: longint;zone: smallint;counter: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'resct_102'; //��������������������ֵ
    function fakefus_102(icdev: longint;mode: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'fakefus_102'; //ģ����˻�����
    function clrpr_102(icdev: longint;zone: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'clrpr_102'; //д����λ��0
    function clrrd_102(icdev: longint;zone: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'clrrd_102'; //������λ��0
    function psnl_102(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'psnl_102'; //���˻�����

    //IC��ͨ�ú���
    function ic_init(port: Integer;baud: Integer): longint; stdcall;
    far;external 'Mwic_32.dll' name 'ic_init'; //��ʼ��ͨѶ�ӿ�
    function auto_init(port: longint;baud: longint): longint; stdcall;
    far;external 'Mwic_32.dll' name 'auto_init'; //����Ӧʽ��ʼ������
    function ic_exit(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'ic_exit'; //�ر�ͨѶ��
    function get_status(icdev: longint;status: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'get_status'; //�����豸��ǰ״̬
    function chk_band(port: longint):longint;stdcall;
    far;external 'Mwic_32.dll' name 'chk_band'; //�Զ����ͨѶ��ʽ
    function chk_card(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'chk_card'; //�⿨����

    function cmp_dvsc(icdev:longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll' name 'cmp_dvsc'; //�Ƚ��豸����
    function setsc_md(icdev: longint;mode: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'setsc_md'; //�����豸����ģʽ
    function srd_dvsc(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'srd_dvsc'; //�����豸����
    function swr_dvsc(icdev: longint;len: smallint;password: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'swr_dvsc'; //��д�豸����

    function turn_off(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'turn_off'; //�Կ��µ�
    function turn_on(icdev: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'turn_on'; //�Կ��ϵ�
    function srd_ver(icdev: longint;len: smallint;version: pchar):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'srd_ver'; //��ȡ�豸�汾��
    function dv_beep(icdev: longint;time: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'dv_beep'; //��д������
    function set_band(icdev: longint;band: longint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'set_band'; //���ô��ڷ�ʽ�µĲ����ʻ򲢿ڵ�ͨѶ��ʽ

    function asc_hex(password: pchar;password1: pchar;lengths: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'asc_hex'; //��ASCII��ת��Ϊʮ����������
    function hex_asc(password1: pchar;password: pchar;lengths: smallint):smallint;stdcall;
    far;external 'Mwic_32.dll'name 'hex_asc'; //��ʮ����������ת��ΪASCII��

    function ic_encrypt(key: pchar;ptrsource: pchar;msglen: smallint;ptrdest: pchar):smallint;
    stdcall;far;external 'Mwic_32.dll'name 'ic_encrypt'; //DES�㷨���ܺ���
    function ic_decrypt(key: pchar;ptrdest: pchar;msglen: smallint;ptrsource: pchar):smallint;
    stdcall;far;external 'Mwic_32.dll'name 'ic_decrypt'; //DES�㷨���ܺ���

  
  //-----------------------------------------------


  // SLE4442 ��������
  function chk_4442(icdev: longint):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'chk_4442'; //��鿨���Ƿ���ȷ
  function swr_4442(icdev: longint;offset:smallint;length:smallint;data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'swr_4442'; //��ָ����ַд����
  function srd_4442(icdev: longint;offset:smallint;length:smallint; data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'srd_4442'; //��ָ����ַ������
  function prd_4442(icdev: longint;length:smallint;data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'prd_4442'; //������λ
  function pwr_4442(icdev: longint;offset:smallint;length:smallint;data1:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'pwr_4442'; //����ָ����ַ������

  function csc_4442(icdev: longint;length:smallint;password:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'csc_4442'; //�˶Կ�����
  function wsc_4442(icdev: longint;length:smallint; password:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'wsc_4442'; //��д������
  function rsc_4442(icdev: longint;length:smallint; password:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'rsc_4442'; //����������
  function rsct_4442(icdev: longint;counter:pchar):smallint;stdcall;
  far;external 'Mwic_32.dll'name 'rsct_4442'; //����������������ֵ



implementation     



  end.

