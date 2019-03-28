using Apixu.Services;
using Apixu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apixu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm = default;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new MainPageViewModel();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = e.ToString();
            if (!string.IsNullOrEmpty(selectedValue))
            {
                vm.OnSearchCommand.Execute(null);
            }
        }
    }
}