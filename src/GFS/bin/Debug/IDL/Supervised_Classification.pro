PRO SUPERVISED_CLASSIFICATION
  COMPILE_OPT idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  InputFilename = "G:\新建文件夹\北师大\OUT\OUt.img"
  ExampleShpFile = "G:\新建文件夹\北师大\新建文件夹1\color_sample\sample.shp"
  OutFileName = "G:\新建文件夹\北师大\ziji\idlshiyanclassyyk111.img"
  MAXIMUM_LIKELIHOOD_CLASSIFICATION,InputFilename,ExampleShpFile,OutFileName
END
;+
; :DESCRIPTION:
;    Describe the procedure.
;  利用最大似然法实现面向对象的分类
; :PARAMS:
;    InputFilename：待分类影像
;    ExampleShpFile：样本点Shp文件
;       Shp文件属性表格式：FID   Shape    CLASS_NAME CLASS_ID   CLASS_CLRS
;                    属性：           Geometry  String(40) String(10) String(12)
;                    值：                Polygon   City(Road) 1(2,3,4,5) 1(2,3,4,5)
;    OutFileName:分类结果绝对路径
;
; :AUTHOR: Yikun Yang
;-
PRO MAXIMUM_LIKELIHOOD_CLASSIFICATION,InputFilename,ExampleShpFile,OutFileName
  COMPILE_OPT idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ENVI_OPEN_FILE,InputFilename,r_fid=fid
  ENVI_FILE_QUERY,fid,nl=nl,ns=ns,nb=nb,dims=dims
  oshp=OBJ_NEW('IDLffShape',ExampleShpFile)
  oshp->GETPROPERTY,n_entities=n_ent,Attribute_info=attr_info,n_attributes=n_attr,Entity_type=ent_type,ATTRIBUTE_NAMES=ATTRIBUTE_NAME
  ;ROI
  ROI_IDS = LONARR(n_ent)
  color = STRARR(n_ent)
  backup_color = STRARR(n_ent)
  temp_roi_id = 0
  FOR j = 0,n_ent-1 DO BEGIN
    ent1=oshp->GETATTRIBUTES(j)
    ent2=oshp->GETENTITY(j)
    vert=*(ent2.VERTICES)
    ENVI_CONVERT_FILE_COORDINATES,fid,XPTS,YPTS,vert[0,*],vert[1,*]
    ROI_NAME = ent1.ATTRIBUTE_0
    color[j] = ent1.ATTRIBUTE_1
    backup_color[j] = ent1.ATTRIBUTE_2
    IF j EQ 0 THEN BEGIN
      ROI_IDS[J] = ENVI_CREATE_ROI(color=color[j], name=ROI_NAME,nl=nl,ns=ns)
      num = N_ELEMENTS(XPTS)
      XPTS = REFORM(XPTS,num)
      YPTS = REFORM(YPTS,num)
      ENVI_DEFINE_ROI, ROI_IDS[J] , /POLYGON, XPTS=XPTS, YPTS=YPTS
      oshp->DESTROYENTITY, ent2
      temp_roi_id = ROI_IDS[J]
    ENDIF ELSE BEGIN
      IF color[j] EQ color[j-1] THEN BEGIN
        num = N_ELEMENTS(XPTS)
        XPTS = REFORM(XPTS,num)
        YPTS = REFORM(YPTS,num)
        ENVI_DEFINE_ROI, temp_roi_id , /POLYGON, XPTS=XPTS, YPTS=YPTS,/NO_UPDATE
        oshp->DESTROYENTITY, ent2
      ENDIF ELSE BEGIN
        ROI_IDS[J] = ENVI_CREATE_ROI(color=color[j], name=ROI_NAME,nl=nl,ns=ns)
        num = N_ELEMENTS(XPTS)
        XPTS = REFORM(XPTS,num)
        YPTS = REFORM(YPTS,num)
        ENVI_DEFINE_ROI, ROI_IDS[J] , /POLYGON, XPTS=XPTS, YPTS=YPTS
        oshp->DESTROYENTITY, ent2
        temp_roi_id = ROI_IDS[J]
      ENDELSE
    ENDELSE
  ENDFOR
  roiid = roi_ids[WHERE(roi_ids GT 0)]
  roifile = 'D:\test.roi'
  ENVI_SAVE_ROIS, roifile, roiid
  OBJ_DESTROY,oshp
  ENVI_FILE_MNG,id=fid,/REMOVE
  ENVI_DELETE_ROIS,roiid,/ALL
  
  backup_color = backup_color[uniq(backup_color)]
  ncolor = N_ELEMENTS(backup_color)
  roi_colors1 = BYTARR(3,ncolor)
  for kkk = 0,ncolor-1 do begin
    roi_colors1[*,kkk] = STRSPLIT(backup_color[kkk],',',/EXTRACT)    
  endfor
  
  ENVI_OPEN_FILE,InputFilename,r_fid=fid
  ENVI_FILE_QUERY,fid,nb=nb,ns=ns,nl=nl,dims=dims
  pos = LINDGEN(nb)
  ENVI_RESTORE_ROIS, roifile
  roi_ids = ENVI_GET_ROI_IDS(fid=fid, $
    roi_colors=roi_colors, roi_names=class_names)
  class_names = ['Unclassified', class_names]
  num_classes = N_ELEMENTS(roi_ids)
  ; Set the unclassified class to black and use roi colors
  lookup = BYTARR(3,num_classes+1)
  lookup[0,1] = roi_colors1
  ; 计算类ROI的基本统计信息
  ;
  mean = FLTARR(N_ELEMENTS(pos), num_classes)
  stdv = FLTARR(N_ELEMENTS(pos), num_classes)
  cov = FLTARR(N_ELEMENTS(pos),N_ELEMENTS(pos),num_classes)
  FOR j=0, num_classes-1 DO BEGIN
    ;
    roi_dims=[ENVI_GET_ROI_DIMS_PTR(roi_ids[j]),0,0,0,0]
    ENVI_DOIT, 'envi_stats_doit', fid=fid, pos=pos, $
      dims=roi_dims, comp_flag=4, mean=c_mean, $
      stdv=c_stdv, cov=c_cov
    MEAN[0,j] = c_mean
    stdv[0,j] = c_stdv
    cov[0,0,j] = c_cov
  ENDFOR
  ;
  ;thresh=REPLICATE(0.05,num_classes)

  out_bname = 'MaximumLikelihood'
  ENVI_DOIT, 'class_doit', fid=fid, pos=pos, dims=dims, $
    out_bname=out_bname, out_name=OutFileName, method=2, $
    mean=mean, stdv=stdv, std_mult=st_mult, $
    lookup=lookup, class_names=class_names, $
    cov = cov
END