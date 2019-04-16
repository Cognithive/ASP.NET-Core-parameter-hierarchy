namespace ParameterHierarchy
{
    using Microsoft.AspNetCore.Mvc;

    [Route("/")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Default(Parameters1 parameters)
        {
            if (!ModelState.IsValid)
            {
                return this.ValidationProblem();
            }

            return this.View(new Model1(parameters));
        }
    }
}
