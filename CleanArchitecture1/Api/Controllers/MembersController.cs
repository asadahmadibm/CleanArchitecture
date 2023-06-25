using Application.IService;
using Domain.entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public ActionResult<IList<Member>> Get()
        {
            return Ok(this.memberService.GetAllMembers());
        }

    }
}