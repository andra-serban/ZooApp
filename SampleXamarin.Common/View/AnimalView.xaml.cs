using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZooView.ViewModel;

namespace ZooView.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalView : ContentPage
    {
        AnimalViewModel vm;
        public AnimalView()
        {
            InitializeComponent();
            vm = new AnimalViewModel();
            BindingContext = vm;
        }
    }
}