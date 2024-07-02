namespace PortraitLandscapeLayoutTest;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();
            
        // Add our function to the SizeChanged event
        SizeChanged += (sender, e) => ApplyDynamicGrid(sender, e, "MainGrid");
    }

    /// <summary>
    /// Process the SizeChanged event and apply the appropriate VisualState to the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <param name="OurGrid">Name of grid to process (so we don't have to search for it)</param>
    private void ApplyDynamicGrid(object? sender, EventArgs e, string OurGrid) {
        var GridName = this.FindByName<Grid>(OurGrid);

        Console.WriteLine("SizeChanged event triggered");

        if (Width > Height) {
            Console.WriteLine("Switching to Landscape mode");
            MyVisualStateManagerGridHandling.ApplyVisualState(GridName, "Landscape");
        } else {
            Console.WriteLine("Switching to Portrait mode");
            MyVisualStateManagerGridHandling.ApplyVisualState(GridName, "Portrait");
        }
    }

    // Handle orientation changes manually (ignoring xaml VisualStateManager)
    /*
    private void OnSizeChanged(object? sender, EventArgs e) {
        if (Width > Height) {
            // Landscape
            MainGrid.RowDefinitions.Clear();
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            MainGrid.ColumnDefinitions.Clear();
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Grid.SetRow(Box1, 0);
            Grid.SetColumn(Box1, 0);
            Grid.SetRowSpan(Box1, 1);
            Grid.SetColumnSpan(Box1, 1);

            Grid.SetRow(Box2, 0);
            Grid.SetColumn(Box2, 1);
            Grid.SetRowSpan(Box2, 2);
            Grid.SetColumnSpan(Box2, 1);

            Grid.SetRow(Box3, 1);
            Grid.SetColumn(Box3, 0);
            Grid.SetRowSpan(Box3, 1);
            Grid.SetColumnSpan(Box3, 1);
        } else {
            // Portrait
            MainGrid.RowDefinitions.Clear();
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            MainGrid.ColumnDefinitions.Clear();
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Grid.SetRow(Box1, 0);
            Grid.SetColumn(Box1, 0);
            Grid.SetRowSpan(Box1, 1);
            Grid.SetColumnSpan(Box1, 1);

            Grid.SetRow(Box2, 1);
            Grid.SetColumn(Box2, 0);
            Grid.SetRowSpan(Box2, 1);
            Grid.SetColumnSpan(Box2, 1);

            Grid.SetRow(Box3, 2);
            Grid.SetColumn(Box3, 0);
            Grid.SetRowSpan(Box3, 1);
            Grid.SetColumnSpan(Box3, 1);
        }

        // Log for debugging
        Console.WriteLine($"Orientation changed to: {(Width > Height ? "Landscape" : "Portrait")}");
    }
}
*/

}
