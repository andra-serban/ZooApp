
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZooView.ViewModel;

namespace ZooView.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainIstoricView : ContentPage
    {
        MainIstoricViewModel vm;
        public MainIstoricView()
        {
            InitializeComponent();
            vm = new MainIstoricViewModel();
            BindingContext = vm;
        }
    }
}