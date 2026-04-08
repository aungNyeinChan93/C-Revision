using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Tuto_07_JSON.Models;

namespace Tuto_07_JSON
{
    public class BirdController
    {
        public void AllBirds()
        {
            string birdStr = File.ReadAllText("Data/birds.json");

            //var birds = JsonConvert.DeserializeObject<Birds>(birdStr);
            var birds =  birdStr.Decode<Birds>();

            if (birds is null || birds.birds.Count <= 0)
            {
                return ;
            }

            foreach (Bird bird in birds.birds)
            {
                Console.WriteLine($" Bird Name  ==> {bird.BirdEnglishName} \n");
            }

        }

        public void Create(Bird bird)
        {
            string birdStr = File.ReadAllText("Data/birds.json");
            var birds = birdStr.Decode<Birds>();
            birds!.birds.Add(bird);

            string birdsStr = JsonConvert.SerializeObject(birds,Formatting.Indented);
            File.WriteAllText("Data/birds.json",birdsStr);
            Console.WriteLine("Create success!");
        }
    }
}
