using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using supplierapi.Services;

namespace supplierapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoreService _storeService;

        public StoresController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public ActionResult<List<Store>> Get() =>
            _storeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStore")]
        public ActionResult<Store> Get(string id)
        {
            var store = _storeService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        [HttpPost]
        public ActionResult<Store> Create(Store store)
        {
            _storeService.Create(store);

            return CreatedAtRoute("GetStore", new { id = store.Id.ToString() }, store);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Store storeIn)
        {
            var store = _storeService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            _storeService.Update(id, storeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var store = _storeService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            _storeService.Remove(store.Id);

            return NoContent();
        }
    }
}
