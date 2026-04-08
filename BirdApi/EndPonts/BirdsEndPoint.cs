using BirdApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlTypes;

namespace BirdApi.EndPonts
{
    public static class BirdsEndPoint
    {
        public static void UseBirdEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/birds", () =>
            {
                string birdsStr = File.ReadAllText("Data/Birds.json");
                var birds = JsonConvert.DeserializeObject<BirdModel>(birdsStr);
                if (birds is null) return Results.BadRequest();
                return birds!.Birds.Count >= 1 ? Results.Ok(birds) : Results.NotFound();
            }).WithName("Birds");

            app.MapPost("/api/birds", (Bird bird) =>
            { 
                string birdsStr = File.ReadAllText("Data/Birds.json");
                var birdModel = JsonConvert.DeserializeObject<BirdModel>(birdsStr);

                if (birdModel is null) return Results.BadRequest();

                //bird.Id = birdModel.Birds.Count + 1;
                bird.Id = birdModel.Birds.Max(x => x.Id +1);
                birdModel.Birds.Add(bird);

                string jsonStr = JsonConvert.SerializeObject(birdModel,Formatting.Indented);
                try
                {
                    File.WriteAllText("Data/Birds.json", jsonStr);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err.Message);
                }

                return Results.Ok("Create Success");

            }).WithName("Create");

            app.MapGet("/api/birds/{id}", ([FromRoute]int id) =>
            {
                string birdsStr = File.ReadAllText("Data/Birds.json");
                var birdModel = JsonConvert.DeserializeObject<BirdModel>(birdsStr);
                if (birdModel is null) return Results.BadRequest();

                var bird = birdModel.Birds.FirstOrDefault(b => b.Id == id);
                return bird is not null ? Results.Ok(bird) : Results.NotFound();
            }).WithName("Bird");

            app.MapPut("/api/birds/{id}", ([FromRoute]int id ,[FromBody]Bird birdDto) =>
            {
                string birdsStr = File.ReadAllText("Data/Birds.json");
                var birdModel = JsonConvert.DeserializeObject<BirdModel>(birdsStr);
                if (birdModel is null) return Results.BadRequest();

                var bird = birdModel.Birds.FirstOrDefault(b => b.Id == id);
                if(bird is null) return Results.NotFound();

                bird.BirdMyanmarName = birdDto.BirdMyanmarName;
                bird.BirdEnglishName = birdDto.BirdEnglishName;
                bird.ImagePath = birdDto.ImagePath;
                bird.Description = birdDto.Description;

                string jsonStr = JsonConvert.SerializeObject(birdModel, Formatting.Indented);
                try
                {
                    File.WriteAllText("Data/Birds.json", jsonStr);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err.Message);
                }
                return Results.Ok("Update Success");

            }).WithName("Update");

            app.MapDelete("/api/birds/{id}", ([FromRoute]int id) =>
            {
                try
                {
                    string birdsStr = File.ReadAllText("Data/Birds.json");
                    var birdModel = JsonConvert.DeserializeObject<BirdModel>(birdsStr);
                    if (birdModel is null) return Results.BadRequest();

                    int findIndex = birdModel.Birds.FindIndex(b => b.Id == id);
                    birdModel.Birds.RemoveAt(findIndex);

                    string jsonStr = JsonConvert.SerializeObject(birdModel);
                    File.WriteAllText("Data/Birds.json", jsonStr);
                    return Results.NoContent();
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err.Message);
                }

            }).WithName("Delete");
        }
    }
}
