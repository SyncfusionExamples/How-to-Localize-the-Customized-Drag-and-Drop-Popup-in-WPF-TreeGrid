# How to Localize the Customized Drag-and-Drop Popup in WPF TreeGrid

In Syncfusion [WPF TreeGrid](https://www.syncfusion.com/wpf-controls/treegrid){target="_blank"}, you can customize the drag-and-drop popup by defining a custom DragDropTemplate. When using a custom template, the built-in localization does not automatically apply to the custom text displayed in the popup.

This can be achieved by creating culture-specific resource files (.resx), retrieving the localized values through an IValueConverter, and binding the localized text to the TextBlock elements in the custom drag-and-drop template.

The following example demonstrates how to localize the drag-and-drop status text displayed in a customized drag-and-drop popup.

#### Step 1: Create Default Resource Files
Add the default resource file of TreeGrid into Resources folder. You can download the Syncfusion.SfGrid.WPF.resx [here](https://www.syncfusion.com/downloads/support/directtrac/general/ze/Syncfusion.SfGrid.WPF2020296999.zip){target="_blank"}.
![image.png](https://support.syncfusion.com/kb/agent/attachment/article/25553/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6Ijc0NDkxIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.mmcFw9IcmCf4TmioDKaxXojf2rzvF8l3Iz6PrLFx2B8)

#### Step 2: Create Resource Files
Create culture-specific resource file specifically for the custom drag-and-drop template.

**Image:**

![image.png](https://support.syncfusion.com/kb/agent/attachment/article/25553/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjczODUzIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.3xKUqYZqUlIpHdP3lYUtE8GrDCEwbTjzEixFgrtHyWg)

#### Step 3: Create the Value Converter
Create a converter that retrieves the localized value from the resource file based on the current culture.

**ResourceValueConverter.cs**
 
```csharp
public class ResourceValueConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        if (value is null)
        {
            return string.Empty;
        }

        string resourceKey = value.ToString() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(resourceKey))
        {
            return string.Empty;
        }

        string? localizedValue = CustomDragResource.ResourceManager.GetString(
            resourceKey,
            culture);

        return localizedValue ?? resourceKey;
    }

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
} 
```

#### Step 4: Define the ViewModel
Specify the resource key to display in the drag-and-drop popup. To localize additional content in the template, add a corresponding property in the ViewModel, define its value in the resource file, and bind it to the template.

**ViewModel.cs**
 
```csharp
public class ViewModel
{
    public string DropStatus { get; set; } = "DropStatus";
} 
```

#### Step 5: Apply Localization in the Drag-and-Drop Template
Bind the drag status values to the converter in the customized drag-and-drop template.

**Drap Drag Template**
  
```xml
<DataTemplate x:Key="DragDropTemplate">
    <Border x:Name="border" 
    Width="120"    
    Background="SkyBlue"   
    BorderBrush="Black"  
    BorderThickness="1.2">
        <Grid  VerticalAlignment="Center" 
       HorizontalAlignment="Left">
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <TextBlock Text="{Binding DropStatus ,Source={StaticResource viewModel}, Converter={StaticResource resourceValueConverter}}"
                           Foreground="Black"/>
            <TextBlock Text="{Binding DragStatus, Converter={StaticResource resourceValueConverter}}"  
       Foreground="Black" Grid.Row="1" />

        </Grid>
    </Border>
</DataTemplate> 
```

#### Output
When the application culture changes, the drag-and-drop popup automatically displays the localized text from the corresponding resource file.

![image.png](https://support.syncfusion.com/kb/agent/attachment/article/25553/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjczODczIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.dyB9yz7IBPBpC-6Hoovr_A-uTqdGeTIgghZOZsNI8uA)


[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-Localize-the-Customized-Drag-and-Drop-Popup-in-WPF-TreeGrid)

#### Conclusion

I hope you enjoyed learning how to improve shift‑key row selection performance in a [WPF TreeGrid](https://www.syncfusion.com/wpf-controls/treegrid){target="_blank"}.

You can refer to our [WPF TreeGrid](https://www.syncfusion.com/wpf-controls/treegrid). feature tour page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/wpf/treegrid/getting-started){target="_blank"}, and how to quickly get started with configuration specifications. You can also explore our [WPF TreeGrid example](https://github.com/syncfusion/wpf-demos/tree/master/treegrid){target="_blank"} to understand how to create and manipulate data.

For current customers, check out our components from the [License and Downloads](https://www.syncfusion.com/sales/ui-component-suite){target="_blank"} page. If you are new to Syncfusion, try our 30-day [free trial](https://www.syncfusion.com/downloads/wpf/confirm){target="_blank"} to check out our other controls.
Please let us know in the comments section if you have any queries or require clarification. You can also contact us through our [support forums](https://www.syncfusion.com/forums/wpf?control=sftreegrid){target="_blank"}, [Direct-Trac](https://support.syncfusion.com/create){target="_blank"}, or [feedback portal](https://www.syncfusion.com/feedback/wpf?control=sftreegrid){target="_blank"}. We are always happy to assist you!
