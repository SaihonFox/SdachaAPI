using System.Windows;

namespace APIUI;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		enter.Click += Enter_Click;
	}

	private async void Enter_Click(object sender, RoutedEventArgs e)
	{
		var user = await API.Auth(login.Text, password.Text);
		if (user == null)
		{
			MessageBox.Show("Не найден пользователь");
			return;
		}

		new AnalysisWindow(user).Show();
		Close();
	}
}