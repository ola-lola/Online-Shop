namespace Shop {
    public class Customer {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Nick { get; set; }

        public string Password { get; set; }

        public string CreditCard { get; set; }

        public Customer( string name, string surname, string email,
                        string address, string phone, string nick,
                        string password, string creditcard)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Address = address;
            this.Phone = phone;
            this.Nick = nick;
            this.Password = password;
            this.CreditCard = creditcard;
        }
    }
}