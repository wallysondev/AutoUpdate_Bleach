using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace AutoUpdate_Bleach
{
    //Lembrar de colocar o arquivo version.json no googledrive, compartilhar este arquivo para qualquer pessoa com o link
    //depois ir no site https://sites.google.com/site/gdocs2direct/ e gerar um link direto atraves dele.
    //para atualizar as versões basta ir no google drive e ir na opcao controle de versao, Lembre também de colocar os arquivos compartilhados lá.

    enum LauncheStatus
    {
        Verify,
        Failed,
        Update,
        Extract,
        Complete
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient cliente;
        DateTime TickCount;
        short currentdownload;

        Version localversion;
        Version onlineversion;

        private string rootPath;
        private string versionFile;
        private string downloadurl;
        private string Jsonstring;

        private LauncheStatus _status;
        internal LauncheStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                switch (_status) 
                {
                    case LauncheStatus.Verify:
                        lblProgress.Content = "Verificando...";
                        break;
                    case LauncheStatus.Failed:
                        lblProgress.Content = "Erro!";
                        break;
                    case LauncheStatus.Update:
                        lblProgress.Content = "Baixando...";
                        break;
                    case LauncheStatus.Extract:
                        lblProgress.Content = "Instalando...";
                        break;
                    case LauncheStatus.Complete:
                        lblProgress.Content = "Concluido!";
                        break;
                    default:
                        break;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            rootPath = Environment.CurrentDirectory;
            versionFile = Path.Combine(rootPath, "Version.json");
            downloadurl = "https://drive.google.com/uc?export=download&id=";
        }
        #region Buttons window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnStopDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            RunAutoUpdate();
        }
        #endregion

        private void RunAutoUpdate()
        {
            try
            {
                TickCount = DateTime.Now;

                // instancia o cliente web
                cliente = new WebClient();
                cliente.DownloadProgressChanged += Cliente_DownloadProgressChanged;
                cliente.DownloadFileCompleted += Cliente_DownloadFileCompleted;

                // Baixa as informacoes da versão diretamente do site
                Jsonstring = cliente.DownloadString("https://download1496.mediafire.com/5h5dr9jdjf6g/ohe1blhnn6e9w1b/Version.json");

                // Trás os valores para a variavel depois de recuperar do download
                onlineversion = JsonConvert.DeserializeObject<Version>(Jsonstring);

                if (File.Exists(versionFile))
                {
                    // recupera a informacao do json na pasta do update
                    Jsonstring = ModelJson.ReadJSON("Version");

                    // Atribui as informacoes do json local na variavel localversion
                    localversion = JsonConvert.DeserializeObject<Version>(Jsonstring);

                    // Substitui os valores encontrados no arquivo local pelo arquivo online
                    for (int newversion = 0; newversion <= onlineversion.MaxFiles; newversion++)
                    {
                        for (int oldversion = 0; oldversion <= localversion.MaxFiles; oldversion++)
                        {
                            if (newversion <= localversion.MaxFiles)
                            {
                                localversion.Files[oldversion] = onlineversion.Files[newversion];
                                break;
                            }
                        }
                    }
                }
                else
                {
                    localversion = new Version();
                }

                for (int newversion = 0; newversion <= onlineversion.MaxFiles; newversion++)
                {
                    // Realiza o download dos arquivos pegando a informacao diretamente do arquivo online
                    GetUpdateFiles(true, onlineversion.Files[newversion]);
                }
            }
            catch (Exception ex)
            {
                Status = LauncheStatus.Failed;
                MessageBox.Show($"Erro ao verificar atualizacoes {ex.Message}");
            }
        }

        private void GetUpdateFiles(bool _IsUpdate,FileVersion _fileversion)
        {
            try
            {
                cliente = new WebClient();
                cliente.DownloadProgressChanged += Cliente_DownloadProgressChanged;
                cliente.DownloadFileCompleted += Cliente_DownloadFileCompleted;

                if (_IsUpdate)
                {
                    Status = LauncheStatus.Update;
                    cliente.DownloadFileAsync(new Uri("https://download2390.mediafire.com/amz5fgjz391g/vgopeg6p19u6pa9/VEGAS+PRO+17.0.0.284.rar"), "VEGASPRO.rar", _fileversion);
                }
                else
                {
                    Status = LauncheStatus.Verify;

                    // Recupera as informacoes do arquivo json baixado
                    Jsonstring = cliente.DownloadString("https://download1496.mediafire.com/5h5dr9jdjf6g/ohe1blhnn6e9w1b/Version.json");

                    // Trás os valores para a variavel depois de recuperar do download
                    Version onlineversion = JsonConvert.DeserializeObject<Version>(Jsonstring);
                }
            }
            catch (Exception ex)
            {
                Status = LauncheStatus.Failed;
                MessageBox.Show($"Erro ao verificar atualizacoes {ex.Message}");
            }
        }

        #region Downloads Progress
        private void Cliente_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //lblcurrent.Text = currentdownload.ToString();
        }

        private void Cliente_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double receive = double.Parse(e.BytesReceived.ToString());
            double total = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = receive / total * 100;
            double downloaded = ((receive / 1024) / 1024); // baixado ate o momento
            double totaldownload = ((total / 1024) / 1024); // total a baixar

            //double speed = Math.Round(((receive / 1024) / (Environment.TickCount - TickCount)), 2);

            var elapsedTime = (DateTime.Now - TickCount).TotalSeconds;
            var allTimeFordownloading = (elapsedTime * e.TotalBytesToReceive / e.BytesReceived);
            var remainingTime = allTimeFordownloading - elapsedTime;
            TimeSpan time = TimeSpan.FromSeconds(remainingTime);
            lblTimer.Content = time.ToString(@"hh\:mm\:ss");

            //Progress.Value = e.ProgressPercentage;

            //lblSpeed.Text = $"{string.Format("{0:0.##}", speed)}";
            //txtProgress.Text = $"Fazendo o download de {filedownloadname} ";
            //lblDownloader.Text = $"Total baixado {string.Format("{0:0.##}", percentage)}% ";
            ProgressBarDinamic.Value = int.Parse(Math.Truncate(percentage).ToString());
            lblFilevalue.Content = Math.Round(downloaded, 2) + "MB / " + Math.Round(totaldownload, 2) + "MB";

            if (((receive / 1024f) / elapsedTime) < 1024)
                lblFilevalue.Content += string.Format(" {0} Kbps", Math.Round(((receive / 1024f) / elapsedTime),2));
            else
                lblFilevalue.Content += string.Format(" {0} Mbps", Math.Round((((receive / 1024f) / 1024f) / elapsedTime),2));
        }

        #endregion
    }
}
