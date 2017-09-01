pro Example_Based_Feature_Extraction_Program
  COMPILE_OPT IDL2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  InputFile = ""
  OutputFile = "" 
  Segment_Settings_Scale_Level = 50.0
  Merge_Settings_scale_level = 40.0
  Kernel_Size = 9
  Example_Based_Feature_Extraction,InputFile,Segment_Settings_Scale_Level,Merge_Settings_scale_level,Kernel_Size,OutputFile
end
PRO Example_Based_Feature_Extraction,InputFile,Segment_Settings_Scale_Level,Merge_Settings_scale_level,Kernel_Size,OutputFile
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
