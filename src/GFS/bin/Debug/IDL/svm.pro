;pro svmtest
;    COMPILE_OPT IDL2
;    ENVI, /RESTORE_BASE_SAVE_FILES
;    ENVI_BATCH_INIT
;    svm,'G:\影像7实验\GF3SVMTest\131546715126197153.tif','G:\影像7实验\GF3SVMTest\YYK.tif','G:\影像7实验\GF3SVMTest\20171113024000.shp','G:\影像7实验\GF3SVMTest\yyk2.tif'
;end


;********************************************************************************
; svm.pro
;
; 作者： 闫现强
;
; 创建时间：20160617
;
; 描述：svm分类
;
; 参数说明：
;
; inputfile       输入影像
; outputfile      输出分类影像
; roifile         几何校正所需的控制点文件
; rulefile        输出的后验概率影像
; thresh          指定像元分类的最小概率，所有类的概率小于这个阈值的像素将不会被分类。默认值0.5
; penalty         指定要使用的支持向量机分类的惩罚参数。这个参数控制了样本错误与分类刚性延伸之间的平衡， 默认值是75。
; kernel_type     指定要使用的支持向量机分类的内核类型。可选 0：linear。1：polynomial。2：径向基函数（rbf）。3：sigmoid
; kernel_degree   如果选择polynomial，设置一个核心多项式的次数用于svm，最小值是1，最大值是6，默认值是3。
; kernel_bias     如果选择polynomial 或 sigmoid，使用向量机规则需要为kernel指定 the bias ，默认值是1
;
; 调用示例：
;
;   executestring（"svm,'c:\infile.tif','c:\outfile.tif','c:\test.roi','c:\rule.tif'"）
;
; 修改记录：
;
;*********************************************************************************/
pro svm,inputfile,outputfile,roifile,rulefile,$
  thresh=thresh, $
  penalty=penalty, kernel_type= kernel_type, $
  kernel_degree=kernel_degree, kernel_bias=kernel_bias

  compile_opt idl2

  envi,/restore_base_save_files
  envi_batch_init

  ;打开文件
  envi_open_file, inputfile, r_fid=fid
  if (fid eq -1) then begin
    return
  endif
  ;获取文件信息
  envi_file_query, fid, dims=dims, nb=nb,nl=nl,ns=ns
  pos  = lindgen(nb)
  out_name = outputfile
  ;参数设置
  if ~keyword_set(thresh) then thresh = .5
  if ~keyword_set(penalty) then penalty=75
  if ~keyword_set(kernel_type) then kernel_type=1
  if ~keyword_set(kernel_degree) then kernel_degree=3
  if ~keyword_set(kernel_bias) then kernel_bias = 2.

  ;roi文件
  oshp=OBJ_NEW('IDLffShape',roifile)
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
  roifile = 'D:\svm.roi'
  ENVI_SAVE_ROIS, roifile, roiid
  OBJ_DESTROY,oshp
  ENVI_DELETE_ROIS,roiid,/ALL

  envi_restore_rois, roifile
  roi_ids = envi_get_roi_ids(fid=fid)
  ;调用svm分类
  envi_doit, 'envi_svm_doit', $
    fid=fid, pos=pos, dims=dims, $
    out_name=out_name, $
    roi_ids=roi_ids, thresh=thresh, $
    penalty=penalty, kernel_type= kernel_type, $
    kernel_degree=kernel_degree, kernel_bias=kernel_bias, $
    rule_out_name = rulefile
end