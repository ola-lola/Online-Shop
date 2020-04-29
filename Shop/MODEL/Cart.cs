using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Shop {
    public class Cart
    {
        public Dictionary<Product,int> cart = new Dictionary<Product, int>();

        public void AddProductToCart() 
        {
            //dodać opcje wpisywania ilości produktu dodawanego do koszyka
        }

        public void UpdateProductInCart() 
        {

        }

        public void DeleteProductFromCart()
        {
            //odejmowanie pojedynczego produktu
        }

        public void DeleteAllFromCart()
        {

        }

        public void CalculateTotalCartValue()
        {
            //update total price po każdym dodaniu/odjeciu produktu z koszyka
        }

        public void MakeProductReservation() 
        {
            //jak starczy czasu
        }
    }
}

