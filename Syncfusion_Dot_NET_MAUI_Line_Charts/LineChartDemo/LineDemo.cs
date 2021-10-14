using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Syncfusion.Maui.Charts;

namespace Charts
{
    public class LineDemo : ContentPage
    {
        public LineDemo()
        {
			SfCartesianChart chart = new SfCartesianChart();
			chart.BindingContext = new ViewModel.ViewModel();

			//Initializing Primary Axis
			CategoryAxis primaryAxis = new CategoryAxis();
			chart.PrimaryAxis = primaryAxis;

			//Initializing Secondary Axis
			NumericalAxis secondaryAxis = new NumericalAxis();
			chart.SecondaryAxis = secondaryAxis;

			//Initialize series
			var binding = new Binding() { Path = "Data" };
			LineSeries lineSeries = new LineSeries()
			{
				XBindingPath = "Year",
				YBindingPath = "Counts",
				ShowDataLabels = true,
				Background = new SolidColorBrush(Color.FromArgb("#314A6E")),
			};

			lineSeries.SetBinding(ChartSeries.ItemsSourceProperty, binding);
			chart.Series.Add(lineSeries);

			//Chart title
			var title = new Label()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HorizontalTextAlignment = Microsoft.Maui.TextAlignment.Center,
				Text = "Annual rainfall of Paris",
				FontSize = 16,
				Margin = new Microsoft.Maui.Thickness(5, 10, 5, 10),
			};
			chart.Title = title;

			var grid = new Grid() 
			{ 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Microsoft.Maui.Thickness(20),
			};

			grid.Children.Add(chart);

			this.Content = grid;
		}
	}
}