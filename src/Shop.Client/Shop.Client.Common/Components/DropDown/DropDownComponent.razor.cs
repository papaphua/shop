using Microsoft.AspNetCore.Components;

namespace Shop.Client.Common.Components.DropDown;

public partial class DropDownComponent<T> : ComponentBase
{
    private bool _showDropdown = false;
    [Parameter] [EditorRequired] public required List<T> Options { get; set; }
    [Parameter] public T? SelectedOption { get; set; }
    [Parameter] public EventCallback<T?> SelectedOptionChanged { get; set; }
    [Parameter] public EventCallback OnAfterSelection { get; set; }

    private void ToggleDropdown()
    {
        _showDropdown = !_showDropdown;
    }

    private async Task OnSelectedOptionChanged(T? option)
    {
        if (SelectedOption != null && SelectedOption.Equals(option))
        {
            SelectedOption = default;
            await SelectedOptionChanged.InvokeAsync(default);
        }
        else
        {
            SelectedOption = option;
            await SelectedOptionChanged.InvokeAsync(option);
        }

        _showDropdown = false;
        await OnAfterSelection.InvokeAsync(SelectedOption);
    }

    private bool IsSelectedOption(T option)
    {
        return option!.Equals(SelectedOption);
    }
}