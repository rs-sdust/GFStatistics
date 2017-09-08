;pro FX_Segmentonly
;  COMPILE_OPT IDL2
;  ENVI, /RESTORE_BASE_SAVE_FILES
;  ENVI_BATCH_INIT
;  InputFile = "J:\北师大\Feature_Extraction\GF1_PMS1_E1154_N378_20140607_L1A0000246663-MSS1_subset.tif"
;  OutputFile = "J:\北师大\OUT\OUt.dat" 
;  Segment_Settings_Scale_Level = 50.0
;  Merge_Settings_scale_level = 40.0
;  Kernel_Size = 9
;  envi_fx_segmentonly,InputFile,Segment_Settings_Scale_Level,Merge_Settings_scale_level,Kernel_Size,OutputFile
;end

;+
; :Description:
;    Describe the procedure.
;    实现图像分割
;    
; :Params:
;    InputFile：待分割图像
;    Segment_Settings_Scale_Level:分割尺度
;    Merge_Settings_scale_level:融合尺度
;    Kernel_Size:纹理内核大小
;    OutputFile:分割输出结果
;    
; :Author: 杨以坤
;-

PRO FX_Segmentonly,InputFile,Segment_Settings_Scale_Level,Merge_Settings_scale_level,Kernel_Size,OutputFile
  COMPILE_OPT idl2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ENVI_OPEN_FILE,InputFile,r_fid=fid
  ENVI_FILE_QUERY,fid,dims=dims,nb=nb
  pos = lindgen(nb)
  ENVI_DOIT, 'envi_fx_segmentonly_doit', $
    fid=fid, pos=pos, dims=dims,r_fid=r_fid, $
    merge_level=Merge_Settings_scale_level, $
    scale_level=Segment_Settings_Scale_Level, $
    segmentation_raster_filename=OutputFile,KERNEL_SIZE=Kernel_Size
  ENVI_FILE_MNG,id=r_fid,/REMOVE
  ENVI_FILE_MNG,id=fid,/REMOVE
END
