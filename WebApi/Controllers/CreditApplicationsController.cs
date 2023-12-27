using Application.Features.CreditApplications.Commands.Create;
using Application.Features.CreditApplications.Commands.Delete;
using Application.Features.CreditApplications.Commands.Review;
using Application.Features.CreditApplications.Queries.GetById;
using Application.Features.CreditApplications.Queries.GetLinkedCustomer;
using Application.Features.CreditApplications.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditApplicationsController : BaseController
{
    [HttpPost("CreateCreditApplicationAsync")]
    public async Task<IActionResult> CreateCreditApplicationAsync([FromBody] CreateCreditApplicationCommand createCreditApplicationCommand)
    {
        CreateCreditApplicationResponse createCreditApplicationResponse = await Mediator.Send(createCreditApplicationCommand);
        return Ok(createCreditApplicationResponse);
    }

    [HttpGet("GetCreditApplicationListAsync")]
    public async Task<IActionResult> GetCreditApplicationListAsync()
    {
        GetCreditApplicationListQuery getCreditApplicationListQuery = new();
        IList<GetCreditApplicationListResponse> getCreditApplicationListResponses = await Mediator.Send(getCreditApplicationListQuery);
        return Ok(getCreditApplicationListResponses);
    }

    [HttpGet("GetCreditApplicationById")]
    public async Task<IActionResult> GetCreditApplicationById([FromQuery] Guid id)
    {
        GetCreditApplicationByIdQuery getCreditApplicationByIdQuery = new() { Id = id };
        GetCreditApplicationByIdResponse getCreditApplicationByIdResponse = await Mediator.Send(getCreditApplicationByIdQuery);
        return Ok(getCreditApplicationByIdResponse);
    }

    [HttpGet("GetLinkedCustomer")]
    public async Task<IActionResult> GetLinkedCustomer([FromQuery] Guid id)
    {
        GetLinkedCustomerQuery getLinkedCustomerQuery = new() { Id = id };
        GetLinkedCustomerResponse getLinkedCustomerResponse = await Mediator.Send(getLinkedCustomerQuery);
        return Ok(getLinkedCustomerResponse);
    }

    [HttpPut("ApproveCreditApplication")]
    public async Task<IActionResult> ApproveCreditApplication([FromBody] Guid id, bool approved)
    {
        ReviewCreditApplicationCommand reviewCreditApplicationCommand = new() { Id = id, Approved = approved };
        ReviewCreditApplicationResponse reviewCreditApplicationResponse = await Mediator.Send(reviewCreditApplicationCommand);
        return Ok(reviewCreditApplicationResponse);
    }

    [HttpDelete("DeleteCreditApplicationAsync")]
    public async Task<IActionResult> DeleteCreditApplicationAsync([FromQuery] Guid id)
    {
        DeleteCreditApplicationCommand deleteCreditApplicationCommand = new() { Id = id };
        DeleteCreditApplicationResponse deleteCreditApplicationResponse = await Mediator.Send(deleteCreditApplicationCommand);
        return Ok(deleteCreditApplicationResponse);
    }
}
