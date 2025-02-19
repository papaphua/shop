using Microsoft.AspNetCore.Components;
using Shop.Shared.Core;

namespace Shop.Client.Common.Components.DropDown;

public partial class DropDownComponent : ComponentBase
{
    [Parameter] [EditorRequired] public List<IDropDownOption> Options { get; set; } = [];
    [Parameter] public int? SelectedOption { get; set; }
    [Parameter] public EventCallback<int?> SelectedOptionChanged { get; set; }

    private async Task OnSelectedOptionChanged(ChangeEventArgs args)
    {
        if (int.TryParse(args.Value!.ToString(), out var parsedValue))
        {
            if (parsedValue > 0)
            {
                SelectedOption = parsedValue;
                await SelectedOptionChanged.InvokeAsync(parsedValue);
            }
            else
            {
                SelectedOption = null;
                await SelectedOptionChanged.InvokeAsync(null);
            }
        }
    }
}