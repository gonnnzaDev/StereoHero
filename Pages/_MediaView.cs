namespace Project.Pages
{
    public class _MediaView : Media
    {
        public required string InitPoint { get; set; } = string.Empty;

        public _MediaView()
        {
        }
        public _MediaView(string i)
        {
            InitPoint = i;
        }

        public _MediaView(int id, string description, string name, string produceBy, double price, string image, string i)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.produceBy = produceBy;
            this.image = image;
            this.InitPoint = i;
        }
    }
}
