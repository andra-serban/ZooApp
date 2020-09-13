namespace SampleXamarin.Constants
{
    public static class Constants
    {
        public const string mainUri = "https://zoo-webapp.azurewebsites.net/api/mainsapi/";
        public const string individUri = "https://zoo-webapp.azurewebsites.net/api/individsapi/";
        public const string animalUri = "https://zoo-webapp.azurewebsites.net/api/animalsapi/";
        public const string imagesUri = "https://zoo-webapp.azurewebsites.net/api/IndividImagesApi/";
        public const string selectAnimalQuery = "SELECT  EXISTS * FROM Animal Where Id=?";
        public const string selectIndividQuery = "SELECT EXISTS * FROM Individ Where Id=?";
        public const string selectMainQuery = "SELECT EXISTS * FROM Main Where Ancora=?";
        public const string selectImagesQuery = "SELECT EXISTS * FROM IndividImages Where Idindivid=?";
    }
}
