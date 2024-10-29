using System.Windows.Controls;
using APIUI.Model;

namespace APIUI;

public partial class AnalysisUserControl : UserControl
{
	public AnalysisUserControl() =>
		InitializeComponent();

	public AnalysisUserControl SetData(Analysis a)
	{
		name.Text = a.Name;
		price.Text = a.Price.ToString();
		results_after.Text = a.ResultsAfter;
		category.Text = a.AnalysisCategoryNavigation.Name;

		return this;
	}
}