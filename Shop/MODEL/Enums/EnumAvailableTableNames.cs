namespace Shop {
    public enum AvailableTableNames {
        products,               // 0
        customers,              // 1
        transactions,           // 2
    }

    public enum AllTableColumns {
        name,              // 0
        division,          // 1
        brigade,           // 2
        battalion,         // 3
        unit,              // 4
        status,            // 5
        quantity,          // 6
        price,             // 7
        
        
        customer_uid,
        //name,
        surname,
        email,
        delivery_address,
        tel_number,
        nick,
        password,
        // credit_card_number

        transaction_uid,
        // customer_uid,
        price_value,
        credit_card_number
    }

}