using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_App_Lab1_test1
{
    /// <summary>
    /// Логика взаимодействия для PageGrid.xaml
    /// </summary>
    public partial class PageGrid : Page
    {
        private readonly TaxiContext context;
        //private readonly List<Order> _orders;
        private readonly IList<string> headers = new List<string>() { "Номер заказа", "Цена заказа", "Время заказа", "Дата заказа", "Номер клиента", "Номер водителя" };
        public PageGrid()
        {
            InitializeComponent();
            this.grid.Items.Clear();

            this.context = new TaxiContext();

            this.grid.ItemsSource = context.Orders.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => ResetHeaders();

        private void ResetHeaders()
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (headers.Count > i)
                    this.grid.Columns[i].Header = headers[i];
                else grid.Columns[i].Header = "";
            }
        }

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (var dbcontext = new TaxiContext())
            {
                this.grid.ItemsSource = dbcontext.Orders.ToList();

                ResetHeaders();
            }
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var item = (Order)grid.CurrentCell.Item;
            context.Orders.Add(new Order()
            {
                Date = item.Date,
                IdClient = item.IdClient,
                IdClientNavigation = item.IdClientNavigation,
                IdDriver = item.IdDriver,
                IdDriverNavigation = item.IdDriverNavigation,
                Price = item.Price,
                Time = item.Time
            });
        }

        private void CutCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var item = (Order)this.grid.SelectedItem;

            context.Orders.Update(item);
        }

        private async void SearchCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.SearchTextBox is null)
                this.grid.ItemsSource = context.Orders.ToList();
            else
            {
                var items = await this.context.Orders.
                    Where(i => EF.Functions.Like(i.Price!, $"%{this.SearchTextBox.Text}%")).ToListAsync();
                this.grid.ItemsSource = items;
                ResetHeaders();
            }
        }

        //Поиск

        private void textBox_TextChanged(Object sender, EventArgs e)
        {

            try
            {
                int.Parse(this.SearchTextBox.Text);
                this.SearchTextBox.Background = Brushes.White;
            }
            catch
            {
                this.SearchTextBox.Background = Brushes.Red;
            }

            if (this.SearchTextBox.Text == "")
            {
                this.SearchTextBox.Background = Brushes.White;
                this.grid.ItemsSource = context.Orders.ToList();
            }
            else
            {
                var items =  this.context.Orders.
                    Where(i => EF.Functions.Like(i.Price!, $"%{this.SearchTextBox.Text}%")).ToList();
                this.grid.ItemsSource = items;
            }
            ResetHeaders();
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            context.SaveChanges();
            this.grid.ItemsSource = context.Orders.ToList();
            ResetHeaders();
        }

        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.Orders.Remove((Order)this.grid.CurrentItem);
        }
    }
}

