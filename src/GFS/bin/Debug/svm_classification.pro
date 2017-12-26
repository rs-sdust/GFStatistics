pro svm_classification, image_path, shp_path, savepath

;=======================================================
;�����ܣ�ʵ��svm�Ǽල����
;�����ˣ�����Ȩ
;��  �ڣ�2013��7��28��
;��Ȩ���У�
;Email:liexuewuwei@163.com
;=======================================================

compile_opt idl2
envi, /restore_Base_save_files
envi_batch_init, /NO_STATUS_WINDOW

;-------------------------------------------------------
;����
;1����������
;image_path=envi_pickfile(title='pick the data')
if (image_path eq '') then return

envi_open_file, image_path, r_fid=fid
envi_file_query, fid, dims=dims, ns=ns, nl=nl, nb=nb

pos  = lindgen(nb)

;shp_path = envi_pickfile(title='pick the shp data')
if (shp_path eq '') then return

;2�����
;savepath=dialog_pickfile(title='ѡ�����·��', /write, /OVERWRITE_PROMPT)
if (savepath eq '') then return

;��shpת��ROI
myshape = OBJ_NEW('IDLffShape',shp_path)

;-----------------------------------------------------------------------------------------------------------
;��ȡshp����
myshape->GetProperty, n_entities=n_ent,Attribute_info=attr_info,n_attributes=n_attr,Entity_type=ent_type

;-----------------------------------------------------------------------------------------------------------
;����shp���Խ���ROI

;ͳ���ж�����
class_name = strarr(n_ent)
For i=0,n_ent-1 Do Begin

attr = myshape->GetAttributes(i)
class_name[i] = attr.(0)

endfor

For i=0,n_ent-1 Do Begin

data=where(strcmp(class_name,class_name[i]),num)
if num gt 1 then class_name[data[1:num-1]] = ''

endfor

class=where(strcmp(class_name,''),complement=class_index, ncomplement=class_num)
class_name=class_name[class_index]

;����ROI
roi_id = intarr(class_num)
For i=0,class_num-1 Do Begin

roi_id[i] = envi_create_roi(color=i+2, name = class_name[i], ns=ns, nl=nl)

endfor

;��ROI��Ӷ���
FOR i=0, (n_ent-1) DO BEGIN

ent = myshape->GetEntity(i)
attr=myshape->GetAttributes(i)

xmap=(*ent.vertices)[0, *]
ymap =(*ent.vertices)[1, *]

;get the file coordinates
envi_convert_file_coordinates, fid, xf, yf, xmap, ymap

;Clean-up of pointers
myshape->DestroyEntity, ent

xpts=transpose(xf)
ypts=transpose(yf)

for j=0,class_num-1 Do Begin

if strcmp(attr.(0),class_name[j]) then envi_define_roi, roi_id[j], /POLYGON, xpts= xpts, ypts=ypts

endfor

ENDFOR

; Close the Shapefile.
OBJ_DESTROY, myshape

ENVI_GET_ROI_INFORMATION, roi_id, ns=ns, nl=nl, NPTS = NPTS, ROI_NAMES = ROI_NAMES, ROI_COLORS = ROI_COLORS

class_names = ['Unclassified', ROI_NAMES]
num_classes = n_elements(roi_id)
lookup = bytarr(3, num_classes + 1)
lookup = bytarr(3,num_classes+1)
lookup[0,1] = roi_colors
;CLASS_NAMES = ROI_NAMES
;LOOKUP = ROI_COLORS
out_name = savepath
NPTS = NPTS

  envi_doit, 'envi_svm_doit', $
    fid=fid, pos=pos, dims=dims, $
    out_name=out_name, $
    roi_ids=roi_id

;envi_batch_exit, /NO_CONFIRM, /EXIT_IDL

end