﻿//----------------------------------------------------------------------- 
// PDS.Witsml.Server, 2016.1
//
// Copyright 2016 Petrotechnical Data Systems
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Energistics.DataAccess.WITSML131;
using PDS.Framework;

namespace PDS.Witsml.Server.Data.Wellbores
{
    /// <summary>
    /// Data provider that implements support for WITSML API functions for <see cref="Wellbore"/>.
    /// </summary>
    /// <seealso cref="PDS.Witsml.Server.Data.WitsmlDataProvider{WellboreList, Wellbore}" />
    [Export(typeof(IEtpDataProvider))]
    [Export131(ObjectTypes.Wellbore, typeof(IEtpDataProvider))]
    [Export131(ObjectTypes.Wellbore, typeof(IWitsmlDataProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Wellbore131DataProvider : WitsmlDataProvider<WellboreList, Wellbore>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wellbore131DataProvider"/> class.
        /// </summary>
        /// <param name="container">The composition container.</param>
        /// <param name="dataAdapter">The data adapter.</param>
        [ImportingConstructor]
        public Wellbore131DataProvider(IContainer container, IWitsmlDataAdapter<Wellbore> dataAdapter) : base(container, dataAdapter)
        {
        }

        /// <summary>
        /// Sets the default values for the specified data object.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        protected override void SetDefaultValues(Wellbore dataObject)
        {
            dataObject.Uid = dataObject.NewUid();
            dataObject.CommonData = dataObject.CommonData.Create();
        }

        /// <summary>
        /// Creates an <see cref="WellboreList" /> instance containing the specified data objects.
        /// </summary>
        /// <param name="dataObjects">The data objects.</param>
        /// <returns>The <see cref="WellboreList" /> instance.</returns>
        protected override WellboreList CreateCollection(List<Wellbore> dataObjects)
        {
            return new WellboreList { Wellbore = dataObjects };
        }
    }
}
