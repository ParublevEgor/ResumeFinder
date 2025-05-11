using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;
using ResumeFinder.Services;

namespace ResumeFinder.Controllers
{
    /// <summary>
    /// Контроллер для заказчика
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод для GET-запроса
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpGet(nameof(GetAll))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Customer> customers = await _customerService.GetAllAsync(token);
            ICollection<CustomerDTO> customerDTOs = _mapper.Map<ICollection<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }

        /// <summary>
        /// Метод для GET-запроса
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpGet(nameof(Get))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> Get([FromQuery] long id, CancellationToken token)
        {
            Customer? customer = await _customerService.GetAsync(id, token);
            CustomerDTO? customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        /// <summary>
        /// Метод для PUT-запроса
        /// </summary>
        /// <param name="customerDTO">Данные заказчика</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPut(nameof(Update))]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Update([FromBody] CustomerDTO customerDTO, CancellationToken token)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);
            Customer updatedCustomer = await _customerService.UpdateAsync(customer, token);
            CustomerDTO updatedCustomerDTO = _mapper.Map<CustomerDTO>(updatedCustomer);
            return Ok(updatedCustomerDTO);
        }

        /// <summary>
        /// Метод для DELETE-запроса
        /// </summary>
        /// <param name="id">Id заказчика</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpDelete(nameof(Delete))]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _customerService.RemoveAsync(id, token);
            return Ok();
        }
    }
}
