
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZooView.ViewModel;

namespace ZooView.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PozaIndividView : ContentPage
    {
        PozaIndividViewModel vm;
        public PozaIndividView()
        {
            InitializeComponent();
            vm = new PozaIndividViewModel();
            BindingContext = vm;
        }
    }
}