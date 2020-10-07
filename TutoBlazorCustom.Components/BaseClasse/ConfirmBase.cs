using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TutoBlazorCustom.Components
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowModal { get; set; }

        [Parameter]
        public EventCallback<bool> ConfirmationSuppression { get; set; }

        [Parameter]
        public string ConfirmationMessage { get; set; }

        public void Show()
        {
            ShowModal = true;
            StateHasChanged();
        }

        protected async Task ConfirmationChange(bool value)
        {
            ShowModal = false;
            await ConfirmationSuppression.InvokeAsync(value);
        }
    }
}
