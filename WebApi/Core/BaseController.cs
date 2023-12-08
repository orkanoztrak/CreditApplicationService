﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Core;

public abstract class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}