using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Queries.GetById;
using Application.Features.Customers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand createCustomerCommand)
    {
        CreateCustomerResponse response = await Mediator.Send(createCustomerCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerListAsync()
    {
        GetCustomerListQuery getCustomerListQuery = new ();
        List<GetCustomerListResponse> response = await Mediator.Send(getCustomerListQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] Guid id)
    {
        GetCustomerByIdQuery getCustomerByIdQuery = new() { Id = id };
        GetCustomerByIdResponse response = await Mediator.Send(getCustomerByIdQuery);
        return Ok(response);
    }

}
