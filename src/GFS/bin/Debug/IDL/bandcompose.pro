;********************************************************************************
; bandcompose.pro
;
; 作者： 周雪莹
;
; 创建时间：20160629
;
; 描述：波段合成
;
; 参数说明：
;
;   indir       输入段存储目录
;   outname     输出影像
;
; 调用示例：
;
;   executestring（"bandcompose,'c:\indir\',c:\outname.tif'"）
;
; 修改记录：
;
;   20160630  刘承前/yxq 修改输入参数为输入段存储目录
;
;*********************************************************************************/
pro bandcompose,indir,outname

  compile_opt idl2
  envi, /restore_base_save_files
  envi_batch_init
  ; 描述：波段合成
  file_tif = file_search(indir,'*.tif',count = count1,/test_regular)
  ;  indir = 'e:\out\b1.tif,e:\out\b2.tif,e:\out\b3.tif,e:\out\b4.tife:\out\b5.tif,e:\out\b6.tif,e:\out\b7.tif'
  ;  out_name = 'e:\out2\out2.tif'
  ;  file_tif=strsplit(indir, ',', /extract)
  num=n_elements(file_tif)
  fid_all=intarr(num)
  bandname = file_tif
  for i = 0,num-1,1 do begin
    bandname[i] = file_basename(file_tif[i], '.tif')
  endfor

  for i=0,num-1 do begin
    envi_open_file,file_tif[i],r_fid=r_fid
    fid_all[i]=r_fid
  endfor

  envi_file_query,fid_all[0], ns=ns, nl=nl,dims=datadims
  nb = num
  fid = lonarr(nb)
  pos = lonarr(nb)
  dims = lonarr(5,nb)
  out_bname=strarr(num)
  for n=0,nb-1 do begin
    dims[*,n]=datadims
    fid[n]=fid_all[n]
  endfor

  out_bname = bandname
  out_proj  = envi_get_projection(fid=fid_all[0], $
    pixel_size=out_ps)
  out_dt = 4
  envi_doit, 'envi_layer_stacking_doit', $
    fid=fid, pos=pos, dims=dims, $
    out_dt=out_dt, out_name=outname,in_memory=in_memory, $
    interp=2, out_ps=out_ps,out_bname=out_bname, $
    out_proj=out_proj, r_fid=r_fid
end