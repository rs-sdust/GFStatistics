;********************************************************************************
; entropy.pro
;
; 作者： 刘承前、yxq
;
; 创建时间：20160627
;
; 描述：图像信息熵计算
;
; 参数说明：
;
;   inputfile			    输入后验概率影像
;	  outputfile			输出影像信息熵
;
; 调用示例：
;
;   executestring（"entropy,'c:\infile.tif','c:\outfile.tif'"）
;
; 修改记录：
;
;   20160628  yxq  添加调用参数。
;*********************************************************************************/

pro entropy,inputfile,outputfile

  compile_opt idl2
  envi,/restore_base_save_files
  envi_batch_init

  ;打开文件
  ;  inputfile = 'c:\users\qian\desktop\6.27\rule.tif'
  ;  outputfile = 'c:\users\qian\desktop\6.27\rule_out.tif'
  envi_open_file, inputfile, r_fid=fid
  if (fid eq -1) then begin
    return
  endif

  ;获取文件信息
  envi_file_query, fid, dims=dims, ns=ns,nl=nl,nb=nb,description = description,$
    samples = samples,$
    lines   = lines,$
    bands   = bands,$
    header_offset = header_offset,$
    file_type = file_type,$
    data_type = data_type,$
    interleave = interleave,$
    ;    sensor_type = sensor_type,$
    ;    byte_order = byte_order,$
    map_info = map_info;,$
  ;    wavelength_units = wavelength_units

  ;创建容器数组
  data = make_array(ns,nl,nb + 1,/float,value = 0)
  ;读数据
  for i = 0l, nb-1 do begin
    tempdata = envi_get_data(fid=fid, dims=dims, pos=i)
    data[*,*,i] = tempdata[*,*]
  endfor
  ;翻译公式
  for i = 0l, nb-1 do begin
    data[*,*,i] = (data[*,*,i])*(alog10(data[*,*,i]))
  endfor

  for i = 0l, nb-1 do begin
    data[*,*,nb] += data[*,*,i]
  endfor
  ;结果数据
  finaldata = (-1)*data[*,*,nb]
  ;创建envi格式的mapinfo
  map_info = envi_get_map_info(fid=fid)
  ;写文件
  envi_write_envi_file,$
    finaldata, out_name=outputfile, $
    description = description,$
    samples = samples,$
    lines   = lines,$
    bands   = bands,$
    header_offset = header_offset,$
    file_type = file_type,$
    data_type = data_type,$
    interleave = interleave,$
    ;sensor_type = sensor_type,$
    ;byte_order = byte_order,$
    map_info = map_info;,$
  ;wavelength_units = wavelength_units
end