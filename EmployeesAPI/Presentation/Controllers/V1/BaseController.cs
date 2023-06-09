﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeesAPI.Presentation.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
        // Поле медиатора для использования его
        // для формирования команд при выполнении
        // запросов.
        private IMediator? _mediator;
        protected IMediator? Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        // Поле Id пользователя.
        internal Guid EmployeeId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
