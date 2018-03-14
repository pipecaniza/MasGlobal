using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasGlobal.Core.Behaviors;
using Microsoft.AspNetCore.Mvc;

namespace MasGlobal.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBehavior _employeeBehavior;

        public EmployeeController(IEmployeeBehavior employeeBehavior)
        {
            _employeeBehavior = employeeBehavior;
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> Get(int? id)
        {
            if (id != null)
            {
                return Json(await _employeeBehavior.GetByIdAsync((int)id));
            }
            else
            {
                return Json(await _employeeBehavior.GetAllAsync());
            }
        }
    }
}