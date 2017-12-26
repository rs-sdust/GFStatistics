;	从一幅多波段影像中移除指定波段
;	inFile 输入影像
;	inBands 波段记录txt文件，参考bandreduction.txt（注意IDL中波段序号如果是从零开始，文本中的序号需要减一）
;	outFile 输出文件

;pro mainfunction
;  compile_opt idl2
;  infile = 'G:\hyperion\EO1H1190372007289110PV.tif'
;  inBands = 'G:\hyperion\bands.txt'
;  outFile = 'G:\hyperion\out.tif'
;  bandreduction, inFile,inBands,outFile
;end
;+
; :Description:
;
;-
pro bandreduction, inFile,inBands,outFile
  compile_opt idl2
  ENVI, /restore_base_save_files
  ENVI_BATCH_INIT
;  CATCH, errorStatus
  openr,1,inBands
  temp = ''
  readf,1,temp
  FREE_LUN, 1
  tempa = STRSPLIT(temp,',',/EXTRACT,COUNT=count)
  tempb = INDGEN(count)
  for i=0,count-1 do begin
    tempb[i] = fix(tempa[i])-1
  endfor
  ENVI_OPEN_FILE,inFile,r_fid=fid
  ENVI_FILE_QUERY,fid,dims=dims,nb=nb,DATA_TYPE=out_dt,nl=nl,ns=ns
  if(max(tempb) ge nb) then begin
    inf = DIALOG_MESSAGE('The Rmove Band great than the total number of image',/ERROR,/CANCEL)
  endif else begin
    num = nb - N_ELEMENTS(tempb)
    pos = BINDGEN(num)
    a = 0
    for i=0,nb-1 do begin
      index = where(i eq tempb)
      if(index eq -1) then begin
        pos[a]  =i
        a++
      endif
    endfor
;CATCH,ex
    inf = DIALOG_MESSAGE("create arr...",/ERROR,/CANCEL)
    if(out_dt eq 1) then begin
      data = bytarr(num,ns,nl)
    endif else if(out_dt eq 2 or out_dt eq 3)then begin
      data = intarr(num,ns,nl)
    endif  else  begin
      data = fltarr(num,ns,nl)
    endelse
    
;CATCH,/cancel
    inf = DIALOG_MESSAGE("create arr succeed , get data...",/ERROR,/CANCEL)
    for i=0,num-1 do begin
      data[i,*,*] = ENVI_GET_DATA(fid=fid,pos=pos[i],dims=dims)
    endfor
    inf = DIALOG_MESSAGE("get data succeed , write data...",/ERROR,/CANCEL)
    mapinfo = ENVI_GET_MAP_INFO(fid=fid)
    ENVI_WRITE_ENVI_FILE,data,OUT_NAME=outFile,OUT_DT=out_dt,MAP_INFO=mapinfo,INTERLEAVE =2,NB=num,R_FID=aaa
    inf = DIALOG_MESSAGE("write data succeed",/ERROR,/CANCEL)
;    CATCH, /CANCEL
;    PRINT, !ERROR_STATE.MSG
;    ENVI_FILE_MNG,id=aaa,/REMOVE
;    ENVI_FILE_MNG,id=fid,/REMOVE
;    data = !NULL
;    ENVI_BATCH_EXIT, /NO_CONFIRM
  endelse
end
