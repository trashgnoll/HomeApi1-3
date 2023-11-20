using System;
using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _repository;
        private IMapper _mapper;
        
        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost] 
        [Route("")] 
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена");
            }
            
            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EditRoomRequest request)
        {
            var roomToEdit = await _repository.GetRoomById(id);
            if (roomToEdit == null) 
                return StatusCode(409, $"Ошибка: Комната {id} не существует.");

            Data.Queries.UpdateRoomQuery query = new (
                request.NewArea, request.NewGasConnected, request.NewVoltage, request.NewName);
            await _repository.UpdateRoom(roomToEdit, query);
            return StatusCode(201, $"Комната {id} изменена");
        }

    }
}