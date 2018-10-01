using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;


namespace WpfApp_1
{
    class ViewModel : INotifyPropertyChanged
    {
        private Picture selectedPicture;
        private RelayCommand loadfiles;
        public ObservableCollection<Picture> Files { get; private set; }
        Timer timer = new Timer();

        public Picture SelectedPicture
        {
            get { return selectedPicture; }
            set
            {
                selectedPicture = value;
                OnPropertyChanged("SelectedPicture");
            }
        }
        public ViewModel()
        {
            Files = new ObservableCollection<Picture>();
        }

        public RelayCommand Load_Files
        {
            get
            {
                return loadfiles ?? (loadfiles = new RelayCommand(LoadFiles));
            }
        }

        public void LoadFiles()
        {
            List<string> filter = new List<string>() { @"bmp", @"jpg", @"gif", @"png", @"tif", @"jpeg" };
            FileInfo fileInfo;
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Files.Clear();
                foreach (string file in Directory.GetFiles(dialog.SelectedPath))
                {
                    fileInfo = new FileInfo(file);
                    if (filter.Exists(n => n == file.Split(new char[] { '.' }).Last().ToLower()))
                    {
                        try
                        {
                            var fileinfo = new FileInfo(file);
                            Files.Add(new Picture { Name = fileinfo.Name, _Path = fileinfo.FullName });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
