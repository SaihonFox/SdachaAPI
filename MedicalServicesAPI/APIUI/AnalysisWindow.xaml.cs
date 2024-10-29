using System.Windows;
using System.Windows.Controls;

using APIUI.Model;

namespace APIUI;

public partial class AnalysisWindow : Window
{
	public User user;

	public AnalysisWindow(User user)
	{
		InitializeComponent();

		this.user = user;

		var list = API.AnalysesList();
		var categoriesList = API.CategoryList();
		foreach (var analysis in list)
			analysis.AnalysisCategoryNavigation = categoriesList.First(c => c.Id == analysis.AnalysisCategory);

		foreach (var analyse in list)
			items_list.Items.Add(new AnalysisUserControl().SetData(analyse));

		search.TextChanged += Search_TextChanged;

		MessageBox.Show($"Добро пожаловать, {user.Surname} {user.Name} {user.Patronym}!");

		sort_by.SelectionChanged += Sort_by_SelectionChanged;
	}

	private void Sort_by_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var list = API.AnalysesList();
		var categoriesList = API.CategoryList();
		foreach (var analysis in list)
			analysis.AnalysisCategoryNavigation = categoriesList.First(c => c.Id == analysis.AnalysisCategory);

		int index = sort_by.SelectedIndex;
		items_list.Items.Clear();
		list = index switch
		{
			0 => list.OrderBy(a => a.Name).ToList(),
			1 => list.OrderBy(a => a.Price).ToList(),
			2 => list.OrderBy(a => a.ResultsAfter).ToList(),
			3 => list.OrderBy(a => a.AnalysisCategory).ToList(),
		};
		foreach (var analyse in list)
			items_list.Items.Add(new AnalysisUserControl().SetData(analyse));
	}

	private void Search_TextChanged(object sender, TextChangedEventArgs e)
	{
		items_list.Items.Clear();
		var analyses = API.AnalysesList();
		var categoriesList = API.CategoryList();
		foreach (var analysis in analyses)
			analysis.AnalysisCategoryNavigation = categoriesList.First(c => c.Id == analysis.AnalysisCategory);

		var list = analyses.Where(a => new[]{a.Name, a.AnalysisCategoryNavigation.Name, a.ResultsAfter, a.Price.ToString()}.Any(s => s.Contains(search.Text.Trim(), StringComparison.CurrentCultureIgnoreCase))).ToList();
		foreach (var a in list)
			items_list.Items.Add(new AnalysisUserControl().SetData(a));
	}
}