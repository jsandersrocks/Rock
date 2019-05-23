using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Rock.Web.UI.Controls;

namespace Rock.Field.Types
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Rock.Field.FieldType" />
    public class ConditionalScaleFieldType : DecimalFieldType
    {
        #region ConfigurationKeys

        private static class ConfigurationKey
        {
            public const string ConfigurationJSON = "ConfigurationJSON";
        }

        #endregion ConfigurationKeys

        #region Configuration

        /// <summary>
        /// Returns a list of the configuration keys
        /// </summary>
        /// <returns></returns>
        public override List<string> ConfigurationKeys()
        {
            var keys = base.ConfigurationKeys();
            keys.Add( ConfigurationKey.ConfigurationJSON );
            return keys;
        }

        /// <summary>
        /// Creates the HTML controls required to configure this type of field
        /// </summary>
        /// <returns></returns>
        public override List<Control> ConfigurationControls()
        {
            var controls = base.ConfigurationControls();

            var pnlRulesEditor = new Panel();

            var conditionalScaleRulesControlsRepeater = new Repeater { ID = "conditionalScaleRulesControlsRepeater" };
            conditionalScaleRulesControlsRepeater.ItemTemplate = new ConditionalScaleRangeRuleItemTemplate();
            conditionalScaleRulesControlsRepeater.ItemDataBound += ConditionalScaleRulesControlsRepeater_ItemDataBound;
            pnlRulesEditor.Controls.Add( conditionalScaleRulesControlsRepeater );

            LinkButton btnAddRule = new LinkButton { ID = "btnAddRule", CssClass = "btn btn-action btn-xs margin-b-md", Text = "<i class='fa fa-plus-circle'></i>", CausesValidation = false };
            btnAddRule.Click += BtnAddRule_Click;
            pnlRulesEditor.Controls.Add( btnAddRule );

            controls.Add( pnlRulesEditor );

            return controls;
        }

        /// <summary>
        /// Sets the configuration value.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <param name="configurationValues">The configuration values.</param>
        public override void SetConfigurationValues( List<Control> controls, Dictionary<string, ConfigurationValue> configurationValues )
        {
            base.SetConfigurationValues( controls, configurationValues );

            if ( controls == null || controls.Count < 1 )
            {
                return;
            }

            var pnlRulesEditor = controls[0] as Panel;

            var conditionalScaleRulesControlsRepeater = pnlRulesEditor.FindControl( "conditionalScaleRulesControlsRepeater" ) as Repeater;

            var configurationJSON = configurationValues.GetValueOrNull( ConfigurationKey.ConfigurationJSON );

            List<ConditionalScaleRangeRule> conditionalScaleRangeRuleList = configurationJSON.FromJsonOrNull<List<ConditionalScaleRangeRule>>() ?? new List<ConditionalScaleRangeRule>();
            conditionalScaleRangeRuleList = conditionalScaleRangeRuleList.OrderBy( a => a.RangeIndex ).ThenBy( a => a.Label ).ToList();
            if ( !conditionalScaleRangeRuleList.Any() )
            {
                conditionalScaleRangeRuleList.Add( new ConditionalScaleRangeRule() );
            }

            conditionalScaleRulesControlsRepeater.DataSource = conditionalScaleRangeRuleList;
            conditionalScaleRulesControlsRepeater.DataBind();
        }

        /// <summary>
        /// Handles the ItemDataBound event of the ConditionalScaleRulesControlsRepeater control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        private void ConditionalScaleRulesControlsRepeater_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            var repeaterItem = e.Item;

            ConditionalScaleRangeRule conditionalScaleRangeRule = e.Item.DataItem as ConditionalScaleRangeRule;

            HtmlGenericContainer conditionalScaleRangeRuleContainer = repeaterItem.FindControl( "conditionalScaleRangeRuleContainer" ) as HtmlGenericContainer;
            var labelTextBox = conditionalScaleRangeRuleContainer.FindControl( "labelTextBox" ) as TextBox;
            var highValueNumberBox = conditionalScaleRangeRuleContainer.FindControl( "highValueNumberBox" ) as NumberBox;
            var colorPicker = conditionalScaleRangeRuleContainer.FindControl( "colorPicker" ) as ColorPicker;
            var lowValueNumberBox = conditionalScaleRangeRuleContainer.FindControl( "lowValueNumberBox" ) as NumberBox;

            labelTextBox.Text = conditionalScaleRangeRule.Label;
            // from http://stackoverflow.com/a/216705/1755417 (to trim trailing zeros)
            highValueNumberBox.Text = conditionalScaleRangeRule.HighValue?.ToString( "G29" );
            colorPicker.Text = conditionalScaleRangeRule.Color;
            lowValueNumberBox.Text = conditionalScaleRangeRule.LowValue?.ToString( "G29" );
        }

        /// <summary>
        /// Handles the Click event of the BtnAddRule control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnAddRule_Click( object sender, System.EventArgs e )
        {
            LinkButton btnAddRule = sender as LinkButton;
            var pnlRulesEditor = btnAddRule.Parent as Panel;
            var conditionalScaleRulesControlsRepeater = pnlRulesEditor.FindControl( "conditionalScaleRulesControlsRepeater" ) as Repeater;
            List<ConditionalScaleRangeRule> conditionalScaleRangeRuleList = GetRangeRulesListFromRepeaterControls( conditionalScaleRulesControlsRepeater );
            conditionalScaleRangeRuleList.Add( new ConditionalScaleRangeRule() );
            conditionalScaleRulesControlsRepeater.DataSource = conditionalScaleRangeRuleList;
            conditionalScaleRulesControlsRepeater.DataBind();
        }

        /// <summary>
        /// Gets the range rules list from repeater controls.
        /// </summary>
        /// <param name="conditionalScaleRulesControlsRepeater">The conditional scale rules controls repeater.</param>
        /// <returns></returns>
        private static List<ConditionalScaleRangeRule> GetRangeRulesListFromRepeaterControls( Repeater conditionalScaleRulesControlsRepeater )
        {
            List<ConditionalScaleRangeRule> conditionalScaleRangeRuleList = new List<ConditionalScaleRangeRule>();
            int rangeIndex = 0;
            foreach ( var repeaterItem in conditionalScaleRulesControlsRepeater.Items.OfType<RepeaterItem>() )
            {
                HtmlGenericContainer conditionalScaleRangeRuleContainer = repeaterItem.FindControl( "conditionalScaleRangeRuleContainer" ) as HtmlGenericContainer;
                var labelTextBox = conditionalScaleRangeRuleContainer.FindControl( "labelTextBox" ) as TextBox;
                var highValueNumberBox = conditionalScaleRangeRuleContainer.FindControl( "highValueNumberBox" ) as NumberBox;
                var colorPicker = conditionalScaleRangeRuleContainer.FindControl( "colorPicker" ) as ColorPicker;
                var lowValueNumberBox = conditionalScaleRangeRuleContainer.FindControl( "lowValueNumberBox" ) as NumberBox;
                conditionalScaleRangeRuleList.Add( new ConditionalScaleRangeRule
                {
                    RangeIndex = rangeIndex++,
                    Label = labelTextBox.Text,
                    Color = colorPicker.Value,
                    HighValue = highValueNumberBox.Text.AsDecimalOrNull(),
                    LowValue = lowValueNumberBox.Text.AsDecimalOrNull()
                } );
            }

            return conditionalScaleRangeRuleList;
        }

        /// <summary>
        /// Gets the configuration value.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        public override Dictionary<string, ConfigurationValue> ConfigurationValues( List<Control> controls )
        {
            var configurationValue = new ConfigurationValue( "Configuration JSON", "The JSON data used for the conditional formatting rules", string.Empty );
            var pnlRulesEditor = controls[0];
            var conditionalScaleRulesControlsRepeater = pnlRulesEditor.FindControl( "conditionalScaleRulesControlsRepeater" ) as Repeater;

            var rules = GetRangeRulesListFromRepeaterControls( conditionalScaleRulesControlsRepeater );

            configurationValue.Value = rules.ToJson();

            var values = base.ConfigurationValues( controls );
            values.Add( ConfigurationKey.ConfigurationJSON, configurationValue );

            return values;
        }

        #endregion Configuration

        #region Formatting

        /// <summary>
        /// Returns the field's current value(s)
        /// </summary> 
        /// <param name="parentControl">The parent control.</param>
        /// <param name="value">Information about the value</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="condensed">Flag indicating if the value should be condensed (i.e. for use in a grid column)</param>
        /// <returns></returns>
        public override string FormatValue( System.Web.UI.Control parentControl, string value, System.Collections.Generic.Dictionary<string, ConfigurationValue> configurationValues, bool condensed )
        {
            decimal? rangeValue = value.AsDecimalOrNull();
            if ( rangeValue == null )
            {
                return string.Empty;
            }

            var configurationJSON = configurationValues.GetValueOrNull( ConfigurationKey.ConfigurationJSON );
            List<ConditionalScaleRangeRule> conditionalScaleRangeRuleList = configurationJSON.FromJsonOrNull<List<ConditionalScaleRangeRule>>() ?? new List<ConditionalScaleRangeRule>();

            var matchingRangeRule = conditionalScaleRangeRuleList.FirstOrDefault( a => ( a.HighValue ?? decimal.MaxValue ) >= rangeValue.Value && rangeValue.Value >= ( a.LowValue ?? decimal.MinValue ) );
            if ( matchingRangeRule != null )
            {
                return $"<span class='label scale-label' style='background-color:{matchingRangeRule.Color}'>{matchingRangeRule.Label}</span>";
            }
            else
            {
                // if out-of-range, display nothing
                return string.Empty;
            }
        }

        #endregion

        #region Classes

        /// <summary>
        /// 
        /// </summary>
        private class ConditionalScaleRangeRule
        {
            public int RangeIndex { get; set; }

            public string Label { get; set; }

            public string Color { get; set; }

            public decimal? HighValue { get; set; }

            public decimal? LowValue { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="System.Web.UI.ITemplate" />
        private class ConditionalScaleRangeRuleItemTemplate : ITemplate
        {
            /// <summary>
            /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control" /> object that child controls and templates belong to. These child controls are in turn defined within an inline template.
            /// </summary>
            /// <param name="container">The <see cref="T:System.Web.UI.Control" /> object to contain the instances of controls from the inline template.</param>
            public void InstantiateIn( Control container )
            {
                HtmlGenericContainer conditionalScaleRangeRuleContainer = new HtmlGenericContainer { ID = $"conditionalScaleRangeRuleContainer", CssClass = "row" };
                Panel pnlColumn1 = new Panel { ID = "pnlColumn1", CssClass = "col-md-5" };
                var labelTextBox = new RockTextBox { ID = "labelTextBox", Placeholder = "Label", CssClass = "margin-b-md" };
                pnlColumn1.Controls.Add( labelTextBox );
                var highValueNumberBox = new NumberBox { ID = "highValueNumberBox", Placeholder = "High Value", CssClass = "margin-b-md" };
                pnlColumn1.Controls.Add( highValueNumberBox );
                conditionalScaleRangeRuleContainer.Controls.Add( pnlColumn1 );

                Panel pnlColumn2 = new Panel { ID = "pnlColumn2", CssClass = "col-md-5" };
                var colorPicker = new ColorPicker { ID = "colorPicker", CssClass = "margin-b-md" };
                pnlColumn2.Controls.Add( colorPicker );
                var lowValueNumberBox = new NumberBox { ID = "lowValueNumberBox", Placeholder = "Low Value", NumberType = ValidationDataType.Double };
                pnlColumn2.Controls.Add( lowValueNumberBox );
                conditionalScaleRangeRuleContainer.Controls.Add( pnlColumn2 );

                Panel pnlColumn3 = new Panel { ID = "pnlColumn3", CssClass = "col-md-2" };
                LinkButton btnDeleteRule = new LinkButton { ID = "btnDeleteRule", CssClass = "btn btn-danger btn-sm", CausesValidation = false, Text = "<i class='fa fa-times'></i>" };
                btnDeleteRule.Click += BtnDeleteRule_Click;
                pnlColumn3.Controls.Add( btnDeleteRule );
                conditionalScaleRangeRuleContainer.Controls.Add( pnlColumn3 );

                container.Controls.Add( conditionalScaleRangeRuleContainer );
                container.Controls.Add( new HtmlGenericControl( "hr" ) );
            }

            /// <summary>
            /// Handles the Click event of the BtnDeleteRule control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void BtnDeleteRule_Click( object sender, System.EventArgs e )
            {
                LinkButton btnDeleteRule = sender as LinkButton;

                var repeaterItem = btnDeleteRule.FirstParentControlOfType<RepeaterItem>();
                var rangeIndexToDelete = repeaterItem.ItemIndex;
                var conditionalScaleRulesControlsRepeater = repeaterItem.NamingContainer as Repeater;
                List<ConditionalScaleRangeRule> conditionalScaleRangeRuleList = GetRangeRulesListFromRepeaterControls( conditionalScaleRulesControlsRepeater );
                conditionalScaleRangeRuleList = conditionalScaleRangeRuleList.Where( a => a.RangeIndex != rangeIndexToDelete ).ToList();
                conditionalScaleRulesControlsRepeater.DataSource = conditionalScaleRangeRuleList;
                conditionalScaleRulesControlsRepeater.DataBind();
            }
        }

        #endregion
    }
}
