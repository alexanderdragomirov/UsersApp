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
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            Button_Animation(authButton);
        }

        private static void Button_Animation(Button button)
        {
            DoubleAnimation authAnimation = new DoubleAnimation();
            authAnimation.From = 0;
            authAnimation.To = 450;
            authAnimation.Duration = TimeSpan.FromSeconds(0.4);
            button.BeginAnimation(Button.WidthProperty, authAnimation);
        }
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PasswordBox.Password.Trim();

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
            else 
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PasswordBox.ToolTip = "";
                PasswordBox.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext context=new AppContext())
                {
                    authUser = context.Users.Where(b=>b.Login==login && b.Password==pass).FirstOrDefault();
                    
                }
                if (authUser!=null)
                {
                    MessageBox.Show("Успешно.");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Close();

                }
                else
                {
                    MessageBox.Show("Что-то не корректно");
                }
                

            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow=new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
