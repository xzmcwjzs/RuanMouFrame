using Dicom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_DICOM_Viewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private OpenFileDialog openFileDialog=new OpenFileDialog(); 
        private void toolStripOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) { return; }
           
            try
            {
                string fileName = openFileDialog.FileName;

                DicomFile dcmFile = DicomFile.Open(fileName,Encoding.Default);
                LoadAndShowDCMMetaInfo(dcmFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void LoadAndShowDCMMetaInfo(DicomFile dcm)
        {
            DicomDataset dcmDataset = dcm.Dataset;
            DicomFileMetaInformation dcmMetaInfo = dcm.FileMetaInfo;
        }

    }
}
