using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using supplierapi.Services;
using supplierapi.Models;
using System.Linq;
using Newtonsoft.Json;

namespace supplierapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StoreUserController : ControllerBase
    {
        private IStoreUserService _userService;

        private readonly IDistributedCache _distributedCache;

        public StoreUserController(IStoreUserService userService, IDistributedCache distributedCache)
        {
            _userService = userService;
            _distributedCache = distributedCache;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            System.Console.WriteLine("Hi!");
            
            StoreUser user = null;

            var userSessionKey = "UserLogin" + model.Username;
            var userSessionValue = HttpContext.Session.GetString(userSessionKey);

            if(userSessionValue == null) {
                user = _userService.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                HttpContext.Session.SetString(userSessionKey, model.Username + Guid.NewGuid().ToString());
                _distributedCache.SetString(userSessionKey, JsonConvert.SerializeObject(user));

            } else {
                string _userObjectJsonString = _distributedCache.GetString(userSessionKey);

                user = JsonConvert.DeserializeObject<StoreUser>(_userObjectJsonString);
            }

            // var existingTime = _distributedCache.GetString(cacheKey);
            // if (!string.IsNullOrEmpty(existingTime))
            // {
            //     System.Console.WriteLine( "Fetched from cache : " + existingTime);
            // }
            // else
            // {
            //     existingTime = DateTime.UtcNow.ToString();
            //     _distributedCache.SetString(cacheKey, existingTime);
            //     System.Console.WriteLine("Added to cache : " + existingTime);
            // }

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}