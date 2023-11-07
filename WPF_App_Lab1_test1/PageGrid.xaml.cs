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
        private readonly List<Order> _orders;
        private readonly IList<string> headers = new List<string>(){"Номер заказа","Цена заказа","Время заказа","Дата заказа","Номер клиента","Номер водителя", "Номер водителя", "Номер водителя", "Номер водителя" };
        public PageGrid()
        {
            InitializeComponent();

            this.grid.Items.Clear();

            


            using (var dbcontext = new TaxiContext())
                this._orders = dbcontext.Orders.ToList();
            


            this.grid.ItemsSource = _orders;



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResetHeaders();
        }

        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (var dbcontext = new TaxiContext())
            {
                dbcontext.Orders.Remove((Order)this.grid.CurrentCell.Item);
                dbcontext.SaveChanges();
            }
        }

        private void ResetHeaders(){
            for (int i = 0; i < this.grid.Columns.Count(); i++){
                this.grid.Columns[i].Header = headers[i];
            }
        }

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (var dbcontext = new TaxiContext())
            {
                this.grid.ItemsSource = dbcontext.Orders.ToList();

                ResetHeaders();
                // try {
                //     var product = (Order)this.grid.CurrentCell.Item;
                //     var old_product = dbcontext.Orders.Where(i => i.IdOrder == product.IdOrder).FirstOrDefault();
                    
                //     var old_grid = this.grid.Items[this.grid.SelectedIndex];

                // }
                // catch(Exception ex){
                //     MessageBox.Show("Ошибка","Выбранного элемента не существует");
                // }
            }
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (var dbcontext = new TaxiContext())
            { 
                dbcontext.Orders.Add((Order)this.grid.CurrentCell.Item);
                dbcontext.SaveChanges();
            }
        }

        private void CutCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SearchCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}

