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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var pass = password.Text;

            var email = emailTB.Text;
            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null) 
            {
                MessageBox.Show("Такой пользователь уже зарегестрирован");
                return;
            }
            var user = new User { Login = login, Email = email, Password = pass }; 
            context.Users.Add(user);   
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались");
        }
    }
}
