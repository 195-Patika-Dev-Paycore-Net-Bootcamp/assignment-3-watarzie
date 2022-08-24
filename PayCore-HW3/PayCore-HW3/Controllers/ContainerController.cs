using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCore_HW3.Context;
using PayCore_HW3.Context.Abstract;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession<Container> session;
        public ContainerController(IMapperSession<Container> session)
        {
            this.session = session;
        }
        [HttpGet]
        public List<Container> Get()
        {
            List<Container> result = session.Entities.ToList();
            return result;
        }
        [HttpPost]
        public void Post([FromBody] Container container)
        {
            try
            {
                session.BeginTranstaction();
                session.Save(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                session.CloseTransaction();
            }
        }
    }
}
