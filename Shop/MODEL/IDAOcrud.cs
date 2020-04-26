namespace Shop {

    ///
    // IDAO - Interface Data Access Object - connection to DB
    ///
    public interface IDAOcrud
    {
        void AddProduct() {}
        
        void UpdateProductName() {}
        void UpdateProductQuantity() {}
        void UpdateProductPrice() {}

        
        void DeleteProduct() {}
        
        void ReadTable() {}
    }
}