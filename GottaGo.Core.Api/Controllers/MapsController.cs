// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GottaGo.Core.Api.Models.Maps;
using GottaGo.Core.Api.Models.Maps.Exceptions;
using GottaGo.Core.Api.Services.Foundations.Maps;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace GottaGo.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapsController : RESTFulController
    {
        private readonly IMapService mapService;

        public MapsController(IMapService mapService)
        {
            this.mapService = mapService;
        }

        [HttpGet]
        public async ValueTask<ActionResult<List<Address>>> GetAddressesByQueryAsync(
            string query,
            double? latitude,
            double? longitude,
            string language,
            string countries)
        {
            try
            {
                var addressSearch = new AddressSearch
                {
                    Query = query,
                    Language = language,
                    Countries = countries?.Split(",").ToList() ?? new List<string>(),
                    CurrentLocation = new Coordinates
                    {
                        Latitude = latitude,
                        Longitude = longitude
                    }
                };

                List<Address> addresses = await this.mapService.SearchAddress(addressSearch);

                return Ok(addresses);
            }
            catch (MapValidationException mapValidationException)
            {
                return BadRequest(mapValidationException.InnerException);
            }
            catch (MapDependencyException mapDependencyException)
            {
                return InternalServerError(mapDependencyException.InnerException);
            }
            catch (MapServiceException mapServiceException)
            {
                return InternalServerError(mapServiceException);
            }
        }
    }
}