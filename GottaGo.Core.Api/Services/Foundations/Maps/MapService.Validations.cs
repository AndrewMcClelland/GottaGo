// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Collections.Generic;
using GottaGo.Core.Api.Models.Maps;
using GottaGo.Core.Api.Models.Maps.Exceptions;

namespace GottaGo.Core.Api.Services.Foundations.Maps
{
    public partial class MapService
    {
        private void ValidateAddressSearchOnSearch(AddressSearch addressSearch)
        {
            ValidateAddressSearchIsNotNull(addressSearch);

            Validate(
                (Rule: IsInvalidQuery(addressSearch.Query), Parameter: nameof(AddressSearch.Query)));
        }

        private void ValidateAddressSearchIsNotNull(AddressSearch addressSearch)
        {
            if(addressSearch is null)
            {
                throw new NullAddressSearchException();
            }
        }

        private static dynamic IsInvalidQuery(string query) => new
        {
            Condition = String.IsNullOrWhiteSpace(query),
            Message = "Query is required"
        };

        private static void Validate (params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidMapException = new InvalidMapException();

            foreach((dynamic rule, string parameter) in validations)
            {
                if(rule.Condition)
                {
                    invalidMapException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidMapException.ThrowIfContainsErrors();
        }
    }
}
