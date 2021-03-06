//----------------------------------------------------------------------- 
// PDS WITSMLstudio Store, 2018.3
//
// Copyright 2018 PDS Americas LLC
// 
// Licensed under the PDS Open Source WITSML Product License Agreement (the
// "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.pds.group/WITSMLstudio/OpenSource/ProductLicenseAgreement
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

// ----------------------------------------------------------------------
// <auto-generated>
//     Changes to this file may cause incorrect behavior and will be lost
//     if the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------
using System.ComponentModel.Composition;
using Energistics.DataAccess.WITSML200;
using PDS.WITSMLstudio.Framework;

namespace PDS.WITSMLstudio.Store.Data.WellboreGeologies
{
    /// <summary>
    /// Provides validation for <see cref="WellboreGeology" /> data objects.
    /// </summary>
    /// <seealso cref="PDS.WITSMLstudio.Store.Data.DataObjectValidator{WellboreGeology}" />
    [Export(typeof(IDataObjectValidator<WellboreGeology>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class WellboreGeology200Validator : DataObjectValidator<WellboreGeology>
    {
        private readonly IWitsmlDataAdapter<WellboreGeology> _wellboreGeologyDataAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WellboreGeology200Validator" /> class.
        /// </summary>
        /// <param name="container">The composition container.</param>
        /// <param name="wellboreGeologyDataAdapter">The wellboreGeology data adapter.</param>
        [ImportingConstructor]
        public WellboreGeology200Validator(
            IContainer container,
            IWitsmlDataAdapter<WellboreGeology> wellboreGeologyDataAdapter)
            : base(container)
        {
            _wellboreGeologyDataAdapter = wellboreGeologyDataAdapter;
        }
    }
}