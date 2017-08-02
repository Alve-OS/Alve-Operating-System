﻿/*
* PROJECT:          Alve Operating System Development
* CONTENT:          Translation system
* PROGRAMMERS:      Alexy DA CRUZ <dacruzalexy@gmail.com>
*/

using System;
using Alve_OS.System.Computer;

namespace Alve_OS.System.Translation
{
    class Text
    {

        /*
         * ## Utilisation des mots clés:
         * 
         * Les mots clés remplace une phrase
         * par leur traduction correspondant
         * à la langue du système. Vous devez donc
         * associer un mot clé à une phrase.
         */

        public static void Display(string ToTranslate, string arg = "")
        {
            switch (Kernel.langSelected)
            {
                case "fr_FR":

                    switch (ToTranslate)
                    {
                        case "shutdown": //Ceci est un mot clé
                            Console.WriteLine("Extinction en cours..."); //Ceci est une phrase traduite
                            break;
                        case "keyboard":
                            Console.WriteLine("Initialisation clavier FR...");
                            break;
                        case "restart": 
                            Console.WriteLine("Redémarrage en cours..."); 
                            break;
                        case "directorydoesntexist":
                            Console.WriteLine("Ce répertoire n'éxiste pas !");
                            break;
                        case "typename":
                            Console.WriteLine("Type\t Nom");
                            break;
                        case "doesnotexist":
                            Console.WriteLine(arg + " n'existe pas !");
                            break;
                        case "alreadyexist":
                            Console.WriteLine(arg + " existe deja !");
                            break;
                        case "NameSizeParent":
                            Console.WriteLine("Nom\tTaille\tParent");
                            break;
                        case "OSName":
                            Console.WriteLine("Nom du système d'exploitation: Alve");
                            break;
                        case "OSVersion":
                            Console.WriteLine("Version du système:            " + Kernel.version);
                            break;
                        case "OSRevision":
                            Console.WriteLine("Révision du système:           " + Kernel.revision);
                            break;
                        case "UnknownCommand":
                            Console.WriteLine("Commande inconnue.");
                            break;
                        case "unknownlanguage":
                            Console.WriteLine("Langue inconnue.");
                            break;
                        case "availablelanguage":
                            Console.WriteLine("Langues disponibles: en_US fr_FR");
                            break;
                        case "unknowncolor":
                            Console.WriteLine("Couleur inconnue.");
                            break;
                        case "logged":
                            Console.WriteLine("Vous êtes connecté en tant que " + arg + ".");
                            break;
                        case "unknownuser":
                            Console.WriteLine("Utilisateur inconnu.");
                            break;
                        case "languageask":
                            Console.WriteLine("Choisissez votre langue:");
                            break;
                        case "chooseyourusername":
                            Console.WriteLine("Choisissez votre nom d'utilisateur pour votre compte Alve:");
                            break;
                        case "alreadyuser":
                            Console.WriteLine("Cet utilisateur existe déjà !");
                            break;
                        case "passuser":
                            Console.WriteLine("Choisissez un mot de passe pour " + arg);
                            break;
                        case "setupcmd":
                            Console.WriteLine("Voulez vous réellement réinitialiser votre ordinateur ? Tous les fichiers vont être effacés. [o/n]");
                            break;
                        case "user":
                            Console.Write("Utilisateur > ");
                            break;
                        case "passwd":
                            Console.Write("Mot de passe > ");
                            break;
                        case "charmin":
                            Console.Write("Le nom d'utilisateur doit être constitué de caractères alphanumériques et doit être entre 4 à 20 caractères.");
                            break;
                        case "pswcharmin":
                            Console.Write("Le mot de passe doit être constitué de caractères alphanumériques et doit être entre 6 à 40 caractères.");
                            break;
                        case "errorwhileusercreating":
                            Console.Write("Une erreur s'est produite lors de la création du compte utilisateur.");
                            break;
                        case "whattypeuser":
                            Console.Write("Quel est le niveau de l'utilisateur ?");
                            break;
                        case "groupsavailable":
                            Console.Write("Groupes disponibles: 'admin'; 'standard'");
                            break;
                        case "mkfil":
                            Console.WriteLine("Entrez le nom du fichier (mkfil fichier.txt).");
                            break;
                        case "doesnotexit":
                            Console.WriteLine("Ce fichier n'existe pas.");
                            break;
                        case "computername":
                            Console.WriteLine("Nom de l'ordinateur: " + arg);
                            break;
                    }
                    break;

                case "en_US":

                    switch (ToTranslate)
                    {

                        case "shutdown":
                            Console.WriteLine("Shutting Down...");
                            break;
                        case "keyboard":
                            Console.WriteLine("Keyboard initialisation EN...");
                            break;
                        case "restart":
                            Console.WriteLine("Restarting...");
                            break;
                        case "directorydoesntexist":
                            Console.WriteLine("This directory doesn't exist!");
                            break;
                        case "typename":
                            Console.WriteLine("Type\t Name");
                            break;
                        case "doesnotexist":
                            Console.WriteLine(arg + " does not exist!");
                            break;
                        case "alreadyexist":
                            Console.WriteLine(arg + " already exist!");
                            break;
                        case "NameSizeParent":
                            Console.WriteLine("Name\tSize\tParent");
                            break;
                        case "OSName":
                            Console.WriteLine("Operating system name:     Alve");
                            break;
                        case "OSVersion":
                            Console.WriteLine("Operating system version:  " + Kernel.version);
                            break;
                        case "OSRevision":
                            Console.WriteLine("Operating system revision: " + Kernel.revision);
                            break;
                        case "UnknownCommand":
                            Console.WriteLine("Unknown command.");
                            break;
                        case "unknownlanguage":
                            Console.WriteLine("Unknown language.");
                            break;
                        case "availablelanguage":
                            Console.WriteLine("Available languages: en_US fr_FR");
                            break;
                        case "unknowncolor":
                            Console.WriteLine("Unknown colour.");
                            break;
                        case "logged":
                            Console.WriteLine("You are logged in " + arg + ".");
                            break;
                        case "unknownuser":
                            Console.WriteLine("Unknown user.");
                            break;
                        case "languageask":
                            Console.WriteLine("Choose your language:");
                            break;
                        case "chooseyourusername":
                            Console.WriteLine("Choose a user name for your Alve Account:");
                            break;
                        case "alreadyuser":
                            Console.WriteLine("This user exist already!");
                            break;
                        case "passuser":
                            Console.WriteLine("Choose a password for " + arg);
                            break;
                        case "setupcmd":
                            Console.WriteLine("Do you really want to reinitialize the computer ? All files will be erased. [o/n]");
                            break;
                        case "user":
                            Console.Write("Login > ");
                            break;
                        case "passwd":
                            Console.Write("Password > ");
                            break;
                        case "charmin":
                            Console.Write("Username length should be 4-20 characters and contain alphanumeric text.");
                            break;
                        case "pswcharmin":
                            Console.Write("Password length should be 6-40 characters and contain alphanumeric text.");
                            break;
                        case "errorwhileusercreating":
                            Console.Write("An error occurred while creating the user account.");
                            break;
                        case "whattypeuser":
                            Console.Write("What will be the user level ?");
                            break;
                        case "mkfil":
                            Console.WriteLine("Enter the file name (mkfil file.txt).");
                            break;
                        case "doesnotexit":
                            Console.WriteLine("This file does not exist.");
                            break;
                        case "computername":
                            Console.WriteLine("Computer name: " + arg);
                            break;
                    }
                    break;
            }
        }
    }
}
