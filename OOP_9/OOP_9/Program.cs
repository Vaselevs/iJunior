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
        private int _minNumberOfClients = 1;
        private int _maxNumberOfClients = 10;
        private int _numberOfClients = 0;

        public Game()
        {
            _clients = new Queue<Client>();
            _random = new Random();

            for (int i = 0; i < _random.Next(_minNumberOfClients, _maxNumberOfClients); i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        public void Play()
        {
            Console.WriteLine("Вы администратор в магазине и следите, что бы все покупатели оплачивали товары");
            Console.WriteLine("Под вашим мнительным взором они не могут не оплатить. Либо же им придётся избавится от случайного товара");
            Console.WriteLine($"В очереди {_clients.Count}");
            Console.WriteLine();

            while (_clients.Count > 0)
            {
                Client client = _clients.Dequeue();

                _numberOfClients++;

                Console.WriteLine($"К вам подошел {_numberOfClients} покупатель!");
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

            _random = new Random();
            _shoppinCart = new ShoppingCart();

            _shoppinCart.AddManyProducts(_random.Next(_minNumbersOfProductsInshoppingCart, ShoppingCart.NumbersOfProductTypes));

            Money = _random.Next(_minRandom, _maxMoneyRandom);
        }

        public int GetShoppingCartCost()
        {
            return _shoppinCart.HowAllProductsCost();
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
        public const int NumbersOfProductTypes = 10;

        private List<Product> _productsInCart;
        private Random _random;
        private int _minRandomForCart = 0;
        private Dictionary<string, int> _allProducts;

        public ShoppingCart()
        {
            _allProducts = new Dictionary<string, int>();

            _allProducts.Add("Морковь", 10);
            _allProducts.Add("Свёкла", 15);
            _allProducts.Add("Укроп", 5);
            _allProducts.Add("Картошка", 30);
            _allProducts.Add("Лук", 11);
            _allProducts.Add("Квас", 25);
            _allProducts.Add("Пельмешки", 120);
            _allProducts.Add("Арбуз", 50);
            _allProducts.Add("Греча", 33);
            _allProducts.Add("Рис", 22);

            _productsInCart = new List<Product>();
            _random = new Random();
        }

        public void AddNewProduct()
        {
            int randomProduct = _random.Next(_minRandomForCart, _allProducts.Count);
            _productsInCart.Add(new Product(_allProducts.ElementAt(randomProduct).Key, _allProducts.ElementAt(randomProduct).Value));
        }

        public void AddManyProducts(int numberOfProducts)
        {
            for(int i = 0; i < numberOfProducts; i++)
            {
                AddNewProduct();
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

        public string ShowLastProduct()
        {
            return _productsInCart[_productsInCart.Count - 1].Name + " - " + _productsInCart[_productsInCart.Count - 1].Price;
        }

        public int HowAllProductsCost()
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
