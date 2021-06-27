using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Dev.IO.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        //CLASSE BASE PARA AS OUTRAS CONTROLLERS
        //validação de notificacao de erro
        //validação de model state
        //validação da operação de negócios

    }
}