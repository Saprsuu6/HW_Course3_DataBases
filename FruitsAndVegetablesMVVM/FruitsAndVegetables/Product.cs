namespace FruitsAndVegetables
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Calories { get; set; }

        public Product Clone()
        {
            return new Product()
            {
                Name = this.Name,
                Type = this.Type,
                Color = this.Color,
                Calories = this.Calories
            };
        }
    }

}
