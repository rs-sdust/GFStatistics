;********************************************************************************
; entropy.pro
;
; ���ߣ� ����ǰ��yxq
;
; ����ʱ�䣺20160627
;
; ������ͼ����Ϣ�ؼ���
;
; ����˵����
;
;   inputfile			    ����������Ӱ��
;	  outputfile			���Ӱ����Ϣ��
;
; ����ʾ����
;
;   executestring��"entropy,'c:\infile.tif','c:\outfile.tif'"��
;
; �޸ļ�¼��
;
;   20160628  yxq  ��ӵ��ò�����
;*********************************************************************************/

pro entropy,inputfile,outputfile

  compile_opt idl2
  envi,/restore_base_save_files
  envi_batch_init

  ;���ļ�
  ;  inputfile = 'c:\users\qian\desktop\6.27\rule.tif'
  ;  outputfile = 'c:\users\qian\desktop\6.27\rule_out.tif'
  envi_open_file, inputfile, r_fid=fid
  if (fid eq -1) then begin
    return
  endif

  ;��ȡ�ļ���Ϣ
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

  ;������������
  data = make_array(ns,nl,nb + 1,/float,value = 0)
  ;������
  for i = 0l, nb-1 do begin
    tempdata = envi_get_data(fid=fid, dims=dims, pos=i)
    data[*,*,i] = tempdata[*,*]
  endfor
  ;���빫ʽ
  for i = 0l, nb-1 do begin
    data[*,*,i] = (data[*,*,i])*(alog10(data[*,*,i]))
  endfor

  for i = 0l, nb-1 do begin
    data[*,*,nb] += data[*,*,i]
  endfor
  ;�������
  finaldata = (-1)*data[*,*,nb]
  ;����envi��ʽ��mapinfo
  map_info = envi_get_map_info(fid=fid)
  ;д�ļ�
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