namespace PortraitLandscapeLayoutTest;

public static class MyVisualStateManagerGridHandling {
    /// <summary>
    /// Iterate through the VisualStateGroups and apply the appropriate VisualState to the grid
    /// </summary>
    /// <param name="view"></param>
    /// <param name="stateName">The name of the Grid we're working on</param>
    public static void ApplyVisualState(BindableObject view, string stateName) {
        if (view is VisualElement visualElement) {
            var visualStateGroups = VisualStateManager.GetVisualStateGroups(visualElement);
            foreach (var group in visualStateGroups) {
                var state = group.States.FirstOrDefault(s => s.Name == stateName);
                if (state != null) {
                    foreach (var setter in state.Setters) {
                        ApplySetter(visualElement, setter);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Apply the setter to the target element
    /// </summary>
    /// <param name="target">VisualElement</param>
    /// <param name="setter">Setter</param>
    private static void ApplySetter(VisualElement target, Setter setter) {
        var targetElement = target.FindByName<Element>(setter.TargetName);
        if (targetElement != null) {
            //Console.WriteLine($"Applying setter: {setter.TargetName}.{setter.Property.PropertyName} = {setter.Value}");
            targetElement.SetValue(setter.Property, setter.Value);
        } else {
            //Console.WriteLine($"Target element not found: {setter.TargetName}");
        }
    }
}
