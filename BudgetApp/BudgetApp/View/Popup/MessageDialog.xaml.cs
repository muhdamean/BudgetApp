using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace BudgetApp.View.Popup
{
    
    public partial class MessageDialog : PopupPage
    {
        public MessageDialog(string title, string message, string OkText,
            Action OkAction=null, string CancelText=null, Action CancelAction=null)
        {
            InitializeComponent();
            Setup(title, message, OkText, OkAction, CancelText, CancelAction);
        }

        private void Setup(string title, string message, string okText, Action okAction, string cancelText, Action cancelAction)
        {
            CloseWhenBackgroundIsClicked = false;
            TitleTxt.Text = title;
            MessageTxt.Text = message;

            OkBtn.Text = okText;
            CancelBtn.IsVisible = string.IsNullOrWhiteSpace(cancelText) ? false : true;
            CancelBtn.Text = cancelText;

            OkBtn.Clicked += async (s, e) =>
            {
                await Navigation.PopAsync().ConfigureAwait(false);
                okAction?.Invoke();
            };

            CancelBtn.Clicked += async (s, e) =>
            {
                await Navigation.PopAsync().ConfigureAwait(false);
                cancelAction?.Invoke();
            };
        }

        public static void Show(string title, string message, string OkText, Action OkAction = null)
        {
            MessageDialog md = new MessageDialog(title, message, OkText, OkAction);
            App.Current.MainPage.Navigation.PushPopupAsync(md);
        }

        public static void Show(string title, string message, string OkText, Action OkAction, string cancelText, Action cancelAction)
        {
            MessageDialog md = new MessageDialog(title, message, OkText, OkAction, cancelText, cancelAction);
            App.Current.MainPage.Navigation.PushPopupAsync(md);
        }
    }
}

