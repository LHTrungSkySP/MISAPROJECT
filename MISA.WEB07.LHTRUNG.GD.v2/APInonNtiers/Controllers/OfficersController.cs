using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace APInonNtiers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OfficersController : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllOfficer()
        {
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
                {
                    // prepare command of Procedure
                    string storedProcedure = "Proc_officer_GetAllOfficer";

                    // call on database to execute
                    var officers = mySqlConnection.Query<Officer>(storedProcedure, commandType: System.Data.CommandType.StoredProcedure);

                    // doing with result from database
                    if (officers != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, officers);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
    }
}
