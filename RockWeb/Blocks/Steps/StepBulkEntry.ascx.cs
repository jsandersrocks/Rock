// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System.ComponentModel;
using Rock.Attribute;
using Rock.Model;
using Rock.Web.UI;

namespace RockWeb.Blocks.Steps
{
    [DisplayName( "Step Bulk Entry" )]
    [Category( "Steps" )]
    [Description( "Displays a form to add multiple steps at a time." )]

    #region Block Attributes

    [IntegerField(
        name: "Step Type Id",
        description: "The step type to use to add a new step. Leave blank to use the query string: StepTypeId. The type of the step, if step id is specified, overrides this setting.",
        required: false,
        order: 1,
        key: AttributeKey.StepType )]

    #endregion Block Attributes

    public partial class StepBulkEntry : RockBlock
    {
        #region Keys

        /// <summary>
        /// Keys for block attributes
        /// </summary>
        protected static class AttributeKey
        {
            /// <summary>
            /// The step type
            /// </summary>
            public const string StepType = "StepType";
        }

        /// <summary>
        /// Keys for the page parameters
        /// </summary>
        protected static class ParameterKey
        {
            /// <summary>
            /// The step type identifier
            /// </summary>
            public const string StepTypeId = "StepTypeId";
        }

        #endregion Keys
    }
}

