using Application.Features.CreditApplications.Commands.Create;
using Application.Features.CreditApplications.Commands.Review;
using Application.Features.CreditApplications.Queries.GetById;
using Application.Features.CreditApplications.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateCreditApplicationAsync([FromBody] CreateCreditApplicationCommand createCreditApplicationCommand)
    {
        CreateCreditApplicationResponse createCreditApplicationResponse = await Mediator.Send(createCreditApplicationCommand);
        return Ok(createCreditApplicationResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetCreditApplicationListAsync()
    {
        GetCreditApplicationListQuery getCreditApplicationListQuery = new ();
        IList<GetCreditApplicationListResponse> getCreditApplicationListResponses = await Mediator.Send(getCreditApplicationListQuery);
        return Ok(getCreditApplicationListResponses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCreditApplicationById([FromRoute] Guid id)
    {
        GetCreditApplicationByIdQuery getCreditApplicationByIdQuery = new() { Id = id };
        GetCreditApplicationByIdResponse getCreditApplicationByIdResponse = await Mediator.Send(getCreditApplicationByIdQuery);
        return Ok(getCreditApplicationByIdResponse);
    }

    [HttpPut]
    public async Task<IActionResult> ApproveCreditApplication([FromBody] Guid id, bool approved)
    {
        ReviewCreditApplicationCommand reviewCreditApplicationCommand = new() { Id = id, Approved = approved };
        ReviewCreditApplicationResponse reviewCreditApplicationResponse = await Mediator.Send(reviewCreditApplicationCommand);
        return Ok(reviewCreditApplicationResponse);
    }
}
