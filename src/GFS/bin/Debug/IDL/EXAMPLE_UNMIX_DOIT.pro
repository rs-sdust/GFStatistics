PRO EXAMPLE_UNMIX_DOIT

  compile_opt IDL2

  ; First restore all the base save files.

  envi, /restore_base_save_files



  ; Initialize ENVI Classic and send all errors

  ; and warnings to the file batch.txt

  envi_batch_init, log_file='batch.txt'



  ; Open the input file

  envi_open_file, 'G:\hyperion\stack.tif', r_fid=fid

  if (fid eq -1) then begin

    envi_batch_exit

    return

  endif



  ; Set the POS keyword to process all

  ; spectral data. Output the result

  ; to disk.

  envi_file_query, fid, dims=dims, nb=nb

  pos = lindgen(nb)

  out_name = 'G:\hyperion\test.tif'



  ; Read in the endmember text file.

  ; The first column are the

  ; wavelengths and the next 19

  ; columns are the endmembers. We will

  ; use the 19 endmembers for unmixing.

  ; The endmember data must also be

  ; transposed in order to send in

  ; a (nb, # endmember) array.

  envi_read_cols, 'D:\svm.roi', $

    endmem, skip=em_names, /read_skip

  endmem = transpose(endmem[1:*,*])

  out_bname = ['Unmix EM:' + $

    em_names[2:*], 'RMS Error']



  ; Call the Unmixing processing

  ; routine.

  envi_doit,'unmix_doit', $

    fid=fid, pos=pos, dims=dims, $

    endmem=endmem, out_name=out_name, $

    out_bname=out_bname, $

    in_memory=0, r_fid=r_fid

END