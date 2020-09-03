
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZooView.ViewModel;

namespace ZooView.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        MainViewModel vm;
        public MainView()
        {
            InitializeComponent();
            vm = new MainViewModel();
            BindingContext = vm;
        }
    }
}