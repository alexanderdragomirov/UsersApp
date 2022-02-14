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
using System.Windows.Media.Animation;


namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AppContext db;

        public MainWindow()
        {
            InitializeComponent();

            db=new AppContext();

            Button_Animation(regButton);
        }
        private static void Button_Animation(Button button)
        {
            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(0.4);
            button.BeginAnimation(Button.WidthProperty, btnAnimation);
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PasswordBox.Password.Trim();
            string pass_2 = PasswordBox2.Password.Trim();
            string email = TextBoxEmail.Text.ToLower().Trim();

            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Это поле введено не корректно.";
                TextBoxLogin.Background = Brushes.LightPink;
            }
            else if (pass.Length < 5)
            {
                PasswordBox.ToolTip = "Это поле введено не корректно.";
                PasswordBox.Background = Brushes.LightPink;
            }
            else if (pass != pass_2)
            {
                PasswordBox2.ToolTip = "Пароли не совпадают.";
                PasswordBox2.Background = Brushes.LightPink;
            }
            else if (email.Length < 6 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "Это поле введено не корректно";
                TextBoxEmail.Background=Brushes.LightPink;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PasswordBox.ToolTip = "";
                PasswordBox.Background = Brushes.Transparent;
                PasswordBox2.ToolTip = "";
                PasswordBox2.Background = Brushes.Transparent;
                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Успешно.");

                User user = new User(login,pass,email);
                db.Users.Add(user);
                db.SaveChanges();
                this.Button_WinAuth_Click(sender, e);
            }
        }

        private void Button_WinAuth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow=new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
