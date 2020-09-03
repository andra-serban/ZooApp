
using Xamarin.Forms;
using ZooView.ViewModel;

namespace ZooView.View
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZooInfoView : ContentPage
    {
        ZooInfoViewModel vm;
        public ZooInfoView()
        {
            InitializeComponent();
            vm = new ZooInfoViewModel();
            BindingContext = vm;
        }
    }
}