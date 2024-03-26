using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private  ISender _sender;

        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        
    }
}
