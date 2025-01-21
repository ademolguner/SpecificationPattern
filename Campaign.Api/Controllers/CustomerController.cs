using Campaign.Application.Features.Customers.Command.BulkCreate;
using Campaign.Application.Features.Customers.Command.Create;
using Campaign.Application.Features.Customers.Command.Delete;
using Campaign.Application.Features.Customers.Command.Update;
using Campaign.Application.Features.Customers.Query.GetAll;
using Campaign.Application.Features.Customers.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Campaign.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomerController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(CreateCustomer), new { id = result?.Id }, result);
    }
    
    [HttpPost("bulk")]
    public async Task<IActionResult> BulkCustomer([FromBody] BulkCreateCustomerCommand command)
    {
        var result = await mediator.Send(command);
        return result.Count != 0 ? Ok(result) : NotFound();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        var result = await mediator.Send(new GetByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await mediator.Send(new GetAllCustomersQuery());
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        if (id != command.UpdateCustomerRequest.Id) return BadRequest("ID mismatch.");
        var result = await mediator.Send(command);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var result = await mediator.Send(new DeleteCustomerCommand(id));
        return result ? NoContent() : NotFound();
    }
}