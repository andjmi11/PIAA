using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string p1 = "D7871";
            string p2 = "B06EAC7E28";
            string p3 = "8083D74CC012 2860 81";
            string p4 = "276CE38083D74CC012 2860 817BB AA5D21B1C B6BD4E9 9A";

            string ascii = "Andjelija";

            /*FilesRepo.GenerateHexFile("hex100.txt", 100);
              FilesRepo.GenerateHexFile("hex1k.txt", 1000);
              FilesRepo.GenerateHexFile("hex10k.txt", 10000);
              FilesRepo.GenerateHexFile("hex100k.txt", 100000);*/

            /*FilesRepo.GenerateAsciiFile("ascii100.txt", 100);
             FilesRepo.GenerateAsciiFile("ascii1k.txt", 1000);
             FilesRepo.GenerateAsciiFile("ascii10k.txt", 10000);
             FilesRepo.GenerateAsciiFile("ascii100k.txt", 100000);*/
            

           
              SoundEx soundEX = new SoundEx("by");
              SoundEx soundEx1 = new SoundEx("Thrown");
              SoundEx soundEx2 = new SoundEx("DataBase");
              SoundEx soundEx3 = new SoundEx("food");

              soundEX.SearchAllEqualCodes(FilesRepo.ReadAsStringArray("DBMS.txt"), "soundExResultsBY.txt");
              soundEx1.SearchAllEqualCodes(FilesRepo.ReadAsStringArray("DBMS.txt"), "soundExResultsThrown.txt");
              soundEx2.SearchAllEqualCodes(FilesRepo.ReadAsStringArray("DBMS.txt"), "soundExResultsDataBase.txt");
              soundEx3.SearchAllEqualCodes(FilesRepo.ReadAsStringArray("SoundEX.txt"), "soundExResultFood.txt");
          

            

              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100.txt"), p1, 16, "5r100.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex1k.txt"), p1, 16, "5r1k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex10k.txt"), p1, 16, "5r10k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100k.txt"), p1, 16, "5r100k.txt");

              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100.txt"),p2, 16, "10r100.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex1k.txt"), p2 , 16, "10r1k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex10k.txt"), p2, 16, "10r10k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100k.txt"), p2, 16, "10r100k.txt");
                 
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100.txt"), p3, 16, "20r100.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex1k.txt"), p3, 16, "20r1k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex10k.txt"), p3, 16, "20r10k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100k.txt"), p3, 16, "20r100k.txt");
            
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100.txt"), p4, 16, "50r100.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex1k.txt"), p4, 16, "50r1k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex10k.txt"), p4, 16, "50r10k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("hex100k.txt"), p4, 16, "50r100k.txt");

  
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("ascii100.txt"), ascii, 256, "resAscii100.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("ascii1k.txt"), ascii, 256, "resAscii1k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("ascii10k.txt"), ascii, 256, "resAscii10k.txt");
              RabinKarp.RabinKarpMatcher(FilesRepo.ReadAsString("ascii100k.txt"), ascii, 256, "resAscii100k.txt");
           

           

        }
    }
}
