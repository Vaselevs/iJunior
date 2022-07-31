using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Play();
        }
    }

    public class Game
    {
        private Queue<Client> _clients;
        private Random _random;

        public Game()
        {
            int minNumberOfClients = 1;
            int maxNumberOfClients = 10;
            _clients = new Queue<Client>();
            _random = new Random();

            int numberOfClients = _random.Next(minNumberOfClients, maxNumberOfClients);

            for (int i = 0; i < numberOfClients; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        public void Play()
        {
            int numberOfClients = 0;

            Console.WriteLine("Вы администратор в магазине и следите, что бы все покупатели оплачивали товары");
            Console.WriteLine("Под вашим мнительным взором они не могут не оплатить. Либо же им придётся избавится от случайного товара");
            Console.WriteLine($"В очереди {_clients.Count}");
            Console.WriteLine();

            while (_clients.Count > 0)
            {
                Client client = _clients.Dequeue();

                numberOfClients++;

                Console.WriteLine($"К вам подошел {numberOfClients} покупатель!");
                Console.WriteLine($"У него {client.Money} денег в кошельке");
                Console.WriteLine($"Он набрал товаров на сумму: {client.GetShoppingCartCost()}");
                Console.WriteLine();

                client.ShowShoppingCartProducts();

                Console.WriteLine();

                while (client.GetShoppingCartCost() > client.Money)
                {
                    Product deletedProduct = client.DeleteProductFromShoppingCart();
                    Console.WriteLine($"Клиент убирате из корзины {deletedProduct.Name}");
                }

                Console.WriteLine("Клиент расплачивается и уходит!");
                Console.WriteLine();
            }
        }
    }

    public class Client
    {
        private ShoppingCart _shoppinCart;
        private Random _random;
        public int Money { get; private set; }

        public Client()
        {
            int _minRandom = 0;
            int _minNumbersOfProductsInshoppingCart = 1;
            int _maxMoneyRandom = 300;
            int _maxProductsInCart = 10;

            _random = new Random();
            _shoppinCart = new ShoppingCart();
            Money = _random.Next(_minRandom, _maxMoneyRandom);

            _shoppinCart.AddManyProducts(_random.Next(_minNumbersOfProductsInshoppingCart, _maxProductsInCart));
        }

        public int GetShoppingCartCost()
        {
            return _shoppinCart.GetProductsCostSum();
        }

        public void ShowShoppingCartProducts()
        {
            _shoppinCart.ShowAllProductsInfo();
        }

        public Product DeleteProductFromShoppingCart()
        {
            Product product = GetRandomProductFromShoppingCart();
            _shoppinCart.DeleteProduct(product);
            return product;
        }

        private Product GetRandomProductFromShoppingCart()
        {
            return _shoppinCart.GetRandomProduct();
        }
    }

    public class ShoppingCart
    {
        private List<Product> _productsInCart;
        private List<Product> _allProducts;
        private Random _random;
        private int _minRandomForCart = 0;

        public ShoppingCart()
        {
            _allProducts = new List<Product>();

            _allProducts.Add(new Product("Морковь", 10));
            _allProducts.Add(new Product("Свёкла", 15));
            _allProducts.Add(new Product("Укроп", 5));
            _allProducts.Add(new Product("Картошка", 30));
            _allProducts.Add(new Product("Лук", 11));
            _allProducts.Add(new Product("Квас", 25));
            _allProducts.Add(new Product("Пельмешки", 120));
            _allProducts.Add(new Product("Арбуз", 50));
            _allProducts.Add(new Product("Греча", 33));
            _allProducts.Add(new Product("Рис", 22));

            _productsInCart = new List<Product>();
            _random = new Random();
        }

        public void AddManyProducts(int numberOfProducts)
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                int randomProduct = _random.Next(_minRandomForCart, _allProducts.Count);
                _productsInCart.Add(_allProducts[randomProduct]);
                System.Threading.Thread.Sleep(50);
            }
        }

        public void ShowAllProductsInfo()
        {
            foreach (Product product in _productsInCart)
            {
                Console.WriteLine(product.ShowInfo());
            }
        }

        public int GetProductsCostSum()
        {
            int allPrice = 0;

            foreach (Product product in _productsInCart)
            {
                allPrice += product.Price;
            }

            return allPrice;
        }

        public Product GetRandomProduct()
        {
            int randomProductId = _random.Next(_minRandomForCart, _productsInCart.Count);
            Product randomProduct = _productsInCart[randomProductId];
            _productsInCart.RemoveAt(randomProductId);

            return randomProduct;
        }

        public void DeleteProduct(Product product)
        {
            _productsInCart.Remove(product);
        }
    }

    public class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string ShowInfo()
        {
            return Name + " " + Price;
        }
    }
}
