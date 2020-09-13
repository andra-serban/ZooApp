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