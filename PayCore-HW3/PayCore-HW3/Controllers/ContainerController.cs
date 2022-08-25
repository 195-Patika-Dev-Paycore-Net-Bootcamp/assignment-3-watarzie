using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCore_HW3.Context;
using PayCore_HW3.Context.Abstract;
using PayCore_HW3.Extensions;
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
        [HttpGet("{id}")]
        public IActionResult GetByVehicleId(int id)
        {
            List<Container> container = session.Entities.Where(x => x.VehicleId == id).ToList();
            if(container.Count==0 || container == null)
            {
                return NotFound();
            }
            return Ok(container);
        }
        [HttpGet("{id},{n}")]
        public IActionResult GetByNContainer(int id,int n)
        {
            List<List<Container>> result = new List<List<Container>>();
            List<Container> container = session.Entities.Where(x => x.VehicleId == id).ToList();
            if(container.Count % n !=0)
            {
                return BadRequest();
            }
            List<List<Container>> partitions = container.partition(container.Count / n);
            foreach (var item in partitions)
            {
                result.Add(item);
                
            }
            return Ok(result);
            
           
            
            


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
        [HttpPut]
        public ActionResult<Container> Put([FromBody] UpdateContainerModel request)
        {
            Container container = session.Entities.FirstOrDefault(x => x.Id == request.Id);

            if (container == null)
            {
                return NotFound();
            }
            try
            {
                session.BeginTranstaction();
                container.Id = request.Id;
                container.ContainerName = request.ContainerName;
                container.Latitude = request.Latitude;
                container.Longitude = request.Longitude;

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
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Container container = session.Entities.Where(x => x.Id == id).SingleOrDefault();
            

            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTranstaction();
                session.Delete(container);
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

            return Ok();
        }

    }
}
