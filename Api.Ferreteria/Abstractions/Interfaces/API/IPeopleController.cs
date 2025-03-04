using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Interfaces.API
{
    public interface IPeopleController
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get([FromRoute] int Id);
        Task<IActionResult> Add([FromBody] PeopleRequest people);
        Task<IActionResult> Update([FromBody] People people);
        Task<IActionResult> Delete([FromRoute] int Id);
    }
}
