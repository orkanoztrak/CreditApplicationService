using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Queries.GetById;
using Application.Features.Customers.Queries.GetCreditApplicationsForCustomer;
using Application.Features.Customers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpPost("CreateCustomerAsync")]
    public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand createCustomerCommand)
    {
        CreateCustomerResponse createCustomerResponse = await Mediator.Send(createCustomerCommand);
        return Ok(createCustomerResponse);
    }

    [HttpGet("GetCustomerListAsync")]
    public async Task<IActionResult> GetCustomerListAsync()
    {
        GetCustomerListQuery getCustomerListQuery = new ();
        IList<GetCustomerListResponse> getCustomerListResponses = await Mediator.Send(getCustomerListQuery);
        return Ok(getCustomerListResponses);
    }

    [HttpGet("GetCustomerByIdAsync")]
    public async Task<IActionResult> GetCustomerByIdAsync([FromQuery] Guid id)
    {
        GetCustomerByIdQuery getCustomerByIdQuery = new() { Id = id };
        GetCustomerByIdResponse getCustomerByIdResponse = await Mediator.Send(getCustomerByIdQuery);
        return Ok(getCustomerByIdResponse);
    }
    [HttpGet("CetCreditApplicationsForCustomer")]
    public async Task<IActionResult> GetCreditApplicationsForCustomer([FromQuery] Guid id)
    {
        GetCreditApplicationsForCustomerQuery getCreditApplicationsForCustomerQuery = new() { Id = id };
        ICollection<GetCreditApplicationsForCustomerResponse> getCreditApplicationsForCustomerResponses = await Mediator.Send(getCreditApplicationsForCustomerQuery);
        return Ok(getCreditApplicationsForCustomerResponses);
    }

    [HttpDelete("DeleteCustomerAsync")]
    public async Task<IActionResult> DeleteCustomerAsync([FromQuery] Guid id)
    {
        DeleteCustomerCommand deleteCustomerCommand = new DeleteCustomerCommand() { Id = id };
        DeleteCustomerResponse deleteCustomerResponse = await Mediator.Send(deleteCustomerCommand);
        return Ok(deleteCustomerResponse);
    }
}
