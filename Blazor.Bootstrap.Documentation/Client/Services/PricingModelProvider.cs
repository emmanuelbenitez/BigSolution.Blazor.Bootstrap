#region Copyright & License

// Copyright © 2020 - 2021 Emmanuel Benitez
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Collections.Generic;
using Blazor.Bootstrap.Documentation.Client.Models.Examples;

namespace Blazor.Bootstrap.Documentation.Client.Services
{
    public class PricingModelProvider : IPricingModelProvider
    {
        #region IPricingModelProvider Members

        public IEnumerable<PricingModel> GetPricingModels()
        {
            yield return new PricingModel() {
                Name = "Free",
                Price = 0,
                Feature = new[] {
                    "10 users included",
                    "2 GB of storage",
                    "Email support",
                    "Help center access"
                }
            };
            yield return new PricingModel() {
                Name = "Pro",
                Price = 15,
                Feature = new[] {
                    "20 users included",
                    "10 GB of storage",
                    "Priority email support",
                    "Help center access"
                }
            };
            yield return new PricingModel() {
                Name = "Enterprise",
                Price = 29,
                Feature = new[] {
                    "30 users included",
                    "15 GB of storage",
                    "Phone and email support",
                    "Help center access"
                }
            };
        }

        #endregion
    }
}
