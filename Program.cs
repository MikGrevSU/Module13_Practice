using System;

enum CustomerType
{
    New,
    Regular,
    Loyal
}

enum PaymentMethod
{
    Card,
    KaspiQR,
    Cash
}

class Order
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public CustomerType Customer { get; set; }
    public PaymentMethod Payment { get; set; }
    public decimal Discount { get; private set; }
    public bool PaymentSuccessful { get; private set; }

    public void ApplyDiscount()
    {
        switch (Customer)
        {
            case CustomerType.New:
                Discount = 0.15m;
                break;
            case CustomerType.Loyal:
                Discount = 0.07m;
                break;
            default:
                Discount = 0;
                break;
        }
        Console.WriteLine($"Применена скидка: {Discount * 100}%");
    }

    public void MakePayment()
    {
        Console.WriteLine($"Выберите способ оплаты: 1-Карта, 2-Kaspi QR, 3-Наличные");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Payment = PaymentMethod.Card;
                break;
            case "2":
                Payment = PaymentMethod.KaspiQR;
                break;
            case "3":
                Payment = PaymentMethod.Cash;
                break;
            default:
                Console.WriteLine("Неверный выбор. Оплата не прошла.");
                PaymentSuccessful = false;
                return;
        }

        // Симуляция успешной оплаты
        PaymentSuccessful = true;
        Console.WriteLine($"Оплата выполнена через {Payment}. Сумма к оплате: {Price * (1 - Discount):F2} тенге.");
    }

    public void ProcessOrder()
    {
        if (!PaymentSuccessful)
        {
            Console.WriteLine("Оплата не прошла. Заказ отменен.");
            return;
        }
        Console.WriteLine("Заказ обрабатывается на складе...");
        Console.WriteLine("Заказ отправлен покупателю.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();

        Console.WriteLine("Введите название товара:");
        order.ProductName = Console.ReadLine();

        Console.WriteLine("Введите цену товара:");
        order.Price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Выберите тип покупателя: 1-Новый, 2-Обычный, 3-Постоянный");
        string type = Console.ReadLine();
        switch (type)
        {
            case "1":
                order.Customer = CustomerType.New;
                break;
            case "2":
                order.Customer = CustomerType.Regular;
                break;
            case "3":
                order.Customer = CustomerType.Loyal;
                break;
            default:
                order.Customer = CustomerType.Regular;
                break;
        }

        order.ApplyDiscount();
        order.MakePayment();
        order.ProcessOrder();

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
