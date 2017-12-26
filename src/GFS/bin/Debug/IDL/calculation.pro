;+
; :Description:
;
;-
pro Calculation
  COMPILE_OPT IDL2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  in_file_path = 'G:\GF3分类数据\过程与结果数据\Classification\RS2_2014_object_pixel.tif'
  out_file_name = 'G:\GFS_zhongmu\冬小麦识别\中牟县冬小麦识别_error.tif'
  windowSize = 45
  targetValue = 1
  Probability_calculation,in_file_path,windowSize,targetValue,out_file_name
end
pro Probability_calculation,in_file_path,windowSize,targetValue,out_file_name
  compile_opt idl2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ENVI_OPEN_FILE,in_file_path,R_FID=fid
  ENVI_FILE_QUERY,fid,dims=dims,ns=ns,nl=nl,nb=nb
  pos = BINDGEN(nb)
  in_data = ENVI_GET_DATA(fid=fid,dims=dims,pos=pos)
  step = (windowSize-1)/2
  outdata = MAKE_ARRAY(ns,nl,value=0.0)
  for i=0,nl-1 do begin
    for j=0,ns-1 do begin
      ;if(in_data[j,i] eq 256) then continue
      if(in_data[j,i] ne targetValue) then begin
        ;outdata[j,i] = 256.0
        continue
      endif
      m0 = i-step ge 0?i-step:0
      m1 = i+step le nl-1?i+step:nl-1
      n0 = j-step ge 0?j-step:0
      n1 = j+step le ns-1?j+step:ns-1
      tempdata = in_data[n0:n1,m0:m1]
      index = where(tempdata eq targetValue)
      if index[0] eq -1 then continue
      num = N_ELEMENTS(index)
      total_num = N_ELEMENTS(tempdata)
      outdata[j,i] = 1.0-(float(num)/float(total_num))
    endfor  
  endfor
  mapinfo = ENVI_GET_MAP_INFO(fid=fid)
  ENVI_WRITE_ENVI_FILE,outdata,OUT_NAME=out_file_name,OUT_DT=4,$
    MAP_INFO=mapinfo,R_FID=rfid
  outdata = !NULL
  ENVI_FILE_MNG,id=fid,/REMOVE
  ENVI_FILE_MNG,id=fid,/REMOVE  
end

