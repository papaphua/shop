using Microsoft.AspNetCore.Components;

namespace Shop.Client.Common.Components.DropDown;

public partial class DropDownComponent<T> : ComponentBase
{
    private bool _showDropdown = false;

    [Parameter] [EditorRequired] public required List<T> Options { get; set; }
    [Parameter] public T? SelectedOption { get; set; }
    [Parameter] public EventCallback<T?> SelectedOptionChanged { get; set; }

    private void ToggleDropdown()
    {
        _showDropdown = !_showDropdown;
    }

    private async Task OnSelectedOptionChanged(T? option)
    {
        SelectedOption = SelectedOption?.Equals(option) == true
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