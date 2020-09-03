
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZooView.ViewModel;

namespace ZooView.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndividView : ContentPage
    {
        IndividViewModel vm;
        public IndividView()
        {
            InitializeComponent();
            vm = new IndividViewModel();
            BindingContext = vm;
        }
    }
}