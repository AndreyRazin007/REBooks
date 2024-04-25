using System.ComponentModel;
using System.IO;

namespace BookReadingApplication.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Stream _documentStream;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        public Stream DocumentStream
        {
            get { return _documentStream; }
            set
            {
                _documentStream = value;
                OnPropertyChanged(new(nameof(DocumentStream)));
            }
        }

        public ViewModel(string path) => _documentStream = new FileStream(path, FileMode.OpenOrCreate);
    }
}
