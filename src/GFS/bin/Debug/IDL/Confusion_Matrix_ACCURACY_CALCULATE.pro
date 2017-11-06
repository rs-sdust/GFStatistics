;
;PRO Confusion_Matrix_ACCURACY_CALCULATE
;  COMPILE_OPT idl2
;  ENVI,/RESTORE_BASE_SAVE_FILES
;  ENVI_BATCH_INIT
;  ShpFile = "G:\temp\20170905042524.shp"
;  ClassFile = "G:\temp\oobp.tif"
;  OutFileName= "G:\temp\test.txt"
;  Confusion_Matrix_Calcute,ShpFile,ClassFile,OutFileName
;
;  
;  a=1;
;end
PRO Confusion_Matrix_Calcute,ShpFile,ClassFile,OutFileName
  COMPILE_OPT idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ENVI_OPEN_FILE,ClassFile,r_fid=fid
  ENVI_FILE_QUERY,fid,nl=nl,ns=ns,nb=nb,dims=dims,CLASS_NAMES=Raw_CLASS_NAMES,LOOKUP=Raw_LOOKUP
  oshp=OBJ_NEW('IDLffShape',ShpFile)
  oshp->getproperty,n_entities=n_ent,Attribute_info=attr_info,n_attributes=n_attr,Entity_type=ent_type,ATTRIBUTE_NAMES=ATTRIBUTE_NAME  
  ;ROI
  ROI_IDS = LONARR(n_ent)
  color = STRARR(n_ent)
  name_memory = STRARR(n_ent)
  temp_roi_id = 0
  for j = 0,n_ent-1 do begin
    ent1=oshp->GetAttributes(j)
    ent2=oshp->getentity(j)
    vert=*(ent2.vertices)
    ENVI_CONVERT_FILE_COORDINATES,fid,XPTS,YPTS,vert[0,*],vert[1,*]
    ROI_NAME = ent1.ATTRIBUTE_0
    index = where((strpos(Raw_CLASS_NAMES,ent1.ATTRIBUTE_0)+1) eq 1 )
    color[j] = ent1.ATTRIBUTE_1
    
    name_memory[j] = ent1.ATTRIBUTE_0
    
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
  roifile = 'd:\Accuracy.roi'
  envi_save_rois, roifile, roiid
  Obj_destroy,oshp
  ENVI_DELETE_ROIS,roiid,/ALL
  
  ENVI_RESTORE_ROIS, roifile
  roi_ids = ENVI_GET_ROI_IDS(fid=fid,ROI_COLORS=lookup,ROI_NAMES=ROI_NAMES)
  pos = [0]
  
  name_memory = name_memory[uniq(name_memory)]
  class_ptr = LINDGEN(N_ELEMENTS(roi_ids))
  for kk=0,N_ELEMENTS(roi_ids)-1 do begin
    index = where((strpos(Raw_CLASS_NAMES,name_memory[kk]))+1 eq 1)
    class_ptr[kk] = index
  endfor
  
  ENVI_DOIT, 'class_confusion_doit', $
    cfid=fid, cpos=pos, dims=dims, $
    roi_ids=roi_ids, class_ptr=class_ptr, $
    /rpt_commission, to_screen=0, $
    calc_percent=0, commission=commission, $
    omission=omission, matrix=matrix, $
    kappa_coeff=kappa_coeff, accuracy=accuracy
  A11=1
  openw,lunw,OutFileName,/GET_LUN,WIDTH=2000
  NN = N_ELEMENTS(roi_ids)
  tempformat1 = ',a12'
  tempformat2 = 'f6.2,'
  Format1 = '(a12'
  FOR I=0,NN+1 do begin
    Format1 = Format1+tempformat1
  ENDFOR
  Format1 = Format1+')'
  column = NN+3
  lines = NN+6
  out = strarr(column)
  out[1] = '解译结果'
  printf,lunw,out,format = Format1
  out = strarr(column)
  out[2:column-2] = name_memory[*]
  out[column-1] = '生产者精度'
  printf,lunw,out,format = Format1
  out = MAKE_ARRAY(column,NN+1,value = ' ')
  out[0,0] = '分类结果'
  out[1,NN] = '用户精度'
  for kk=0,NN-1 do begin
    out[1,kk] = name_memory[kk]
  endfor
  out[2:column-2,0:NN-1] = long(matrix[0:NN-1,1:NN])
  for ii = 0,NN-1 do begin
    TAMP = STRCOMPRESS(STRING(FLOAT(float(out[ii+2,ii])/total(float(out[ii+2,0:NN-1]))*100.0)),/REMOVE_ALL)
    out[2+ii,NN] = STRMID(TAMP,0,5)
    if(total(float(out[ii+2,0:NN-2])) eq 0) then begin
      out[2+ii,NN] = 0.0
    endif
  endfor
  FOR ii = 0,NN-1 DO BEGIN
    tamp = STRCOMPRESS(STRING(FLOAT(out[2+II,ii])/TOTAL(FLOAT(out[2:NN+1,ii]))*100.0),/REMOVE_ALL)
    out[2+NN,II] = STRMID(TAMP,0,5)
    IF(TOTAL(FLOAT(out[2:NN,ii])) EQ 0) THEN BEGIN
      out[2+NN,II] = 0.0
    ENDIF
  ENDFOR
  tempformat2 = ',a12'
  Format1 = '(a12,a12'
  FOR I=0,NN-1 do begin
    Format1 = Format1+tempformat2
  ENDFOR
  Format1 = Format1+',f12.2)'
  for ii=0,NN-1 DO BEGIN
    printf,lunw,(string(out[*,ii],format = Format1)+ '%')
  ENDFOR
  
  outAA = STRARR(NN+2)
  format = '(a12)'
  FOR II =0,1 DO BEGIN
    outAA[II] = (string(out[II,NN],format = format))
  ENDFOR
  format = '(f10.2)'  
  for ii=0,NN-1 do begin
    outAA[II+2] = (string(out[II+2,NN],format = format) + '%')
  endfor
  printf,lunw,outAA
  printf,lunw,' '
 
  out = strarr(2,2)
  format = '(A12)'
  FORMAT1 = '(F12.2)'
  out[0,0] = STRING('总体精度',FORMAT = format)
  out[1,0] = STRING(accuracy,FORMAT = format1)+'%'
  out[0,1] = STRING('Kappa系数',FORMAT = format)
  out[1,1] = STRING(kappa_coeff*100.0,FORMAT = format1)+'%'
  
  printf,lunw,out
  free_lun,lunw
END