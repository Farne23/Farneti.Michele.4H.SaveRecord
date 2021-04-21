using System;
using System.IO;

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
            RegistroDeiComuni Prova = new RegistroDeiComuni();

        }
        
        public class RegistroDeiComuni
        {
            public RegistroDeiComuni()
            {}

            public static void ValorizzaFileBinario()
            {
                FileStream writeStreamComuni;
                writeStreamComuni = new FileStream("Comuni.bin", FileMode.Create);
                BinaryWriter writeBinaryComuni = new BinaryWriter(writeStreamComuni);

                int i =1; 

                using (StreamReader sr = new StreamReader(@"Models/CodiciComuni.csv"))
                {             
                    do
                    {
                        string RigaLetta = sr.ReadLine();

                        if(RigaLetta == null) { break; };

                        string[] Riga = RigaLetta.Split(",");
                    
                        writeStreamComuni.Seek((i-1) * 32, SeekOrigin.Begin);
                        writeBinaryComuni.Write(i);
                        writeBinaryComuni.Write(Riga[1].PadRight(22));
                        writeBinaryComuni.Write(Riga[0]);

                        i++;                  
                    }
                    while (true);
                }
                writeBinaryComuni.Close();
            }
        }
    } 
}
