;pro svmtest
;    COMPILE_OPT IDL2
;    ENVI, /RESTORE_BASE_SAVE_FILES
;    ENVI_BATCH_INIT
;    svm,'G:\Ӱ��7ʵ��\GF3SVMTest\131546715126197153.tif','G:\Ӱ��7ʵ��\GF3SVMTest\YYK.tif','G:\Ӱ��7ʵ��\GF3SVMTest\20171113024000.shp','G:\Ӱ��7ʵ��\GF3SVMTest\yyk2.tif'
;end


;********************************************************************************
; svm.pro
;
; ���ߣ� ����ǿ
;
; ����ʱ�䣺20160617
;
; ������svm����
;
; ����˵����
;
; inputfile       ����Ӱ��
; outputfile      �������Ӱ��
; roifile         ����У������Ŀ��Ƶ��ļ�
; rulefile        ����ĺ������Ӱ��
; thresh          ָ����Ԫ�������С���ʣ�������ĸ���С�������ֵ�����ؽ����ᱻ���ࡣĬ��ֵ0.5
; penalty         ָ��Ҫʹ�õ�֧������������ĳͷ����������������������������������������֮���ƽ�⣬ Ĭ��ֵ��75��
; kernel_type     ָ��Ҫʹ�õ�֧��������������ں����͡���ѡ 0��linear��1��polynomial��2�������������rbf����3��sigmoid
; kernel_degree   ���ѡ��polynomial������һ�����Ķ���ʽ�Ĵ�������svm����Сֵ��1�����ֵ��6��Ĭ��ֵ��3��
; kernel_bias     ���ѡ��polynomial �� sigmoid��ʹ��������������ҪΪkernelָ�� the bias ��Ĭ��ֵ��1
;
; ����ʾ����
;
;   executestring��"svm,'c:\infile.tif','c:\outfile.tif','c:\test.roi','c:\rule.tif'"��
;
; �޸ļ�¼��
;
;*********************************************************************************/
pro svm,inputfile,outputfile,roifile,rulefile,$
  thresh=thresh, $
  penalty=penalty, kernel_type= kernel_type, $
  kernel_degree=kernel_degree, kernel_bias=kernel_bias

  compile_opt idl2

  envi,/restore_base_save_files
  envi_batch_init

  ;���ļ�
  envi_open_file, inputfile, r_fid=fid
  if (fid eq -1) then begin
    return
  endif
  ;��ȡ�ļ���Ϣ
  envi_file_query, fid, dims=dims, nb=nb,nl=nl,ns=ns
  pos  = lindgen(nb)
  out_name = outputfile
  ;��������
  if ~keyword_set(thresh) then thresh = .5
  if ~keyword_set(penalty) then penalty=75
  if ~keyword_set(kernel_type) then kernel_type=1
  if ~keyword_set(kernel_degree) then kernel_degree=3
  if ~keyword_set(kernel_bias) then kernel_bias = 2.

  ;roi�ļ�
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
  ;����svm����
  envi_doit, 'envi_svm_doit', $
    fid=fid, pos=pos, dims=dims, $
    out_name=out_name, $
    roi_ids=roi_ids, thresh=thresh, $
    penalty=penalty, kernel_type= kernel_type, $
    kernel_degree=kernel_degree, kernel_bias=kernel_bias, $
    rule_out_name = rulefile
end