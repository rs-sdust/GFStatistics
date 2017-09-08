PRO NEURAL_NET_CLASSIFICATION
  COMPILE_OPT idl2
  envi,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  InputFilename = ''
  ExampleShpFile = ''
  OutFileName = ''
  
  ;the training threshold contribution,between 0.0 and 1.0
  theta = 0.9
  ;the training rate,between 0.0 and 1.0
  eta = 0.2
  ;the training momentum,between 0.0 and 1.0
  alpha = 0.9
  ;the activation function,0: Logistic,1: Hyperbolic
  act_type = 0
  ;the RMS training error criteria
  rms_crit = 0.1
  ;the number of hidden layers,Typically[0,1 or 2]
  num_layers = 2
  ;the maximum number of training sweeps
  num_sweeps = 20
  ;an minimum activation threshold
  THRESH = 0.4
  
  Neural_Net_Classification_Function,InputFilename,ExampleShpFile,theta,eta,alpha,act_type,rms_crit,num_layers,num_sweeps,THRESH,OutFileName
END
;+
; :DESCRIPTION:
;    Describe the procedure.
;  利用神经网络实现面向对象的分类
; :PARAMS:
;    InputFilename：待分类影像
;    ExampleShpFile：样本点Shp文件
;       Shp文件属性表格式：FID   Shape    CLASS_NAME CLASS_ID   CLASS_CLRS
;                    属性：           Geometry  String(40) String(10) String(12)
;                    值：                Polygon   City(Road) 1(2,3,4,5) 1(2,3,4,5)
;    theta：the training threshold contribution,between 0.0 and 1.0
;    eta：the training rate,between 0.0 and 1.0
;    alpha：the training momentum,between 0.0 and 1.0
;    act_type:the activation function,0: Logistic,1: Hyperbolic
;    rms_crit:the RMS training error criteria
;    num_layers:the number of hidden layers,Typically[0,1 or 2]
;    num_sweeps:the maximum number of training sweeps
;    THRESH:an minimum activation threshold
;    OutFileName:分类结果绝对路径
;
; :AUTHOR: Yikun Yang
;-
pro Neural_Net_Classification_Function,InputFilename,ExampleShpFile,theta,eta,alpha,act_type,rms_crit,num_layers,num_sweeps,THRESH,OutFileName
  compile_opt idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ENVI_OPEN_FILE,InputFilename,r_fid=fid
  ENVI_FILE_QUERY,fid,nl=nl,ns=ns,nb=nb,dims=dims  
  oshp=OBJ_NEW('IDLffShape',ExampleShpFile)
  oshp->getproperty,n_entities=n_ent,Attribute_info=attr_info,n_attributes=n_attr,Entity_type=ent_type,ATTRIBUTE_NAMES=ATTRIBUTE_NAME  
  ;ROI
  ROI_IDS = LONARR(n_ent)
  color = STRARR(n_ent)
  temp_roi_id = 0
  for j = 0,n_ent-1 do begin
    ent1=oshp->GetAttributes(j)
    ent2=oshp->getentity(j)
    vert=*(ent2.vertices)
    ENVI_CONVERT_FILE_COORDINATES,fid,XPTS,YPTS,vert[0,*],vert[1,*]
    ROI_NAME = ent1.ATTRIBUTE_0
    color[j] = ent1.ATTRIBUTE_1
    if j eq 0 then begin
      ROI_IDS[J] = ENVI_CREATE_ROI(color=color[j], name=ROI_NAME,nl=nl,ns=ns)
      num = N_ELEMENTS(XPTS)
      XPTS = REFORM(XPTS,num)
      YPTS = REFORM(YPTS,num)
      ENVI_DEFINE_ROI, ROI_IDS[J] , /POLYGON, XPTS=XPTS, YPTS=YPTS
      oshp->DESTROYENTITY, ent2
      temp_roi_id = ROI_IDS[J]
    endif else begin
      if color[j] eq color[j-1] then begin
        num = N_ELEMENTS(XPTS)
        XPTS = REFORM(XPTS,num)
        YPTS = REFORM(YPTS,num)
        ENVI_DEFINE_ROI, temp_roi_id , /POLYGON, XPTS=XPTS, YPTS=YPTS,/NO_UPDATE
        oshp->DESTROYENTITY, ent2
      endif else begin
        ROI_IDS[J] = ENVI_CREATE_ROI(color=color[j], name=ROI_NAME,nl=nl,ns=ns)
        num = N_ELEMENTS(XPTS)
        XPTS = REFORM(XPTS,num)
        YPTS = REFORM(YPTS,num)
        ENVI_DEFINE_ROI, ROI_IDS[J] , /POLYGON, XPTS=XPTS, YPTS=YPTS
        oshp->DESTROYENTITY, ent2
        temp_roi_id = ROI_IDS[J]
      endelse
    endelse    
  endfor
  roiid = roi_ids[where(roi_ids gt 0)]
  roifile = 'D:\test1.roi'
  envi_save_rois, roifile, roiid
  Obj_destroy,oshp
  ENVI_FILE_MNG,id=fid,/REMOVE
  ENVI_DELETE_ROIS,roiid,/ALL
  
  ENVI_OPEN_FILE,InputFilename,r_fid=fid
  ENVI_FILE_QUERY,fid,nb=nb,ns=ns,nl=nl,dims=dims
  IF ~KEYWORD_SET(theta) THEN theta = .9
  IF ~KEYWORD_SET(eta) THEN eta = .2
  IF ~KEYWORD_SET(alpha) THEN alpha = .9
  IF ~KEYWORD_SET(act_type) THEN act_type = 0
  IF ~KEYWORD_SET(rms_crit) THEN rms_crit = .1
  IF ~KEYWORD_SET(num_layers) THEN num_layers = 2
  IF ~KEYWORD_SET(num_sweeps) THEN num_sweeps = 20
  IF ~KEYWORD_SET(THRESH) THEN THRESH = 0.4
  ENVI_RESTORE_ROIS, roifile
  roi_ids = ENVI_GET_ROI_IDS(fid=fid,ROI_COLORS=lookup,ROI_NAMES=ROI_NAMES)
  ;Settheclassificationvariables;
  num_classes=N_ELEMENTS(roi_ids)
  class_names=['Unclassified',ROI_NAMES]
  lookup=REFORM([0,0,0,REFORM(lookup,3*num_classes)],3,num_classes+1)
  pos = LINDGEN(nb)
  ENVI_DOIT, 'envi_neural_net_doit', fid=fid,pos=pos,dims=dims,$
    out_name=OutFileName,rule_out_name = '', theta=theta,eta=eta,alpha=alpha,$
    num_classes=num_classes, num_sweeps=num_sweeps, num_layers=num_layers,act_type=act_type,$
    rms_crit=rms_crit, roi_ids=roi_ids,/train, class_names=class_names,lookup=lookup,$
    THRESH = THRESH
end