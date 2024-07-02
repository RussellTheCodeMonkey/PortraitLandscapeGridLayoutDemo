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
}
