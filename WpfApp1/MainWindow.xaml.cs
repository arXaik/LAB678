using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LabTasks
{
    public partial class MainWindow : Window
    {
        private Stack<Product> productStack;

        public MainWindow()
        {
            InitializeComponent();
            productStack = new Stack<Product>();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = productNameTextBox.Text;
            decimal price = decimal.Parse(priceTextBox.Text);

            Product newProduct = new Product(productName, price);
            productStack.Push(newProduct);

            productNameTextBox.Clear();
            priceTextBox.Clear();
        }

        private void ViewData_Click(object sender, RoutedEventArgs e)
        {
            string data = "Данные стека:\n";
            foreach (var product in productStack)
            {
                data += $"Наименование товара: {product.ProductName}, Цена: {product.Price}\n";
            }
            decimal averagePrice = productStack.Any() ? productStack.Average(p => p.Price) : 0;
            averagePriceTextBlock.Text = $"Средняя цена товаров: {averagePrice}";
        }


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(nTextBox.Text);

            double result = CalculateExpression(n);

            resultTextBlock.Text = $"Результат: {result}";
        }

        private void CalculateSum_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = matrixTextBox.Text.Split('\n');
            int rows = lines.Length;
            int columns = lines[0].Split(' ').Length;

            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }

            int sum = CalculateMatrixSum(matrix);

            sumResultTextBlock.Text = $"Сумма элементов в интервале [-2; 3]: {sum}";
        }

        private void CalculateTimeDifference_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan time1 = TimeSpan.Parse(time1TextBox.Text);
            TimeSpan time2 = TimeSpan.Parse(time2TextBox.Text);

            int differenceInMinutes = CalculateTimeDifference(time1, time2);

            timeDifferenceTextBlock.Text = $"Разница в минутах: {differenceInMinutes}";
        }

        private int Factorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        private double CalculateExpression(int n)
        {
            int factorial5 = Factorial(5);
            int factorial8 = Factorial(8);
            int factorial6 = Factorial(6);
            int factorial4 = Factorial(4);

            double result = (2 * factorial5 + 3 * factorial8) / (double)(factorial6 + factorial4);
            return result;
        }

        private int CalculateMatrixSum(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int element = matrix[i, j];
                    if (element >= -2 && element <= 3)
                    {
                        sum += element;
                    }
                }
            }

            return sum;
        }

        private int CalculateTimeDifference(TimeSpan time1, TimeSpan time2)
        {
            TimeSpan difference = time2 - time1;
            int differenceInMinutes = (int)difference.TotalMinutes;
            return Math.Abs(differenceInMinutes);
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Product(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }
    }
}
