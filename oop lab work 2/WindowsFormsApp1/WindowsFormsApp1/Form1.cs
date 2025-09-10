using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly List<Planet> planets = new List<Planet>();

        public Form1()
        {
            InitializeComponent();
        }

        // Обробник кнопки "Додати"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо дані з форми
                string name = txtName.Text;
                double mass = double.Parse(txtMass.Text, CultureInfo.InvariantCulture);
                double diameter = double.Parse(txtDiameter.Text, CultureInfo.InvariantCulture);
                int satellites = int.Parse(txtSatellites.Text);

                // Створюємо планету
                Planet planet = new Planet(name, mass, diameter, satellites);

                // Додаємо у список
                planets.Add(planet);

                // Виводимо список у текстове поле
                txtOutput.Clear();
                foreach (var p in planets)
                {
                    txtOutput.AppendText(p.ToString() + Environment.NewLine);
                }

                // Очищаємо поля вводу
                txtName.Clear();
                txtMass.Clear();
                txtDiameter.Clear();
                txtSatellites.Clear();
            }
            catch
            {
                MessageBox.Show("Перевірте правильність введених даних!", "Помилка");
            }
        }
    }

    // Клас "Планета"
    public class Planet
    {
        public string Name { get; set; }      // Назва планети

        // Закриті поля
        private double mass;                  // маса (кг)
        private double diameter;              // діаметр (км)

        public int Satellites { get; set; }   // Кількість супутників

        // Конструктор
        public Planet(string name, double mass, double diameter, int satellites)
        {
            Name = name;
            this.mass = mass;
            this.diameter = diameter;
            Satellites = satellites;
        }

        // Методи доступу до маси
        public void SetMass(double value) => mass = value;
        public double GetMass() => mass;

        // Методи доступу до діаметра
        public void SetDiameter(double value) => diameter = value;
        public double GetDiameter() => diameter;

        // Метод для текстового виводу
        public override string ToString()
        {
            return $"{Name} | Маса: {mass:E2} кг | Діаметр: {diameter} км | Супутники: {Satellites}";
        }
    }
}
