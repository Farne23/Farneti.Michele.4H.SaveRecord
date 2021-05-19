using System;
using System.IO;
using Farneti.Michele._4H.SaveRecord.Models;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farneti.Michele._4H.SaveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\nRegistro dei comuni di Michele Farneti\r\n");

            //Leggere un file csv di comuni e trasformarlo in una lista
            //Scrivere  la list comuni in un fil binario
            //RIleggere il file binario una list

            Comuni C= new Comuni("Comuni.csv");   
            Console.WriteLine($"Ho letto {C.Count} righe da file csv\r\n"); 

            C.Save(); 

            Console.WriteLine($"Ho letto {C.Count} righe da file binario\r\n"); 

            Console.WriteLine(C[100].ToString()); 

            C.Load();
            
            Console.WriteLine("Caricamento eseguito\r\n");
        }    
    } 
}
