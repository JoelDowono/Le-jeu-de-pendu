using System;

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

        static void DevinerMot(string mot)
        {
            //AfficherMot()

            //DemanderUneLettre()
        }
        static void Main(string[] args)
        {
            string mot = "ELEPHANT";

            AfficherMot(mot, new List<char> { 'E', 'L', 'w' });

            //DevinerMot(mot);
        }
    }
}