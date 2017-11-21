using MusicDatabase.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicDatabase.GenreTool
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MusicDbContext ctx = new MusicDbContext())
            {
                string json = File.ReadAllText("genres.json");
                List<string> items = JsonConvert.DeserializeObject<List<string>>(json);
                foreach (string item in items)
                {
                    ctx.Genres.Add(new Data.Tables.Genre()
                    {
                        GenreName = item
                    });
                    Console.WriteLine($"Genre: {item} - OK");
                }
                ctx.SaveChanges();
                Console.WriteLine("Process is Complated");
            }
            Console.ReadKey();
        }
    }
}
