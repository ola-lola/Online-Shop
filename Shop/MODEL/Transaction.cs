namespace Shop {
    public class Transaction {
        public string CustomerUid { get; set; }   // Jak przekazać tu Uid customera?
        public float PriceValue { get; set; }
        public string CreditCardNumber{ get; set; }
    

        public Transaction ( string customerUid, float priceValue, string creditCardNumber)
        {
            this.CustomerUid = customerUid;
            this.PriceValue = priceValue;
            this.CreditCardNumber = creditCardNumber;
        }
        
    }
}