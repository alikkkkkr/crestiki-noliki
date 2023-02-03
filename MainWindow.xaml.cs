using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml.Linq;

namespace prac1sharp
{
    public partial class MainWindow : Window
    {
        private bool enable = false;
        string xo;
        string robot_xo = "";
        Random random = new();
        List<Button> buttons = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            buttons.Add(but1);
            buttons.Add(but2);
            buttons.Add(but3);
            buttons.Add(but4);
            buttons.Add(but5);
            buttons.Add(but6);
            buttons.Add(but7);
            buttons.Add(but8);
            buttons.Add(but9);
            but1.IsEnabled = enable;
            but2.IsEnabled = enable;
            but3.IsEnabled = enable;
            but4.IsEnabled = enable;
            but5.IsEnabled = enable;
            but6.IsEnabled = enable;
            but7.IsEnabled = enable;
            but8.IsEnabled = enable;
            but9.IsEnabled = enable;
            int value_value;
            value_value = random.Next(0, 2);
            if (value_value == 1)
            {
                MessageBox.Show($"бэмс, выпало {value_value}, занчит ты за O");
                xo = "X";
            }
            else
            {
                MessageBox.Show($"чикс, выпало {value_value}, занчит ты за X");
                xo = "O";
            }
            zanovo.IsEnabled = enable;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = xo;
            (sender as Button).IsEnabled = false;
            if (Winer() != "") { textblock.Text = "виыграл - " + Winer(); ssilka_zanovo(); }
            else Robot();
        }
        private void sysBut_Click(object sender, RoutedEventArgs e)
        {
            if (sysBut != null)
            {
                enable = true;
                but1.IsEnabled = enable;
                but2.IsEnabled = enable;
                but3.IsEnabled = enable;
                but4.IsEnabled = enable;
                but5.IsEnabled = enable;
                but6.IsEnabled = enable;
                but7.IsEnabled = enable;
                but8.IsEnabled = enable;
                but9.IsEnabled = enable;
                zanovo.IsEnabled = enable;
            }
            sysBut.IsEnabled = false;
        }

        private void ssilka_zanovo()
        {
            but1.Content = "";
            but2.Content = "";
            but3.Content = "";
            but4.Content = "";
            but5.Content = "";
            but6.Content = "";
            but7.Content = "";
            but8.Content = "";
            but9.Content = "";
            if (xo == "X") xo = "O";
            else if (xo == "O") xo = "X";
            sysBut.IsEnabled = false;
            enable = true;
            but1.IsEnabled = enable;
            but2.IsEnabled = enable;
            but3.IsEnabled = enable;
            but4.IsEnabled = enable;
            but5.IsEnabled = enable;
            but6.IsEnabled = enable;
            but7.IsEnabled = enable;
            but8.IsEnabled = enable;
            but9.IsEnabled = enable;
            zanovo.IsEnabled = enable;
        }

        private void zanovo_Click(object sender, RoutedEventArgs e)
        {
            ssilka_zanovo();
        }

        private void Robot()
        {
            
            string robot_xo = "";
            if (xo == "X") { robot_xo = "O"; }
            else robot_xo = "X";

            List<Button> butti = new List<Button>() { };
            foreach (Button button in buttons)
            {
                if (button.IsEnabled)
                    butti.Add(button);
            }
            if (butti.Count == 0) {textblock.Text = "ничья, братан"; ssilka_zanovo(); }
            else
            {
                int bot = random.Next(butti.Count);
                butti[bot].Content = robot_xo;
                butti[bot].IsEnabled = false;
                if (Winer() != "") { textblock.Text = "виыграл - " + Winer(); ssilka_zanovo(); }
            }
        }

        private string Winer()
        {
            string win = "";
            if ((but1.Content == but2.Content) && (but2.Content == but3.Content) && (but3.Content!= "")) win = (string)but3.Content;
            else if (but4.Content == but5.Content && but6.Content == but5.Content && but5.Content != "") win = (string)but6.Content;
            else if (but7.Content == but8.Content && but9.Content == but8.Content && but8.Content != "") win = (string)but9.Content;
            else if (but1.Content == but5.Content && but9.Content == but5.Content && but5.Content != "") win = (string)but9.Content;
            else if (but7.Content == but5.Content && but3.Content == but5.Content && but5.Content != "") win = (string)but3.Content;
            else if (but1.Content == but4.Content && but7.Content == but4.Content && but4.Content != "") win = (string)but7.Content;
            else if (but2.Content == but5.Content && but8.Content == but5.Content && but5.Content != "") win = (string)but8.Content;
            else if (but3.Content == but6.Content && but9.Content == but6.Content && but6.Content != "") win = (string)but9.Content;

            //if (win == xo) win = "ты выиграл, красавчик!";
            //else if (win == robot_xo) win = "бот выиграл, ты лох";
            return win;
        }
    }
}