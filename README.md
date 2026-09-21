# How-to-Localize-the-Customized-Drag-and-Drop-Popup-in-WPF-TreeGrid

In Syncfusion WPF TreeGrid, you can customize the drag-and-drop popup by defining a custom DragDropTemplate. When using a custom template, the built-in localization does not automatically apply to the custom text displayed in the popup.

This can be achieved by creating culture-specific resource files (.resx), retrieving the localized values through an IValueConverter, and binding the localized text to the TextBlock elements in the custom drag-and-drop template.

The following example demonstrates how to localize the drag-and-drop status text displayed in a customized drag-and-drop popup.

#### Step 1: Create Default Resource Files
Add the default resource file of TreeGrid into Resources folder. You can download the Syncfusion.SfGrid.WPF.resx [here](https://www.syncfusion.com/downloads/support/directtrac/general/ze/Syncfusion.SfGrid.WPF2020296999.zip){target="_blank"}.

![image.png](https://support.syncfusion.com/kb/agent/attachment/article/25553/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjczODc0Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.1IBi2-Pi_mLNQdMwoO1uO2kfyRc3Ggg5Y-fqV6Rj9N0)

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

        string? localizedValue = Resource1.ResourceManager.GetString(
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
    public string dragStatus { get; set; } = "DropStatus";
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
            <TextBlock Text="{Binding dragStatus ,Source={StaticResource viewModel}, Converter={StaticResource resourceValueConverter}}"
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
