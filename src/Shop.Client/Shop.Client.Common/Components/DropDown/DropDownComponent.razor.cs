using Microsoft.AspNetCore.Components;

namespace Shop.Client.Common.Components.DropDown;

public partial class DropDownComponent<T> : ComponentBase
{
    [Parameter] [EditorRequired] public required List<T> Options { get; set; }
    [Parameter] public T? SelectedOption { get; set; }
    [Parameter] public EventCallback<T?> SelectedOptionChanged { get; set; }


    private async Task OnSelectedOptionChanged(ChangeEventArgs args)
    {
        if (args.Value == null) return;

        var selectedOption = (T?)args.Value;
        SelectedOption = selectedOption ?? default;
        await SelectedOptionChanged.InvokeAsync(selectedOption);
    }
}