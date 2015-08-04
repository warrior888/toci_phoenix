using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pentagram.Controllers
{
    public class CourseRegistrationController : ApiController
    {
		//RegistrationId - id of task given to the user

	    public string GetRandomTest()
	    {
		    var data = "";
		    //TODO: generate random test from db
		    // + generate RegistrationId 
		    //TODO: return (JSON)
			return data;	//JSON object with captcha, question list and RegistrationId
	    }

	    public bool GetUserResponse([FromBody] Object jsonObject)    // Not sure if correct
	    {
			//in object parameter we get RegistrationId (task's ID) and answers
			//TODO: send it to some model in our application (Pentagram.Logic) 
			//TODO: return if operation completed or failed
		    return false;
	    }

    }
}
