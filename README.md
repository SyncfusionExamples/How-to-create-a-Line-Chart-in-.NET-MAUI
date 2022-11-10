# How to create a Line Chart in .NET MAUI (SfCartesianChart)

A .NET MAUI Line Chart is a visual representation of changing data that is created by connecting a set of points with a straight line. This section explains how to create a beautiful .NET MAUI Line Charts.

### Register the handler.
Syncfusion.Maui.Core nuget is a dependent package for all Syncfusion controls of .NET MAUI. In the MauiProgram.cs file, register the handler for Syncfusion core. For more details refer this [link](https://help.syncfusion.com/maui/cartesian-charts/getting-started#register-the-handler).

### Initialize Chart
Import the [SfCartesianChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html?tabs=tabid-1) namespace as shown below.

**[XAML]**
```
xmlns:chart="clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts"
```
**[C#]**
```
using Syncfusion.Maui.Charts;
```
Initialize an empty chart with [XAxes](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html?tabs=tabid-1#Syncfusion_Maui_Charts_SfCartesianChart_PrimaryAxis) and [YAxes](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html?tabs=tabid-1#Syncfusion_Maui_Charts_SfCartesianChart_SecondaryAxis) as shown below,

**[XAML]**
```
<chart:SfCartesianChart>

    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis/>
    </chart:SfCartesianChart.XAxes >

    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis/>
    </chart:SfCartesianChart.YAxes>

</chart:SfCartesianChart>

```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();

//Initializing Primary Axis
CategoryAxis primaryAxis = new CategoryAxis();

chart.XAxes.Add(primaryAxis);

//Initializing Secondary Axis
NumericalAxis secondaryAxis = new NumericalAxis();

chart.YAxes.Add(secondaryAxis);

this.Content = chart;

```
### Initialize view model

Now, let define a simple data model that represents a data point for .NET MAUI Line Chart.
```
public class Model
{
    public string Year { get; set; }

    public double Counts { get; set; }

    public Model(string name , double count)
    {
        Year = name;
        Counts = count;
    }
}
```
Create a view model class and initialize a list of objects as shown below,
```
public class ViewModel
{
    public ObservableCollection<Model> Data { get; set; }

    public ViewModel()
    {
        Data = new ObservableCollection<Model>()
        {
            new Model("1925", 415),
            new Model("1926", 408),
            new Model("1927", 415),
            new Model("1928", 350),
            new Model("1929", 375),
            new Model("1930", 500),
            new Model("1931", 390),
            new Model("1932", 450),
        };
    }
}
```
Set the **ViewModel** instance as the **BindingContext** of chart; this is done to bind properties of **ViewModel** to SfCartesianChart.

> **Note:** Add namespace of ViewModel class in your XAML page if you prefer to set BindingContext in XAML.

**[XAML]**
```
  xmlns:viewModel ="clr-namespace:MauiApp"
. . .

  <chart:SfCartesianChart>

    <chart:SfCartesianChart.BindingContext>
        <viewModel:ViewModel/>
    </chart:SfCartesianChart.BindingContext>

</chart:SfCartesianChart>
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();
chart.BindingContext = new ViewModel();
```
### How to populate data in .NET MAUI Line Charts

As we are going to visualize the comparison of annual rainfall in the data model, add [LineSeries](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.LineSeries.html?tabs=tabid-1) to [SfCartesianChart.Series](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_Series) property, and then bind the Data property of the above ViewModel to the [LineSeries.ItemsSource](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html?&_ga=2.202111828.471182244.1634019879-255829655.1613129491#Syncfusion_Maui_Charts_ChartSeries_ItemsSource) property as shown below.
  
> **Note:** Need to set [XBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_XBindingPath) and [YBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.XYDataSeries.html#Syncfusion_Maui_Charts_XYDataSeries_YBindingPath) properties, so that series would fetch values from the respective properties in the data model to plot the series.

**[XAML]**
  ```
<chart:SfCartesianChart>
    <chart:SfCartesianChart.BindingContext>
        <viewModel:ViewModel/>
    </chart:SfCartesianChart.BindingContext>

. . .
<chart:SfCartesianChart.Series>
    <chart:LineSeries ItemsSource="{Binding Data}"
                        XBindingPath="Year" 
                        YBindingPath="Counts"
                        ShowDataLabels="True" >
    </chart:LineSeries>
</chart:SfCartesianChart.Series>
. . .
</chart:SfCartesianChart> 
```
**[C#]**

```
SfCartesianChart chart = new SfCartesianChart();
chart.BindingContext = new ViewModel();
. . .
var binding = new Binding() { Path = "Data" };
LineSeries lineSeries = new LineSeries()
{
	XBindingPath = "Year",
	YBindingPath = "Counts",
        ShowDataLabels = true
};

LineSeries.SetBinding(ChartSeries.ItemsSourceProperty, binding);
chart.Series.Add(LineSeries);
```

## Output:

![.NET MAUI Line Chart](https://user-images.githubusercontent.com/53489303/200559711-8a02a2ac-e3cc-48e0-b522-178f491d86c2.png)

KB article - [How to create a Line Chart in .NET MAUI](https://www.syncfusion.com/kb/12869/how-to-create-a-line-chart-in-net-maui)
