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
        int nbFamilier = 10;
        int pos = 0;
        int pos2 = 0;
        string familier = "Chacha";

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
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1290), convertpixel.ConvertPixelX(140));// Selection "tous" les object pour permetre de rechercher plus facilement les familiers.
            Thread.Sleep(200);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(500);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1340), convertpixel.ConvertPixelX(809));// Selection la barre de recherche dans l'inventaire. 
            Thread.Sleep(200);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(500);
            souris.Keyboard.TextEntry(familier);
            Thread.Sleep(500);
            for (int i = 1; i <= nbFamilier; i++)
            {

                SelectionFamilierFiveFirstCase(pos);
                Thread.Sleep(500);
                souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1600), convertpixel.ConvertPixelX(240));// Selectionne la nourriture 
                Thread.Sleep(500);
                souris.Mouse.LeftButtonClick();
                Thread.Sleep(500);
                SelectionNouriture();
                souris.Mouse.LeftButtonDoubleClick();
                Thread.Sleep(500);
                pos = pos + 60;


                if (i > 5)
                {
                    for (i; i <= 10; i++)
                    {
                        SelectionFamilierFiveSecondCase(pos2);
                        Thread.Sleep(500);
                        souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1610), convertpixel.ConvertPixelX(317));// Selectionne la nourriture 
                        Thread.Sleep(500);
                        souris.Mouse.LeftButtonClick();
                        Thread.Sleep(500);
                        SelectionNouriture();
                        souris.Mouse.LeftButtonDoubleClick();
                        Thread.Sleep(500);
                        pos2 = pos2 + 60;
                    }

                }
            }

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
            Thread.Sleep(500);
        }
        private void SelectionFamilierFiveFirstCase(int position)
        {
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1285 + position), convertpixel.ConvertPixelX(210));// Position du pet 
            Thread.Sleep(500);
            souris.Mouse.RightButtonClick();
            Thread.Sleep(500);

        }
        private void SelectionFamilierFiveSecondCase(int position)
        {

            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1285 + position), convertpixel.ConvertPixelX(270));// Position du pet
            Thread.Sleep(500);
            souris.Mouse.RightButtonClick();
            Thread.Sleep(500);

        }

    }
}
