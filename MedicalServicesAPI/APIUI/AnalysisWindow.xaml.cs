using System.Windows;
using System.Windows.Controls;

using APIUI.Model;

namespace APIUI;

public partial class AnalysisWindow : Window
{
	public user user;

	public AnalysisWindow(user user)
	{
		InitializeComponent();

		this.user = user;

		var list = API.AnalysesList();
		foreach (var analyse in list)
			grid.Items.Add(analyse);

		search.TextChanged += Search_TextChanged;

		MessageBox.Show($"Добро пожаловать, {user.surname} {user.name} {user.patronym}!");
	}

	private void Search_TextChanged(object sender, TextChangedEventArgs e)
	{
		grid.Items.Clear();
		var analyses = API.AnalysesList();
		var list = analyses.Where(a => new[]{a.name, a.analyses_category.name, a.results_after, a.price.ToString()}.Any(s => s.Contains(search.Text.Trim(), StringComparison.CurrentCultureIgnoreCase)));
		foreach (var a in list)
			grid.Items.Add(a);
	}
}