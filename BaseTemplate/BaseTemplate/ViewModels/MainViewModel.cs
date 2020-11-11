using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BaseMvvmToolKIt.Commands;
using BaseTemplate.Models;
using BaseTemplate.Services;
using Refit;
using TemplateFoundation.Commands;
using TemplateFoundation.ViewModelFoundation;

namespace BaseTemplate.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        const string Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiMzMyMDE5NCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6IjIiLCJ1bmlxdWVfbmFtZSI6Ik1ta19hZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2xvY2FsaXR5IjoiRmFsc2UiLCJuYW1laWQiOiJtTWtfYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9hdXRoZW50aWNhdGlvbiI6InRydWUiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9oYXNoIjoiOsO6w4cxw6TCpsKgUMK5w7fCncOcXGZrflx1MDAyNsOrXyBd4oCm4oCww5c3w6jDucOdwp1Ow63CpFx1MDAwMyIsInByaW1hcnlzaWQiOiIzMzIzNTU3IiwiZ3JvdXBzaWQiOiIwIiwiZ2l2ZW5fbmFtZSI6IkFobWVkIEFyYWZhIEdvbWFhIEFsaSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N5c3RlbSI6IiIsInJvbGUiOiJbMSwxNSwxNiwxNywxOCwxOSwyMCwyMSwyMiwyMywyNCwyNSwyNiwyNywyOCwyOSwzMCwzMSwzMiwxMDEsMTAyLDEwMywxMDQsMTAwMDAxLDEwMDAwMiwxMDAwMDMsMTAwMDA0LDEwMDAwNSwxMDAwMDYsMTAwMDA3LDEwMDAwOCw0MDAwMDEsNDAwMDAyLDQwMDAwOSw0MDAwMTAsNDAwMDExLDQwMDAxMiw0MDAwMTMsNDAwMDE0LDQwMDAxNSw0MDAwMTYsNDAwMDE3LDQwMDAxOSw0MDAwMjAsNDAwMDIxLDQwMDAyMiw0MDAwMjMsNDAwMDI0LDQwMDAyNSw0MDAwMjYsNDAwMDI3LDQwMDAyOCw0MDAwMjksNDAwMDMwLDQwMDAzMSw0MDAwMzIsNDAwMDMzLDQwMDAzNCw0MDAwMzUsNDAwMDM2LDQwMDAzNyw0MDAwMzgsNDAwMDM5LDQwMDA0MCw0MDAwNDEsNDAwMDQyLDQwMDA0Myw0MDAwNDQsNDAwMDQ1LDQwMDA0Niw0MDAwNDddIiwiaXNzIjoiU2VjdXJpdHkuU2VydmljZSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODEvIiwiZXhwIjoxNjA0NTQzOTA1LCJuYmYiOjE2MDQ0ODI0NjV9.JC2_QLCeDomTnoJCv9McqFQa_WqEDXJNQDZTQD-0xvo";
        public IAsyncCommand ClickedCommand { get; set; }
        public ObservableCollection<Value> DataSource { get; set; } = new ObservableCollection<Value>();
        public IAsyncCommand LoadMore { get; set; }
        public IAsyncCommand NavigateCommand { get; set; }
        private async Task FetchData()
        {
            try
            {
                IAndalusiaApi AndApi = RestService.For<IAndalusiaApi>("http://10.24.105.60:7092/OutPatientServices");
                var query = new QueryString() { count = "true", top = 20, orderby = "ArName" };
                var root = await AndApi.GetUsers(Token, query);
                foreach (var item in root.value)
                {
                    DataSource.Add(item);
                }
                RaisePropertyChanged(nameof(DataSource));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public MainViewModel()
        {
            Title = "MainPage";
            NavigateCommand = new AsyncCommand(async () => { await NavigationService.PushPageModel<TestViewModel>(); });
            LoadMore = new AsyncCommand(async () => { await FetchData(); });
            ClickedCommand = new AsyncCommand(async () => { await FetchData(); });
        }
    }
}
