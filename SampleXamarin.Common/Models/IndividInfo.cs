using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Models;

namespace SampleXamarin.Models
{
    class IndividInfo
    {
        Individ individ;
        IndividImages images;
        IndividInfo(Individ individ, IndividImages images)
        {
            this.individ = individ;
            this.images = images;
        }
    }
}
