using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_DICOM_Viewer
{
  public  class DicomHandler
    {
        string fileName = string.Empty;
        BinaryReader dicomFile;//dicom文件流

        public DicomHandler(string _fileName)
        {
            fileName = _fileName;
        }

        public void readAndShow(TextBox textBox1)
        {
            if (fileName == string.Empty)
            {
                return;
            }
            dicomFile = new BinaryReader(File.OpenRead(fileName));
            //文件开始固定的128字节为DICOM文件的引言（Preamble），不过由于可以不写，所以基本上所有的DICOM文件前128字节均为置0
            //跳过128字节导言部分
            dicomFile.BaseStream.Seek(128,SeekOrigin.Begin);

            if(new string(dicomFile.ReadChars(4)) != "DICM")
            {
                MessageBox.Show("没有dicom标志头，文件格式错误");
                return;
            }


        }

        //读取tag  直到遇见图像数据(7fe0 0010)
        private void tagRead()
        {
            bool enDir = false;
            int level = 0;
            StringBuilder folderData = new StringBuilder();
            string folderTag = "";
            while (dicomFile.BaseStream.Position+6<dicomFile.BaseStream.Length)
            {
                string tag = dicomFile.ReadUInt16().ToString("x4") + "," + dicomFile.ReadUInt16().ToString("x4");

                string VR = string.Empty;
                UInt32 Len = 0;

            }


        }


    }
}
