using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApp_1
{
    class MainModel
    {
        public ObservableCollection<string> Files { get; private set; }

        public MainModel()
        {
            Files = new ObservableCollection<string>();
        }

        public void LoadFiles()
        {
            List<string> filter = new List<string>() { @"bmp", @"jpg", @"gif", @"png", @"tif" };
            FileAttributes FAt;
            FileInfo fileInfo;
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Files.Clear();
                foreach (string file in Directory.GetFiles(dialog.SelectedPath))
                {
                    fileInfo = new FileInfo(file);
                    FAt = fileInfo.Attributes;
                    if ((FAt & FileAttributes.Hidden) != FileAttributes.Hidden)
                        if (filter.Exists(n => n == file.Split(new char[] { '.' }).Last().ToLower()))
                            Files.Add(file);
                }
            }
        }
    }
}
