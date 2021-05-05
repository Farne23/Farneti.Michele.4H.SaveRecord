using System.IO.Enumeration;
using System.IO;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using Farneti.Michele._4H.SaveRecord.Models;

namespace Farneti.Michele._4H.SaveRecord.Models
{
    public class Comune
    {
        public int ID { get;  set; }
        public string NomeComune { get;  set; }
        public string CodiceCastale { get;  set; }

        public Comune() { }

        public Comune(string s, int id)
        {
            string[] splitted = s.Split(',');
            ID = id;
            NomeComune = splitted[1];
            CodiceCastale = splitted[0];
        }
    }

    public class Comuni : List<Comune>
    {
        public string NomeFile{get;}
        public Comuni(){}

        public Comuni(string filename)
        {
            NomeFile=filename;

            using(FileStream fin = new FileStream(filename, FileMode.Open))
            {
                StreamReader reader= new StreamReader(fin);

                string riga;
                int id = 1;

                while(!reader.EndOfStream)
                {
                    riga = reader.ReadLine();
                    Comune c = new Comune(riga,id);
                    id++;

                    this.Add(c);                 
                }
            }      
        }

        public void Save()
        {
            string fn= NomeFile.Split(".")[0] +".bin";
            Save(fn);
        }

        public void Save(string fileName)
        {
            FileStream fout = new FileStream(fileName,FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fout);

            foreach(Comune comune in this)
            {
                writer.Write(comune.ID);
                writer.Write(comune.CodiceCastale);
                writer.Write(comune.NomeComune);
            }
            writer.Flush();
            writer.Close();
        }

        public void Load()
        {
            string fn= NomeFile.Split(".")[0] +".bin";
            Load(fn);
        }

        public void Load(string fileName)
        {
            Clear();
            
            using (FileStream fin = new FileStream(fileName, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(fin);
                Comune c = new Comune();
                
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {   
                    c.ID = reader.ReadInt32();
                    c.CodiceCastale = reader.ReadString();
                    c.NomeComune = reader.ReadString();
                    
                    Add( c );
                }
            }
        }

    }
}
