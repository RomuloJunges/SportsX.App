using Microsoft.AspNetCore.Mvc;
using SportsX.Application.Contracts;

namespace SportsX.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        public PhoneController(IPhoneService phoneService)
        {
            this._phoneService = phoneService;
        }
    }
}