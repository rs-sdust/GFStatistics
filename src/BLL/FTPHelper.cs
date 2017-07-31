using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HDBM.UI
{
    /// <summary>
    /// 复制数管系统中的FTPHelper类
    /// </summary>
    public class FTPHelper
    {
        string ftpUserID;
        string ftpPassword;

        public string FTPServerIP { get; set; }
        /// <summary>
        /// 主动模式是当进行文件下载时远程主机连接到本地主机的某端口进行数据发送，适用于本机网络端口开放较多。
        /// 被动模式是当进行文件下载时本机主机连接到远程主机的某端口进行数据发送，适用于对端网络端口开放较多。
        /// </summary>
        bool usePassive = true;
        FtpWebRequest reqFTP;
        /// <summary>
        /// ftp登录信息
        /// </summary>
        /// <param name="ftpServerIP">ftpServerIP(例：221.1.217.92)</param>
        /// <param name="ftpUserID">ftpUserID</param>
        /// <param name="ftpPassword">ftpPassword</param>
        public FTPHelper(string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            this.FTPServerIP = ftpServerIP;
            this.ftpUserID = ftpUserID;
            this.ftpPassword = ftpPassword;
        }
        public FTPHelper(string ftpServerIP, string ftpUserID, string ftpPassword, bool usePassive)
        {
            this.FTPServerIP = ftpServerIP;
            this.ftpUserID = ftpUserID;
            this.ftpPassword = ftpPassword;
            this.usePassive = usePassive;
        }

        #region 连接
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="path"></param>
        private void Connect(String path)//连接ftp
        {
            // 根据uri创建FtpWebRequest对象
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));
            // 指定数据传输类型
            reqFTP.UseBinary = true;
            reqFTP.UsePassive = usePassive;
            // ftp用户名和密码
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

        }
        #endregion

        #region 获取文件列表
        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="path">eg:a/b/</param>
        /// <param name="WRMethods"></param>
        /// <param name="ResponseEncoding">编码方式</param>
        /// <returns></returns>
        private string[] GetFileList(string path, string WRMethods, System.Text.Encoding ResponseEncoding)//上面的代码示例了如何从ftp服务器上获得文件列表
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            try
            {
                Connect(path);
                reqFTP.Method = WRMethods;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), ResponseEncoding);//中文文件名
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {

                downloadFiles = null;
                return downloadFiles;
            }
        }
        public string[] GetFileList(string path, System.Text.Encoding ResponseEncoding)
        {
            if (path.Contains("ftp") == false)
            {
                return GetFileList("ftp://" + FTPServerIP + "/" + path, WebRequestMethods.Ftp.ListDirectory, ResponseEncoding);
            }
            else
            {
                return GetFileList(path, WebRequestMethods.Ftp.ListDirectory, ResponseEncoding);
            }
        }

        public string[] GetFileList(string path)
        {
            return GetFileList("ftp://" + FTPServerIP + "/" + path, System.Text.Encoding.GetEncoding("UTF-8"));
        }
        public string[] GetFileList()//上面的代码示例了如何从ftp服务器上获得文件列表
        {
            return GetFileList("");
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filename">本地文件名</param>
        /// <param name="path">ftp路径</param>
        /// <param name="errorinfo"></param>
        public bool Upload(string localFullName, string remoteFilePath, string remoteFileName) //上面的代码实现了从ftp服务器上载文件的功能
        {
            long tranferSize = 0;
            int transferPercent = 0;
            FileInfo fileInf = new FileInfo(localFullName);
            string urlpath = "ftp://" + FTPServerIP + "/" + remoteFilePath + "/";
            string uri = "ftp://" + FTPServerIP + "/" + remoteFilePath + "/" + remoteFileName;
            DeleteFileName(fileInf.Name);
            Connect(uri);//连接         
            // 默认为true，连接不会被关闭
            // 在一个命令之后被执行
            reqFTP.KeepAlive = false;
            // 指定执行什么命令
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // 上传文件时通知服务器文件的大小
            reqFTP.ContentLength = fileInf.Length;
            // 缓冲大小设置为kb 
            int buffLength = 4096;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // 打开一个文件流(System.IO.FileStream) 去读上传的文件
            FileStream fs = fileInf.OpenRead();
            try
            {
                // 把上传的文件写入流
                Stream strm = reqFTP.GetRequestStream();
                // 每次读文件流的kb
                contentLen = fs.Read(buff, 0, buffLength);
                // 流内容没有结束
                while (contentLen != 0)
                {
                    tranferSize += contentLen;
                    // 把内容从file stream 写入upload stream 
                    strm.Write(buff, 0, contentLen);
                    transferPercent = (int)(tranferSize * 100 / fileInf.Length);
                    if (UpLoading != null)
                    {
                        UpLoading(this, new FileTransferEventArgs(localFullName, tranferSize, transferPercent, urlpath));
                        //MessageBox.Show("HELP" + localFullName + tranferSize.ToString()+"%"+transferPercent.ToString());
                    }
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // 关闭两个流
                strm.Close();
                fs.Close();
                if (UpLoaded != null)
                {
                    UpLoaded(this, new FileTransferEventArgs(localFullName, tranferSize, transferPercent, urlpath));
                    //MessageBox.Show("HELP" + localFullName + tranferSize.ToString()+"%"+transferPercent.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region 下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="ftpfilepath">Ftp文件路径:例："221.1.217.92/20100510.txt"</param>
        /// <param name="filePath">本地目录"c:\"</param>
        /// <param name="fileName">本地文件"1.txt"</param>
        /// <param name="errorinfo"></param>
        /// <returns></returns>
        public void Download(string ftpFullPath, string localFilePath, string localFileName)////上面的代码实现了从ftp服务器下载文件的功能
        {
            long transferSize = 0L;
            int transferPercent = 0;
            string localFullPath = null;
            if (localFilePath.EndsWith("\\"))
            {
                localFilePath = localFilePath.TrimEnd('\\');
            }

            if (localFileName == null)
            {
                string filename = ftpFullPath.Substring(ftpFullPath.LastIndexOf('/') + 1);
                localFullPath = localFilePath + "\\" + filename;
            }
            else
            {
                localFullPath = localFilePath + "\\" + localFileName;
            }
            Connect(ftpFullPath);//连接 
            reqFTP.KeepAlive = false;
            // 指定执行什么命令
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            FileStream outputStream = new FileStream(localFullPath, FileMode.Create);
            long cl = response.ContentLength;
            int bufferSize = 2048;
            int readCount;
            byte[] buffer = new byte[bufferSize];
            readCount = ftpStream.Read(buffer, 0, bufferSize);

            while (readCount > 0)
            {
                transferSize += readCount;
                outputStream.Write(buffer, 0, readCount);
                transferPercent = (int)(transferSize * 100 / cl);
                if (DownLoading != null)
                {
                    DownLoading(this, new FileTransferEventArgs(localFullPath, transferSize, transferPercent, ftpFullPath));
                }
                readCount = ftpStream.Read(buffer, 0, bufferSize);
            }
            ftpStream.Close();
            outputStream.Close();
            response.Close();
            if (DownLoaded != null)
            {
                DownLoaded(this, new FileTransferEventArgs(localFullPath, transferSize, 100, ftpFullPath));
            }

        }
        #endregion
        #region 续传文件
        /// <summary>
        /// 续传文件
        /// </summary>
        /// <param name="filename"></param>
        public bool Upload(string filename, long size, string path, out string errorinfo) //上面的代码实现了从ftp服务器上载文件的功能
        {
            long tranferSize = size;
            int transferPercent = 0;
            //path = path.Replace("\\", "/");
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + FTPServerIP + "/" + path + "/" + fileInf.Name;
            // string uri = "ftp://" + path;
            Connect(uri);//连接         
            // 默认为true，连接不会被关闭
            // 在一个命令之后被执行
            reqFTP.KeepAlive = false;
            // 指定执行什么命令         
            reqFTP.Method = WebRequestMethods.Ftp.AppendFile;
            // 上传文件时通知服务器文件的大小
            reqFTP.ContentLength = fileInf.Length;
            // 缓冲大小设置为kb 
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // 打开一个文件流(System.IO.FileStream) 去读上传的文件
            FileStream fs = fileInf.OpenRead();
            try
            {
                StreamReader dsad = new StreamReader(fs);
                fs.Seek(size, SeekOrigin.Begin);
                // 把上传的文件写入流
                Stream strm = reqFTP.GetRequestStream();
                // 每次读文件流的kb
                contentLen = fs.Read(buff, 0, buffLength);
                // 流内容没有结束
                while (contentLen != 0)
                {
                    tranferSize += contentLen;
                    // 把内容从file stream 写入upload stream 
                    strm.Write(buff, 0, contentLen);
                    transferPercent = (int)(tranferSize * 100 / fileInf.Length);

                    if (UpLoading != null)
                    {
                        UpLoading(this, new FileTransferEventArgs(filename, tranferSize, transferPercent, uri));
                    }
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // 关闭两个流
                if (UpLoaded != null)
                {
                    UpLoaded(this, new FileTransferEventArgs(filename, tranferSize, transferPercent, uri));
                }
                strm.Close();
                fs.Close();
                errorinfo = "完成";
                return true;
            }
            catch (Exception ex)
            {
                errorinfo = string.Format("因{0},无法完成上传", ex.Message);
                return false;
            }
        }
        #endregion



        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFileName(string fileName)
        {
            try
            {
                FileInfo fileInf = new FileInfo(fileName);
                string uri = "ftp://" + FTPServerIP + "/" + fileInf.Name;
                Connect(uri);//连接         
                // 默认为true，连接不会被关闭
                // 在一个命令之后被执行
                reqFTP.KeepAlive = false;
                // 指定执行什么命令
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "删除错误");
            }
        }
        public void DeleteFile(string fileName)
        {
            try
            {
                string uri = "ftp://" + FTPServerIP + "/" + fileName;
                Connect(uri);//连接         
                // 默认为true，连接不会被关闭
                // 在一个命令之后被执行
                reqFTP.KeepAlive = false;
                // 指定执行什么命令
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "删除错误");
            }
        }
        #endregion

        #region 在ftp上创建目录
        /// <summary>
        /// 在ftp上创建目录
        /// </summary>
        /// <param name="dirName"></param>
        public bool MakeDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + FTPServerIP + "/" + dirName;
                Connect(uri);//连接      
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region 删除ftp上目录
        /// <summary>
        /// 删除ftp上目录
        /// </summary>
        /// <param name="dirName"></param>
        public void delDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + FTPServerIP + "/" + dirName;
                Connect(uri);//连接      
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 获得ftp上文件大小
        /// <summary>
        /// 获得ftp上文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public long GetFileSize(string filename)
        {
            long fileSize = 0;
            try
            {
                // FileInfo fileInf = new FileInfo(filename);
                //string uri1 = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                // string uri = filename;

                Connect(filename);//连接      
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                fileSize = response.ContentLength;
                response.Close();
            }
            catch (Exception ex)
            {
                fileSize = 0;
            }
            return fileSize;
        }
        #endregion

        #region ftp上文件改名
        /// <summary>
        /// ftp上文件改名
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void Rename(string currentFilename, string newFilename)
        {
            try
            {
                FileInfo fileInf = new FileInfo(currentFilename);
                string uri = "ftp://" + FTPServerIP + "/" + fileInf.Name;
                Connect(uri);//连接
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                //Stream ftpStream = response.GetResponseStream();
                //ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 是否文件夹
        public bool IsDirectory(string path, string dirname)
        {
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path + "/" + dirname));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            WebResponse resFtp = reqFTP.GetResponse();

            StreamReader reader = new StreamReader(resFtp.GetResponseStream(), Encoding.UTF8);
            StringBuilder result = new StringBuilder();
            string line = reader.ReadLine();
            while (line != null)
            {
                result.Append(line);
                result.Append("\n");
                line = reader.ReadLine();
            }                // to remove the trailing '\n'
            string[] dirs = result.ToString().TrimEnd('\n').Split('\n');

            reader.Close();
            resFtp.Close();
            if (dirs.Length > 1)
                return true;
            else
                return false;
        }

        #endregion

        #region 获取所有文件和文件夹信息
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dirname"></param>
        /// <returns></returns>
        public List<string> GetDirDetais(string path, string dirname)
        {
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path + "/" + dirname));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            WebResponse resFtp = reqFTP.GetResponse();

            StreamReader reader = new StreamReader(resFtp.GetResponseStream(), Encoding.UTF8);
            StringBuilder result = new StringBuilder();
            string line = reader.ReadLine();
            while (line != null)
            {
                result.Append(line);
                result.Append("\n");
                line = reader.ReadLine();
            }                // to remove the trailing '\n'
            string[] dirs = result.ToString().Split('\n');
            List<string> contents = new List<string>();
            foreach (string name in dirs)
            {
                string detail = name.Split(' ')[name.Split(' ').Length - 1];
                if (detail == "" || detail == "." || detail == "..")
                    continue;
                contents.Add(detail);
            }

            reader.Close();
            resFtp.Close();
            return contents;
        }

        #endregion

        #region 获取文件下所有文件以及创建文件夹
        public void GetDownFiles(string remotepath, string remotedir, string localpath, ref Dictionary<string, string> files)
        {

            if (localpath.EndsWith("\\"))
            {
                localpath = localpath.TrimEnd('\\');
            }
            if (remotepath.EndsWith("/"))
            {
                remotepath.TrimEnd('/');
            }
            string folder = localpath + "\\" + remotedir;
            string path = remotepath + "/" + remotedir;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            List<string> dirs = GetDirDetais(remotepath, remotedir);
            if (dirs.Count > 0)
            {
                foreach (string dirname in dirs)
                {
                    if (IsDirectory(path, dirname))
                    {
                        GetDownFiles(path, dirname, folder, ref files);
                    }
                    else
                    {
                        files.Add(path + "/" + dirname, folder);
                    }
                }
            }
        }
        #endregion
        public event UpLoadedHandler UpLoaded;
        public event UpLoadingHandler UpLoading;
        public event DownLoadingHandler DownLoading;
        public event DownLoadedHandler DownLoaded;

    }

    public delegate void UpLoadingHandler(object sender, FileTransferEventArgs e);
    public delegate void UpLoadedHandler(object sender, FileTransferEventArgs e);
    public delegate void DownLoadingHandler(object sender, FileTransferEventArgs e);
    public delegate void DownLoadedHandler(object sender, FileTransferEventArgs e);
    public class FileTransferEventArgs : EventArgs
    {
        public long TransferSize { set; get; }
        /// <summary>
        /// 传输比例0-100
        /// </summary>
        public int TransferPercent { get; set; }

        public string LocalFullName { get; set; }
        public string urlPath { get; set; }
        public string UID { get; set; }
        public FileTransferEventArgs(string localName, long transferSize, int transferPercent, string urlPath)
        {
            this.LocalFullName = localName;
            this.TransferPercent = transferPercent;
            this.TransferSize = transferSize;
            this.urlPath = urlPath;
        }
    }
}
