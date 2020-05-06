namespace Shop {
    public class Transaction {
        
        public string CustomerUUID {get; set;}
        public float PriceValue { get; set; }
        public string CreditCardNumber{ get; set; }
        
    

        public Transaction (string customeruuid, float priceValue, string creditCardNumber)
        {
            this.CustomerUUID = customeruuid;
            this.PriceValue = priceValue;
            this.CreditCardNumber = creditCardNumber;
        }
    }
}