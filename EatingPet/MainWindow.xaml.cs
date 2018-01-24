using EatingPet.InfoUsefull;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using WindowsInput;
using EatingPet.Converter;
using System;
using System.Collections.Generic;
using WPFNotification.Services;
using WPFNotification.Model;

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
        List<string> FamilierDe5Heures = new List<string>();
        string[] Familier5heures = { "ChaCha", "Bwork", "Vilain" };
        int[] NbFamilierParNom = { 10, 25, 15 };
        Random deplacementClick = new Random();


        int posx = 1270;
        int posy = 215;
        int posxNouriture = 1350;
        int posyNouriture = 250;
        int nbBoucle = 0;
        int nourritureFamilier = 10;

        string cheminFichierMotDePasse = @"C:\Users\Pierre\Desktop\PasswordDofus.txt";
        string cheminDofus;

        public MainWindow()
        {
            var nbRandom = deplacementClick.Next(500, 1500);

            InitializeComponent();
            Process NourrirePet = Process.Start(@"C:\Users\Pierre\AppData\Local\Ankama\Dofus\app\Dofus.exe");//Chemin de l'application dofus sans le launcher. 
            INotificationDialogService notificationNourritureFamilier = new NotificationDialogService();
            Thread.Sleep(10000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(nbRandom);
            souris.Keyboard.TextEntry(infoUser.Fichier(cheminFichierMotDePasse)); // mot de passe
            Thread.Sleep(5000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(2000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(2000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(20000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_I);
            Thread.Sleep(nbRandom);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1267), convertpixel.ConvertPixelX(137));// Selection "tous" les object pour permetre de rechercher plus facilement les familiers.
            Thread.Sleep(nbRandom);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(nbRandom);

            for (int z = 0; z < Familier5heures[z].Length; z++)
            {
                RechercheFamilier();
                souris.Mouse.LeftButtonDoubleClick();
                Thread.Sleep(nbRandom);
                souris.Keyboard.TextEntry(Familier5heures[z]);
                Thread.Sleep(nbRandom);
                for (int i = 0; i < NombreDeLignes(NbFamilierParNom[z]); i++)
                {

                    for (int j = 0; j < 5 && i * 5 + j < NbFamilierParNom[z]; j++)
                    {
                        Nourrir(posx, posy, posxNouriture, posyNouriture);

                        posx += 60;
                        posxNouriture += 60;
                        Thread.Sleep(nbRandom);
                    }
                    posx -= 300;
                    posxNouriture -= 300;

                    posy += 60;
                    posyNouriture += 60;

                }
                nbBoucle += 1;
                posx = 1270;
                posy = 215;
                posxNouriture = 1350;
                posyNouriture = 250;

            }
            for (int i = 0; i < NbFamilierParNom.Length; i++)
            {
                if ((NbFamilierParNom[i] * 4) < 10)
                {
                    Notification.Program.Main();
                }
            }
            QuitterApplication();

            NourrirePet.Kill();


        }
        private void QuitterApplication()
        {
            souris.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.MENU, WindowsInput.Native.VirtualKeyCode.F4);
            Thread.Sleep(500);
        }

        private void RechercheFamilier()
        {
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1340), convertpixel.ConvertPixelX(811));// Selection la barre de recherche dans l'inventaire. 
            Thread.Sleep(200);
        }

        public void Nourrir(int posX, int posY, int posXNouriture, int posYNouriture)
        {
            var nbRandom = deplacementClick.Next(500, 2000);

            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(posX), convertpixel.ConvertPixelX(posY));
            Thread.Sleep(nbRandom);
            souris.Mouse.RightButtonClick();
            Thread.Sleep(nbRandom);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(posXNouriture), convertpixel.ConvertPixelX(posYNouriture));
            Thread.Sleep(nbRandom);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(nbRandom);
            SelectionNouriture();
            souris.Mouse.LeftButtonDoubleClick();
            Thread.Sleep(nbRandom);
        }
        private void SelectionNouriture()
        {
            var nbRandom = deplacementClick.Next(1000, 1500);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(730), convertpixel.ConvertPixelX(330));
            Thread.Sleep(nbRandom);
        }

        public decimal NombreDeLignes(int nbFamilier)
        {
            decimal floatNbFamilier = nbFamilier / 5;
            return Math.Ceiling(floatNbFamilier);
        }

        private void ButtonPasseWord_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.ShowDialog();

            cheminFichierMotDePasse = openFileDialog.FileName;
        }
        private void ButtonPasseWord_Click2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.ShowDialog();

            cheminDofus = openFileDialog.FileName;
        }

    }



}




