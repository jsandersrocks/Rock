﻿// <copyright>
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
using System.Collections.Generic;
using Rock.Mobile.Common.Enums;

namespace Rock.Mobile
{
    /// <summary>
    /// This class is used to store and retrieve
    /// Additional Setting for Mobile against the Site Entity
    /// </summary>
    public class AdditionalSettings
    {
        /// <summary>
        /// Gets or sets the type of the shell.
        /// </summary>
        /// <value>
        /// The type of the shell.
        /// </value>
        public ShellType? ShellType { get; set; }

        /// <summary>
        /// Gets or sets the tab location.
        /// </summary>
        /// <value>
        /// The tab location.
        /// </value>
        public TabLocation? TabLocation { get; set; }

        /// <summary>
        /// Gets or sets the CSS style.
        /// </summary>
        /// <value>
        /// The CSS style.
        /// </value>
        public string CssStyle { get; set; }

        /// <summary>
        /// Gets or sets the API key identifier.
        /// </summary>
        /// <value>
        /// The API key identifier.
        /// </value>
        public int? ApiKeyId { get; set; }

        /// <summary>
        /// Gets or sets the profile page identifier.
        /// </summary>
        /// <value>
        /// The profile page identifier.
        /// </value>
        public int? ProfilePageId { get; set; }

        /// <summary>
        /// Gets or sets the person attribute categories.
        /// </summary>
        /// <value>
        /// The person attribute categories.
        /// </value>
        public List<int> PersonAttributeCategories { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the color of the bar background.
        /// </summary>
        /// <value>
        /// The color of the bar background.
        /// </value>
        public string BarBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the menu button.
        /// </summary>
        /// <value>
        /// The color of the menu button.
        /// </value>
        public string MenuButtonColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the activity indicator.
        /// </summary>
        /// <value>
        /// The color of the activity indicator.
        /// </value>
        public string ActivityIndicatorColor { get; set; }
    }
}
