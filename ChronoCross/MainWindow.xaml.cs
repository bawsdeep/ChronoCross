using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace ChronoCross
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

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[]? files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;

			FileOpen(files[0], false);
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			FileOpen(false);
		}

		private void MenuItemFileForceOpen_Click(object sender, RoutedEventArgs e)
		{
			FileOpen(true);
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			SaveData.Instance().Save();
		}

		private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ComboBoxFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataContext = new ViewModel();
		}

		private void FileOpen(bool force)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "memcard|memcard*.mcr";
			if (dlg.ShowDialog() == false) return;
			FileOpen(dlg.FileName, force);
		}

		private void FileOpen(String filename, bool force)
		{
			if (SaveData.Instance().Open(filename, force) == false)
			{
				MessageBox.Show("CheckSum Error", "File Open", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			DataContext = new ViewModel();
		}
	}
}
