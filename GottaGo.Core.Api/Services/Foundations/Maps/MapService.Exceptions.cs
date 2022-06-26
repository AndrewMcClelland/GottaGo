// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GottaGo.Core.Api.Models.ExternalMaps.Search.Exceptions;
using GottaGo.Core.Api.Models.Maps;
using RESTFulSense.Exceptions;
using Xeptions;

namespace GottaGo.Core.Api.Services.Foundations.Maps
{
    public partial class MapService
    {
        private delegate ValueTask<List<Address>> ReturningMapsFunction();

        private async ValueTask<List<Address>> TryCatch(ReturningMapsFunction returningMapsFunction)
        {
            try
            {
                return await returningMapsFunction();
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedMapDependencyException =
                    new FailedMapDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedMapDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var failedMapDependencyException =
                    new FailedMapDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedMapDependencyException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var failedMapDependencyException =
                    new FailedMapDependencyException(httpResponseForbiddenException);

                throw CreateAndLogCriticalDependencyException(failedMapDependencyException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedMapDependencyException =
                    new FailedMapDependencyException(httpResponseException);

                throw CreateAndLogDependencyException(failedMapDependencyException);
            }
            catch (Exception exception)
            {
                var failedMapServiceException =
                    new FailedMapServiceException(exception);

                throw CreateAndLogServiceException(failedMapServiceException);
            }
        }

        private MapDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var mapDependencyException = new MapDependencyException(exception);
            this.loggingBroker.LogCritical(mapDependencyException);

            return mapDependencyException;
        }

        private MapDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var mapDependencyException = new MapDependencyException(exception);
            this.loggingBroker.LogError(mapDependencyException);

            return mapDependencyException;
        }

        private MapServiceException CreateAndLogServiceException(Xeption exception)
        {
            var mapServiceException = new MapServiceException(exception);
            this.loggingBroker.LogError(mapServiceException);

            return mapServiceException;
        }
    }
}
