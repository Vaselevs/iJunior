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
        private int _numberOfClients = 0;

        private ClientQueue _clientQueue;

        public Game()
        {
            _clients = new Queue<Client>();
            _random = new Random();
        }

        public void Play()
        {
            Console.WriteLine("Вы администратор в магазине и следите, что бы все покупатели оплачивали товары");
            Console.WriteLine("Под вашим мнительным взором они не могут не оплатить. Либо же им придётся избавится от случайного товара");
            Console.WriteLine($"В очереди {_clientQueue.GetNumberOfClients()}");
            Console.WriteLine();

            while (_clientQueue.GetNumberOfClients() > 0)
            {
                Client client = _clientQueue.GetNewClient();

                _numberOfClients++;

                Console.WriteLine($"К вам подошел {_numberOfClients} покупатель!");
                Console.WriteLine($"У него {client.Money} денег в кошельке");
                Console.WriteLine($"Он набрал товаров на сумму: {client.GetClientShoppingCartCost()}");
                Console.WriteLine();

                client.ShowClientShoppingCartProducts();

                Console.WriteLine();

                if (client.GetClientShoppingCartCost() >= client.Money)
                {
                    while (client.GetClientShoppingCartCost() > client.Money)
                    {
                        Product deletedProduct = client.GetRandomProductFromShoppingCart();
                        Console.WriteLine($"Клиент убирате из корзины {deletedProduct.Name}");
                        client.DeleteProductFromShoppingCart(deletedProduct);
                    }
                }

                Console.WriteLine("Клиент расплачивается и уходит!");
                Console.WriteLine();
            }
        }
    }

    public class ClientQueue
    {
        private Queue<Client> _clients;
        private Random _random;
        private int _minNumberOfClients = 1;
        private int _maxNumberOfClients = 10;

        public ClientQueue()
        {
            _clients = new Queue<Client>();
            _random = new Random();

            for(int i = 0; i < _random.Next(_minNumberOfClients,_maxNumberOfClients); i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        public Client GetNewClient() => _clients.Dequeue();

        public int GetNumberOfClients() => _clients.Count;
    }

    public class Client
    {
        private ShoppingCart _shoppinCart;
        private Random _random;
        private int _minRandom = 0;
        private int _minNumbersOfProductsInshoppingCart = 1;
        private int _maxMoneyRandom = 300;
        public int Money { get; private set; }

        public Client()
        {
            _random = new Random();
            _shoppinCart = new ShoppingCart();

            _shoppinCart.AddManyProducts(_random.Next(_minNumbersOfProductsInshoppingCart, Product.NumbersOfProductTypes));

            Money = _random.Next(_minRandom, _maxMoneyRandom);
        }

        public int GetClientShoppingCartCost()
        {
            return _shoppinCart.HowCartAllProductsCost();
        }

        public void ShowClientShoppingCartProducts()
        {
            _shoppinCart.ShowAllProductsInfo();
        }

        public Product GetRandomProductFromShoppingCart()
        {
            return _shoppinCart.GetRandomProductFromCart();
        }

        public void DeleteProductFromShoppingCart(Product product)
        {
            _shoppinCart.DeleteProductFromCart(product);
        }
    }

    public class ShoppingCart
    {
        private List<Product> _productsInCart;
        private Random _random;
        private int _minRandomForCart = 0;

        public ShoppingCart()
        {
            _productsInCart = new List<Product>();
            _random = new Random();
        }

        public void AddNewProductInCart()
        {
            _productsInCart.Add(new Product());
        }

        public void AddManyProducts(int numberOfProducts)
        {
            for(int i = 0; i < numberOfProducts; i++)
            {
                AddNewProductInCart();
                System.Threading.Thread.Sleep(50);
            }
        }

        public void ShowAllProductsInfo()
        {
            foreach (Product product in _productsInCart)
            {
                Console.WriteLine(product.ShowProductInfo());
            }
        }

        public string ShowLastProductInCart()
        {
            return _productsInCart[_productsInCart.Count - 1].Name + " - " + _productsInCart[_productsInCart.Count - 1].Price;
        }

        public int HowCartAllProductsCost()
        {
            int allPrice = 0;

            foreach (Product product in _productsInCart)
            {
                allPrice += product.Price;
            }

            return allPrice;
        }

        public Product GetRandomProductFromCart()
        {
            int randomProductId = _random.Next(_minRandomForCart, _productsInCart.Count);
            Product randomProduct = _productsInCart[randomProductId];
            _productsInCart.RemoveAt(randomProductId);

            return randomProduct;
        }

        public void DeleteProductFromCart(Product product)
        {
            _productsInCart.Remove(product);
        }
    }

    public class Product
    {
        public const int NumbersOfProductTypes = 10;
        private Dictionary<string, int> _allProducts;
        private Random _random;
        private int _minRandom = 0;

        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product()
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

            _random = new Random();

            int randomProduct = _random.Next(_minRandom, _allProducts.Count);

            Name = _allProducts.Keys.ElementAt(randomProduct);
            Price = _allProducts.Values.ElementAt(randomProduct);
        }

        public string ShowProductInfo()
        {
            return Name + " " + Price;
        }
    }
}
