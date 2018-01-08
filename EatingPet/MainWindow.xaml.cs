using EatingPet.InfoUsefull;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using WindowsInput;
using EatingPet.Converter;

namespace EatingPet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InputSimulator souris = new InputSimulator();
        UserInfo infoUser = new UserInfo();
        ConverterPixels convertpixel = new ConverterPixels();
        int nbFamilier = 5;
        int pos = 0;

        string cheminFichierMotDePasse;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Process.Start(@"C:\Users\Pierre\AppData\Local\Ankama\Dofus\app\Dofus.exe");//Chemin de l'application dofus sans le launcher. 

            Thread.Sleep(10000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            souris.Keyboard.TextEntry(infoUser.Fichier(cheminFichierMotDePasse)); // Mot de passe
            Thread.Sleep(2000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(2000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(15000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_I);
            Thread.Sleep(500);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1199), convertpixel.ConvertPixelX(122));
            Thread.Sleep(200);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(300);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1335), convertpixel.ConvertPixelX(809));
            Thread.Sleep(200);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(300);
            for (int i = 0; i < nbFamilier; i++)
            {
                SelectionFamilierFiveSecondeCase("Chacha", pos);
                souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1500), convertpixel.ConvertPixelX(236));
                Thread.Sleep(300);
                souris.Mouse.LeftButtonClick();
                Thread.Sleep(300);
                SelectionNouriture();
                souris.Mouse.LeftButtonDoubleClick();
                Thread.Sleep(300);
                pos = pos + 60;
                if (nbFamilier > 5)
                {

                }
            }




            //Thread.Sleep(300);
            //Thread.Sleep(300);
            //Thread.Sleep(300);
            //Thread.Sleep(300);
            //Thread.Sleep(300);
            //Thread.Sleep(300);


        }

        private void ButtonPasseWord_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.ShowDialog();

            cheminFichierMotDePasse = openFileDialog.FileName;
        }
        private void SelectionNouriture()
        {
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(733), convertpixel.ConvertPixelX(327));
            Thread.Sleep(300);
        }
        private void SelectionFamilierFiveSecondeCase(string familier, int position)
        {
            souris.Keyboard.TextEntry(familier);
            Thread.Sleep(300);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1300 + position), convertpixel.ConvertPixelX(200));
            Thread.Sleep(300);
            souris.Mouse.RightButtonClick();
            Thread.Sleep(300);

        }
        private void SelectionFamilierFiveThirdCase(string familier, int position)
        {
            souris.Keyboard.TextEntry(familier);
            Thread.Sleep(300);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1300 + position), convertpixel.ConvertPixelX(200));
            Thread.Sleep(300);
            souris.Mouse.RightButtonClick();
            Thread.Sleep(300);

        }
        private void SelectionFamilierFiveFirstCase(string familier, int position)
        {
            souris.Keyboard.TextEntry(familier);
            Thread.Sleep(300);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1300 + position), convertpixel.ConvertPixelX(200));
            Thread.Sleep(300);
            souris.Mouse.RightButtonClick();
            Thread.Sleep(300);

        }
    }
}
