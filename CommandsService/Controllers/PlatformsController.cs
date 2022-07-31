using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
	[ApiController]
	[Route("api/c/[controller]")]
	public class PlatformsController : ControllerBase
	{
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
		{
			Console.WriteLine("--> Getting Platorms from CommandsService");

			var platformsItems = _repository.GetAllPlatforms();
			return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformsItems));
		}

		[HttpPost]
		public ActionResult TestInboundConnection()
		{
			Console.WriteLine("--> Inbound post # Command Service");
			return Ok("Inbound test ok from Platforms Controller");
		}
	}
}