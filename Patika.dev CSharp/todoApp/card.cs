namespace todoApp
{
    public class card
    {
        private string? cardTitle;
        private string? cardContent;
        private sizeEnums cardSize;
        private string? cardOwner;

        public string? CardTitle { get => cardTitle; set => cardTitle = value; }
        public string? CardContent { get => cardContent; set => cardContent = value; }
        
        public string? CardOwner { get => cardOwner; set => cardOwner = value; }
        public sizeEnums CardSize { get => cardSize; set => cardSize = value; }
    }
}