using System;
using AsciiArt;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void AfficherMot(string mot, List<char> lettres)
        {
            for(int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if(lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else
                {
                    Console.Write("_ ");
                } 
            }
            Console.WriteLine();
        }

        static bool ToutesLettresDevinees(string mot, List<char> lettres)
        {
            foreach(char lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }
            if(mot.Length == 0)
            {
                return true;
            }
            return false;
        }
        static char DemanderUneLettre(string message = "Rentrez une Lettre: ")
        {
            while(true)
            {
                Console.Write(message);
                string reponse = Console.ReadLine();

                if (reponse.Length == 1)
                {
                    reponse = reponse.ToUpper();
                    return reponse[0];
                }
                Console.WriteLine("Erreur : Vous devez rentrer une lettre");
            }
        }

        static void DevinerMot(string mot)
        {
            var lettreDevinees = new List<char>();
            var lettreExclues = new List<char>();
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;

            while(viesRestantes > 0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
                Console.WriteLine();

                AfficherMot(mot, lettreDevinees);
                Console.WriteLine();
                var lettre = DemanderUneLettre();
                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot");
                    lettreDevinees.Add(lettre);
                    if(ToutesLettresDevinees(mot, lettreDevinees))
                    {
                        break;
                    }
                }
                else
                {
                    if (!lettreExclues.Contains(lettre))
                    {
                        viesRestantes--;
                        lettreExclues.Add(lettre);
                    }

                    Console.WriteLine("Vies restante : " + viesRestantes);
                }

                if(lettreExclues.Count > 0)
                {
                    Console.WriteLine("Le mot ne contient pas les lettres : " + String.Join(", ", lettreExclues));
                }
                Console.WriteLine();
            }

            Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
            
            if (viesRestantes == 0)
            {
                Console.WriteLine("PERDU ! Le mot était : " + mot);
            }
            else
            {
                AfficherMot(mot, lettreDevinees);
                Console.WriteLine();
                Console.WriteLine("GAGNE !");
            }
        }

        static string[] chargerLesMots(string nomFichier)
        {
            try
            {
                return File.ReadAllLines(nomFichier);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erreur de lecture du fichier : " + nomFichier + "(" + ex.Message + ")");
            }
            return null;
        }

        static bool DemanderDeRejouer()
        {
            char reponse = DemanderUneLettre("Voulez-vous rejouer (o/n) : ");

            if ((reponse == 'o') || (reponse == 'O'))
            {
                return true;
            }
            else if ((reponse == 'n') || (reponse == 'N'))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Erreur : Vous devez répondre avec o ou n");
                return DemanderDeRejouer();
            }
        }

        static void Main(string[] args)
        {
            var mots = chargerLesMots("mots.txt");

            if((mots == null) || (mots.Length == 0))
            {
                Console.WriteLine("La liste de mots est vide");
            }
            else
            {
                while(true)
                {
                    Random r = new Random();
                    int i = r.Next(mots.Length);
                    string mot = mots[i].Trim().ToUpper();
                    DevinerMot(mot);
                    if (!DemanderDeRejouer())
                    {
                        break;
                    }
                    Console.Clear();
                }
                Console.WriteLine("Merci et à bientôt");
            }
        }
    }
}