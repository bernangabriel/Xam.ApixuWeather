using Apixu.Models;
using Apixu.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Apixu.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        ApiCaller _service = null;

        bool _isBusy = false;
        public bool IsBusy {
            get => _isBusy;
            set {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        string _textToSearch = "";
        public string TextToSearch
        {
            get => _textToSearch;
            set
            {
                _textToSearch = value;
                OnPropertyChanged();
            }
        }

        ApiResponse _result;
        public ApiResponse Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }


        public ICommand OnSearchCommand { get; private set; }

        public MainPageViewModel()
        {
            _service = new ApiCaller();
            OnSearchCommand = new Command(async () => await Search());
        }

        async Task Search()
        {
            if (!string.IsNullOrWhiteSpace(TextToSearch))
            {
                this.IsBusy = true;

                var result = await _service.FetchAsync(TextToSearch);
                if (result != null)
                {
                    Result = result;
                    this.IsBusy = false;
                }
            }
        }
    }
}
