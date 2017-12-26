;********************************************************************************
; bandmath.pro
;
; 作者： 刘承前
;
; 创建时间：20160629
;
; 描述：波段运算
;
; 参数说明：
;
;   infiles      输入影像
;   out_name     输出影像
;   exp			          运算公式
;
; 调用示例：
;
;   executestring（"bandmath,'c:\1.tif,c:\2.tif','c:\out.tif','b1 + b2'"）
;
; 修改记录：
;
;   20160630  yxq 移除波段绑定
;
;*********************************************************************************/
pro bandmath,infiles,out_name,exp
  compile_opt strictarr
  envi, /restore_base_save_files
  envi_batch_init, log_file='batch.txt'
  ;  infiles = 'c:\users\qian\desktop\6.27\we.tif,c:\users\qian\desktop\6.27\er.tif,c:\users\qian\desktop\6.27\rt.tif'
  ;  out_name = 'c:\users\qian\desktop\6.27\gagaga.tif'
  file_names=strsplit(infiles, ',', /extract)
  num_bands=n_elements(file_names)
  fid_array = lonarr(num_bands)
  ;  打开文件，将所有r_fid存入fid_array数组里
  for i=0,num_bands-1 do begin
    envi_open_file,file_names[i],r_fid = fid
    fid_array[i] = fid
  endfor
  pos = intarr(num_bands)
  out_fid=intarr(num_bands)
  envi_file_query,fid_array, dims = dims

  ;波段运算
  envi_doit, 'math_doit', dims=dims, exp=exp, pos=pos, $
    fid=fid_array, out_name=out_name, r_fid=r_fid, /in_memory
  out_fid=r_fid
  ;  结果另存
  pos = intarr(num_bands)
  envi_doit, 'cf_doit', dims=dims, fid=out_fid, pos=pos, out_dt=2, $
    out_name=out_name, /remove, r_fid=result_fid
  envi_batch_exit
end