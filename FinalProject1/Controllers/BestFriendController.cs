using FinalProject1.DTO;
using FinalProject1.Models;
using Microsoft.AspNetCore.Mvc;


namespace FinalProject1.Controllers;


[ApiController]
[Route("[controller]")]

public class BestFriendController : ControllerBase
{
    private readonly FinalProjectContext _db;
    
    private readonly ILogger<BestFriendController> _logger;

    private BestFriendResponse bestFriend;

    public BestFriendController(ILogger<BestFriendController> logger, FinalProjectContext db)
    {
        _logger = logger;
        _db = db;
    }


    [HttpGet("GetFriend")]
    public ActionResult GetFriend(int? Id) {

        if (Id == null || Id == 0)
        {
            bestFriend = new BestFriendResponse();

            var response = _db.BestFriends
                            .OrderByDescending(x => x.Id)
                            .Take(5);

            foreach (var item in response)
            {
                bestFriend.Id = item.Id;
                bestFriend.firstName = item.firstName;
                bestFriend.lastName = item.lastName;
                bestFriend.age = item.age;
                bestFriend.pronouns = item.pronouns;
            }

            return Ok(bestFriend);
        }
        else
        {
            var response = _db.BestFriends.Where(x => x.Id == Id).DefaultIfEmpty().ToArray();
            if (response[0] == null)
            {
                return NotFound(Id + " was not found.");
            }
            return new JsonResult(response);
        }

    }
    [HttpPost("CreateFriend")]
    public void CreateFriend(string firstName, string lastName, string age, string pronouns)
    {
        bestFriend = new BestFriendResponse();
        bestFriend.firstName = firstName;
        bestFriend.lastName = lastName;
        bestFriend.age = age;
        bestFriend.pronouns = pronouns;
        var response = _db.BestFriends.Add(bestFriend);
        _db.SaveChanges();
    }

    [HttpDelete("DeleteFriend")]
    public void DeleteFriend(int Id)
    {
        BestFriend response = _db.BestFriends.Find(Id);
        _db.BestFriends.Remove(response);
        _db.SaveChanges();
    }

    [HttpPut("UpdateFriend")]
    public ActionResult UpdateFriend(int Id, string firstName, string lastName, string age, string pronouns)
    {
        BestFriend response = _db.BestFriends.Find(Id);
        if (response == null)
        {
            return NotFound("Not Found.");
        }
        response.firstName = firstName;
        response.lastName = lastName;
        response.age = age;
        response.pronouns = pronouns;
        _db.Update(response);
        _db.SaveChanges();
        return Ok();
    }
    
}