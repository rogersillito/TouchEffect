using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TouchEffect.Enums;
using TouchEffect.EventArgs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TouchEffectSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimplifiedAccountsPage : ContentPage
    {
        public SimplifiedAccountsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public List<int> Numbers => Enumerable.Range(1, 20).ToList();
        private bool _isHandlingTap;
        private Command<int> _childItemCommand;
        private Command _parentItemCommand;

        public ICommand ChildItemCommand =>
            this._childItemCommand = this._childItemCommand ?? new Command<int>(
            number =>
            {
                if (this._isHandlingTap)
                {
                    //return;
                }
                this._isHandlingTap = true;
                Application.Current.MainPage.DisplayAlert("ChildItemCommand", "Child fired first: " + number, "Cancel");
                this._isHandlingTap = false;
            });

        public ICommand ParentItemCommand =>
            this._parentItemCommand = this._parentItemCommand ?? new Command(() =>
            {
                if (this._isHandlingTap)
                {
                    //return;
                }
                this._isHandlingTap = true;
                Application.Current.MainPage.DisplayAlert("ParentItemCommand", "Parent fired first", "Cancel");
                this._isHandlingTap = false;
            });
    }
}
