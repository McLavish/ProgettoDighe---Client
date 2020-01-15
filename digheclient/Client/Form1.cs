using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        const int allertaVerde = 60 * 60 * 1000;
        const int allertaGialla = 30 * 60 * 1000;
        const int allertaRossa = 10 * 60 * 1000;

        float allarmeVerde;
        float allarmeGiallo;
        float allarmeRosso;

        string path = "./misurazioni.txt";

        float ultimoValore;
        DateTime ultimaRicezione = DateTime.Now;

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] serialPort = SerialPort.GetPortNames();

            try
            {
                router.PortName = serialPort[0];
                ultrasuoni.PortName = serialPort[1];

                router.Open();
                ultrasuoni.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Errore durante la connessione: \r\n" + exc.Message);
                return;
            }

            controlloPeriodico.Interval = allertaVerde;

            string valori = "";

            if (!File.Exists(path))
            {
                Task.Run(() =>
                {
                    Invoke(new Action(() =>
                    {
                        lblAttesa.Visible = true;
                    }));

                    do
                    {
                        lock (router)
                        {
                            router.WriteLine(@"AT+CMGF=1" + (char)13);
                            router.WriteLine(@"AT+CMGL=""rec unread""" + (char)13);
                            Thread.Sleep(2000);

                            valori = router.ReadExisting();
                        }
                    } while (valori == "");

                    Invoke(new Action(() =>
                    {
                        lblAttesa.Visible = false;

                        controlloPeriodico.Enabled = true;
                        controlloPeriodico.Start();

                    }));


                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    FileStream fs = File.Create(path);
                    AddText(fs, valori);
                    fs.Close();


                    Parse(valori);
                });
            }

            
        }

        public void Parse(string messaggio)
        {
            messaggio = messaggio.Split(',')[5].Substring(15).Trim();
            allarmeVerde = float.Parse(messaggio.Split('/')[0]);
            allarmeGiallo = float.Parse(messaggio.Split('/')[1]);
            allarmeRosso = float.Parse(messaggio.Split('/')[2]);
        }

        private void ultrasuoni_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ultimoValore = float.Parse(ultrasuoni.ReadExisting());

            if (ultimoValore >= allarmeVerde && ultimoValore < allarmeGiallo)
            {
                controlloPeriodico.Interval = allertaVerde;
                picColor.BackColor = Color.Green;
            }
            else if (ultimoValore >= allarmeGiallo && ultimoValore < allarmeRosso)
            {
                controlloPeriodico.Interval = allertaGialla;
                picColor.BackColor = Color.Yellow;
            }
            else
            {
                controlloPeriodico.Interval = allertaRossa;
                picColor.BackColor = Color.Red;
            }

            ultimaRicezione = DateTime.Now;
        }

        private void controlloPeriodico_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - ultimaRicezione).TotalMinutes >= 60)
            {
                try
                {
                    ultimoValore = float.Parse(ultrasuoni.ReadExisting());
                    ultimaRicezione = DateTime.Now;
                    router.WriteLine(ultimoValore.ToString() + '\r');
                }
                catch (Exception ex)
                {
                    router.WriteLine(ex.Message + '\r');
                    txtErrori.Text += ex.Message + "\r\n";
                }
            }

            router.WriteLine(ultimoValore.ToString() + '\r');
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
