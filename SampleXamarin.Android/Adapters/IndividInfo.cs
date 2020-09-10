using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Zoo.Models;

namespace SampleXamarin.Adapters
{
    public class IndividInfo
    {
        public Individ individ;
        public IndividImages images;
        public IndividInfo(Individ individ, IndividImages images)
        {
            this.individ = individ;
            this.images = images;
        }
    }
}