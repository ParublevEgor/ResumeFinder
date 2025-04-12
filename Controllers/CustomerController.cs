using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;
using ResumeFinder.Services;

namespace ResumeFinder.Controllers
{
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

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Customer> customers = await _customerService.GetAllAsync(token);
            ICollection<CustomerDTO> customerDTOs = _mapper.Map<ICollection<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }

        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get([FromQuery] long id, CancellationToken token)
        {
            Customer? customer = await _customerService.GetAsync(id, token);
            CustomerDTO? customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] CustomerDTO customerDTO, CancellationToken token)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);
            Customer updatedCustomer = await _customerService.UpdateAsync(customer, token);
            CustomerDTO updatedCustomerDTO = _mapper.Map<CustomerDTO>(updatedCustomer);
            return Ok(updatedCustomerDTO);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _customerService.RemoveAsync(id, token);
            return Ok();
        }
    }
}
