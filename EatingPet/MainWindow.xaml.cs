using EatingPet.InfoUsefull;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using WindowsInput;
using EatingPet.Converter;
using System;
using System.Collections.Generic;

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
        string[] Familier5heures = { "ChaCha", "Bwork", "ChienChien" };
        int[] NbFamilierParNom = { 5, 20, 12 };

        int posx = 1240;
        int posy = 235;
        int posxNouriture = 1300;
        int posyNouriture = 270;

        string cheminFichierMotDePasse = @"C:\Users\Pierre\Desktop\PasswordDofus.txt";
        public MainWindow()
        {
            InitializeComponent();
            Process.Start(@"C:\Users\Pierre\AppData\Local\Ankama\Dofus\app\Dofus.exe");//Chemin de l'application dofus sans le launcher. 

            Thread.Sleep(10000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            souris.Keyboard.TextEntry(infoUser.Fichier(cheminFichierMotDePasse)); // Mot de passe
            Thread.Sleep(2000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(2000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(20000);
            souris.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_I);
            Thread.Sleep(500);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1240), convertpixel.ConvertPixelX(155));// Selection "tous" les object pour permetre de rechercher plus facilement les familiers.
            Thread.Sleep(200);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(500);

            for (int z = 0; z < Familier5heures.Length; z++)
            {
                RechercheFamilier();
                souris.Mouse.LeftButtonDoubleClick();
                Thread.Sleep(500);
                souris.Keyboard.TextEntry(Familier5heures[z]);
                Thread.Sleep(500);

                for (int i = 0; i < NombreDeLignes(NbFamilierParNom[z]); i++)
                {

                    for (int j = 0; j < 5 && i * 5 + j < NbFamilierParNom[z]; j++)
                    {
                        Nourrir(posx, posy, posxNouriture, posyNouriture);

                        posx += 60;
                        posxNouriture += 60;
                        Thread.Sleep(500);
                    }
                    posx -= 300;
                    posxNouriture -= 300;

                    posy += 60;
                    posyNouriture += 60;

                }

                posx = 1240;
                posy = 235;
                posxNouriture = 1300;
                posyNouriture = 270;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {




        }

        private void RechercheFamilier()
        {
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(1290), convertpixel.ConvertPixelX(830));// Selection la barre de recherche dans l'inventaire. 
            Thread.Sleep(200);
        }

        public void Nourrir(int posX, int posY, int posXNouriture, int posYNouriture)
        {
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(posX), convertpixel.ConvertPixelX(posY));
            Thread.Sleep(500);
            souris.Mouse.RightButtonClick();
            Thread.Sleep(500);
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(posXNouriture), convertpixel.ConvertPixelX(posYNouriture));
            Thread.Sleep(500);
            souris.Mouse.LeftButtonClick();
            Thread.Sleep(500);
            SelectionNouriture();
            souris.Mouse.LeftButtonDoubleClick();
            Thread.Sleep(500);
        }
        private void SelectionNouriture()
        {
            souris.Mouse.MoveMouseTo(convertpixel.ConvertPixelY(730), convertpixel.ConvertPixelX(330));
            Thread.Sleep(500);
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

    }



}

