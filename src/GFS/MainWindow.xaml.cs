using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace GFS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Icon = new DrawingImage();
            
        } 

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(@"\images\bg_dataMan.bmp", UriKind.Relative));
            image.Source = bi;

            //this.image.Source = new BitmapImage(new Uri(@"\images\bg_dataMan.bmp", UriKind.Relative));
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(@"\images\bg_classify.png", UriKind.Relative));
            image.Source = bi;
        }

        private void Button_MouseEnter_2(object sender, MouseEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(@"\images\bg_statistic.jpg", UriKind.Relative));
            image.Source = bi;
        }

        private void Button_MouseEnter_3(object sender, MouseEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(@"\images\bg_carbon.bmp", UriKind.Relative));
            image.Source = bi;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(@"\images\splash.png", UriKind.Relative));
            image.Source = bi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("GFS.DataMan.exe");
            }
            catch (Exception )
            {
                MessageBox.Show("启动失败：\r\n找不到模块：GFS.DataMan");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Process.Start("GFS.Classification.exe");
            }
            catch (Exception )
            {
                MessageBox.Show("启动失败：\r\n找不到模块：GFS.Classification");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            try
            {
                Process.Start("GFS.Sample.exe");
            }
            catch (Exception )
            {
                MessageBox.Show("启动失败：\r\n找不到模块：GFS.Sample");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Process.Start("GFS.Carbon.exe");
            }
            catch (Exception)
            {
                MessageBox.Show("启动失败：\r\n找不到模块：GFS.Carbon");
            }
        }

    }
}
