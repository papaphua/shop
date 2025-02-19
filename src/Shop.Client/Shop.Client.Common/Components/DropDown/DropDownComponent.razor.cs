using Microsoft.AspNetCore.Components;

namespace Shop.Client.Common.Components.DropDown;

public partial class DropDownComponent<T> : ComponentBase
{
    [Parameter] [EditorRequired] public required List<T> Options { get; set; }
    [Parameter] public T? SelectedOption { get; set; }
    [Parameter] public EventCallback<T?> SelectedOptionChanged { get; set; }
    [Parameter] public RenderFragment<T>? ItemTemplate { get; set; }

    private bool _showDropdown = false;
    
    private void ToggleDropdown()
    {
        _showDropdown = !_showDropdown;
    }

    private async Task OnSelectedOptionChanged(T? option)
    {
        SelectedOption = SelectedOption?.Equals(option) ?? false
            ? default
            : option;
        await SelectedOptionChanged.InvokeAsync(SelectedOption);
        _showDropdown = false;
    }

    private bool IsSelectedOption(T option)
    {
        return option!.Equals(SelectedOption);
    }
}