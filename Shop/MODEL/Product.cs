namespace Shop {
    public class Product {
        public string Name { get; set; }
        public string Division1 { get; set; }
        public string Brigade2 { get; set; }
        public string Battalion3 { get; set; }

        public int Quantity { get; set; }
        public string Unit { get; set; }

        public string Status { get; set; }

        public float PricePerUnit { get; set; }

        public Product( string name, string division, string brigade,
                        string battalion, int quantity, string unit,
                        string status, float pricePerUnit)
        {
            this.Name = name;
            this.Division1 = division;
            this.Brigade2 = brigade;
            this.Battalion3 = battalion;
            this.Quantity = quantity;
            this.Unit = unit;
            this.Status = status;
            this.PricePerUnit = pricePerUnit;
        }
        
    }
}