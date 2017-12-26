;********************************************************************************
; banddecompose.pro
;
; ���ߣ� ��ѩӨ
;
; ����ʱ�䣺20160629
;
; ���������ηֽ�
;
; ����˵����
;
;   infile     ����Ӱ��
;   outdir     ������δ洢Ŀ¼
;
; ����ʾ����
;
;   executestring��"banddecompose,'c:\infile.tif',c:\outdir'"��
;
; �޸ļ�¼��
;
;   20160630  yxq �޸�������������ע�ͣ��Ƴ����������޸����������
;
;*********************************************************************************/
pro banddecompose,infile,outdir

  compile_opt idl2
  envi, /restore_base_save_files
  envi_batch_init

  ;infile = 'h:\xinjiang_zhundong\landsat_2\1.flaash\2000_246.tif'
  ;  infile = dialog_pickfile(title = 'select files', /multiple_files)
  ;outdir = 'e:\'
  ;  outdir = dialog_pickfile(title = 'select output file path',/directory)

  num=n_elements(infile)

  fid_all=intarr(num)

  for i=0,num-1 do begin
    envi_open_file,infile[i],r_fid=r_fid
    fid_all[i]=r_fid
  endfor


  for i = 0,num-1,1 do begin
    ;    envi_report_stat, base,i+1, num
    ;    envi_report_inc, base, float(num)/(i+1)

    map_info  = envi_get_map_info(fid=fid_all[i])
    envi_open_file,infile[i],r_fid=r_fid
    envi_file_query,fid_all[i], ns=ns, nl=nl,dims=dims,bnames=bnames,nb=nb
    file_name = file_basename(infile[i], '.tif')


    ;    envi_report_init,['processing...'], title='saving the bands', base=base,/interrupt
    for j = 0,nb-1,1 do begin
      ;      envi_report_stat, base,j+1, nb
      ;      envi_report_inc, base, float(nb)/(j+1)

      bandname = bnames[j]
      ;      out_name =outdir+'b'+strmid(string(j+1),10,2)+'.tif'
      out_name =outdir+'B'+strtrim(string(j+1),1)+'.tif'
      print,out_name
      arr = envi_get_data(fid = fid_all[i],pos = j,dims = dims )

      envi_write_envi_file,arr,out_name = out_name,bnames = bandname,map_info=map_info
    endfor
    ;    envi_report_init, base=base, /finish,/interrupt
  endfor

  ;  rs = dialog_message('�����ɹ���',/information)


end