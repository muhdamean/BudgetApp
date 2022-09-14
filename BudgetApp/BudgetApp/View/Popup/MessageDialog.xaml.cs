using System;
using System.Collections.Generic;
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
            
        }
    }
}

