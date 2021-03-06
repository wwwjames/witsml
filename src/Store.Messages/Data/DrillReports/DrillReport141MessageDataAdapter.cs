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
using Energistics.DataAccess.WITSML141;
using PDS.WITSMLstudio.Framework;
using PDS.WITSMLstudio.Store.Configuration;

namespace PDS.WITSMLstudio.Store.Data.DrillReports
{
    /// <summary>
    /// Data adapter that encapsulates CRUD functionality for <see cref="DrillReport" />
    /// </summary>
    /// <seealso cref="PDS.WITSMLstudio.Store.Data.MessageDataAdapter{DrillReport}" />
    /// <seealso cref="PDS.WITSMLstudio.Store.Configuration.IWitsml141Configuration" />
    [Export(typeof(IWitsml141Configuration))]
    [Export(typeof(IWitsmlDataAdapter<DrillReport>))]
    [Export141(ObjectTypes.DrillReport, typeof(IWitsmlDataAdapter))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DrillReport141MessageDataAdapter : MessageDataAdapter<DrillReport>, IWitsml141Configuration    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrillReport141MessageDataAdapter" /> class.
        /// </summary>
        /// <param name="container">The composition container.</param>
        [ImportingConstructor]
        public DrillReport141MessageDataAdapter(IContainer container)
            : base(container, ObjectNames.DrillReport141)
        {
            Logger.Verbose("Instance created.");
        }

        /// <summary>
        /// Gets the supported capabilities for the <see cref="DrillReport"/> object.
        /// </summary>
        /// <param name="capServer">The capServer instance.</param>
        public void GetCapabilities(CapServer capServer)
        {
            Logger.DebugFormat("Getting the supported capabilities for DrillReport data version {0}.", capServer.Version);

            if (MessageHandler.IsQueryEnabled)
                capServer.Add(Functions.GetFromStore, ObjectTypes.DrillReport);

            capServer.Add(Functions.AddToStore, ObjectTypes.DrillReport);
            capServer.Add(Functions.UpdateInStore, ObjectTypes.DrillReport);
            //capServer.Add(Functions.DeleteFromStore, ObjectTypes.DrillReport);
      }
    }
}