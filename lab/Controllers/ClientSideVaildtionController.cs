﻿using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers
{
    public class ClientSideValidationController : Controller
    {
        public JsonResult CheckAddress(string address)
        {
            if (address == "Giza" || address == "Alex" || address == "Cairo")
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
