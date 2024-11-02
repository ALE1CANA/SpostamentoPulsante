using System.Drawing.Text;

namespace SpostamentoPulsante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Button nuovo = new Button();
            nuovo.Size = new Size(20, 20);
            nuovo.Text = "";
            int y = ClientSize.Height / 2 - nuovo.Height / 2;
            int x = this.ClientSize.Width / 2 - nuovo.Width / 2;
            nuovo.Location = new Point(x, y);
            this.Controls.Add(nuovo);

            Thread sinistra = new Thread(spostaSX);
            sinistra.Start(nuovo);

            Thread destra = new Thread(spostaDX);
            destra.Start(nuovo);

            destra.Join();
            sinistra.Join();
        }

        public void spostaDX(object nuovo)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int time = 0;
            int nuovaPosizione = 0;
            while (nuovaPosizione < ClientSize.Width)
            {
                Button button1 = (Button)nuovo;
                nuovaPosizione = button1.Location.X + 10;
                button1.Location = new Point(nuovaPosizione, button1.Location.Y);
                time = rnd.Next(0, 50);
                Thread.Sleep(time);
            }
            MessageBox.Show("Hai Vinto!!!!");

        }

        public void spostaSX(object nuovo)
        {
            int time = 0;
            Random rnd = new Random(DateTime.Now.Millisecond);
            Button button1 = (Button)nuovo;
            int nuovaPosizione = button1.Location.X - 10; ;
            while (nuovaPosizione > 0)
            {
                nuovaPosizione = button1.Location.X - 10;
                button1.Location = new Point(nuovaPosizione, button1.Location.Y);
                time = rnd.Next(0, 50);
                Thread.Sleep(time);
            }
            MessageBox.Show("Hai Vinto!!!!");
        }
    }
}