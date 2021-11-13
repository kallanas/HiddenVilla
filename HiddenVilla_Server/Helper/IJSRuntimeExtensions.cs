using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiddenVilla_Server.Helper
{
    public static class IJSRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async Task ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        public static async Task SwalSuccess(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("TestSwal", "success", message);
        }
        public static async Task SwalError(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("TestSwal", "error", message);
        }
    }
}
