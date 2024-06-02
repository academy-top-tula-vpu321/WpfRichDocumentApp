using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRichDocumentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream stream = File.Open("text.xaml", FileMode.OpenOrCreate))
            {
                //if(docViewer.Document is not null)
                //{
                //    XamlWriter.Save(docViewer.Document, stream);
                //}
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream stream = File.Open("text.xaml", FileMode.Open))
            {
                //FlowDocument? document = XamlReader.Load(stream) as FlowDocument;
                //if (document is not null)
                //    docViewer.Document = document;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }

        private void docSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new();
            if(saveFile.ShowDialog() == true)
            {
                TextRange doc = new(txtEditor.Document.ContentStart, txtEditor.Document.ContentEnd);
                using (FileStream file = File.Create(saveFile.FileName))
                {
                    doc.Save(file, DataFormats.Rtf);
                }
            }
        }

        private void docLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new();
            if (openFile.ShowDialog() == true)
            {
                TextRange doc = new(txtEditor.Document.ContentStart, txtEditor.Document.ContentEnd);
                using (FileStream file = File.Open(openFile.FileName, FileMode.Open))
                {
                    doc.Load(file, DataFormats.Rtf);
                }
            }
        }
    }
}