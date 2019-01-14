using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.IO;

using System.Text;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController 
    {


        private string username = "admin";
        private string password = "admin";
        // POST api/values
        [HttpPost]
        public string Post([FromBody] IReadOnlyDictionary<string,string> value)
        {

            var username = value.GetValueOrDefault("username",null);
            var password = value.GetValueOrDefault("password",null);

            if (this.username.Equals(username) && this.password.Equals(password))
                    return SuccessResponse();
            return ErrorResponse();



        }


        private string SuccessResponse() {

             string filePath = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot");

            var fileTarget  = filePath + "/success.html";

           string response = File.ReadAllText(fileTarget, Encoding.UTF8);

            return response;
        }

        private string ErrorResponse() {



             string filePath = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot");

            var fileTarget  = filePath + "/error.html";

           string response = File.ReadAllText(fileTarget, Encoding.UTF8);

            return response;
        }


        [HttpGet]
        public String Get() {


            return "test server working successfull ";
        }

        
    }
}
