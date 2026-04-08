


//using Newtonsoft.Json;
//using System.Text.Json;
//using Tuto_07_JSON;

//User userOne = new User() { Name = "Aung Nyein Chan",Email = "Aung@1230",Age = 31,UserId =Guid.NewGuid()};
//User UserTwo = new User() { Name = " Nyein ", Email = "Aung@230", Age = 22, UserId = Guid.NewGuid() };



//string jsonStr = JsonConvert.SerializeObject(userOne,Formatting.Indented);
//Console.WriteLine(jsonStr);

//var user = JsonConvert.DeserializeObject<User>(jsonStr);
//Console.WriteLine($"user name is {user?.Name}");

//var user2 = UserTwo.Encode(UserTwo);
//Console.WriteLine(user2);

//var user2Obj = user2.Decode<User>();
//Console.WriteLine($"user two email is {user2Obj?.Email}");

//var str =new User().Encode(new User());
//Console.WriteLine(str);

//var res = "mgmg".Decode<User>();

using Newtonsoft.Json;
using Tuto_07_JSON;

BirdController birdController = new BirdController();


birdController.Create(new Tuto_07_JSON.Models.Bird { Id = 123,BirdEnglishName ="test",BirdMyanmarName= "aew"}); 
birdController.AllBirds();


//JsonConvert.DeserializeObject<>