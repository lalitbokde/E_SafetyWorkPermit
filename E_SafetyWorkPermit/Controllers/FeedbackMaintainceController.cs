using E_SafetyWorkPermit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace E_SafetyWorkPermit.Controllers
{
    public class FeedbackMaintainceController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        [HttpPost]
        public JsonResult<Result> setFeedback(Feedback model)
        {
            try
            {
                db.feedbacks.Add(model);
                db.SaveChanges();
                Result result = new Result
                {
                    Status = 1,
                    Message = "Succcess"
                };
                return Json(result);
            }
            catch
            {

                Result result = new Result
                {
                    Status = 0,
                    Message = "failed"
                };
                return Json(result);
            }
        }
        public class Result
        {
            public int Status { get; set; }
            public string Message { get; set; }

        }
    }
}
