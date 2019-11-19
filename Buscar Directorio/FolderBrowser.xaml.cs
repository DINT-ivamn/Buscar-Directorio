using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Buscar_Directorio
{
    /// <summary>
    /// Lógica de interacción para FolderBrowser.xaml
    /// </summary>
    public partial class FolderBrowser : UserControl
    {
        public string Etiqueta
        {
            get { return (string)GetValue(EtiquetaProperty); }
            set { SetValue(EtiquetaProperty, value); }
        }

        public string SelectedPath
        {
            get { return (string)GetValue(SelectedPathProperty); }
            set { SetValue(SelectedPathProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public bool AllowNewFolder
        {
            get { return (bool)GetValue(AllowNewFolderProperty); }
            set { SetValue(AllowNewFolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllowNewFolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowNewFolderProperty =
            DependencyProperty.Register("AllowNewFolder", typeof(bool), typeof(FolderBrowser), new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for SelectedPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPathProperty =
            DependencyProperty.Register("SelectedPath", typeof(string), typeof(FolderBrowser), new PropertyMetadata(""));

        // Using a DependencyProperty as the backing store for Etiqueta.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EtiquetaProperty =
            DependencyProperty.Register("Etiqueta", typeof(string), typeof(FolderBrowser), new PropertyMetadata(""));

        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(FolderBrowser), new PropertyMetadata(false));



        public FolderBrowser()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BrowseDirectory(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = AllowNewFolder;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SelectedPath = dialog.SelectedPath;
            }
        }
    }
}
