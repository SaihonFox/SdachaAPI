using System.Windows;
using APIUI.Model;

namespace APIUI;

public partial class AnalysisWindow : Window
{
	public user user;

	public AnalysisWindow(user user)
	{
		InitializeComponent();

		this.user = user;
	}
}